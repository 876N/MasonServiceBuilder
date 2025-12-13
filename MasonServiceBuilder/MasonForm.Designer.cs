namespace MasonServiceBuilder
{
    partial class MasonForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Button SelectButton2;
        private Guna.UI2.WinForms.Guna2Button BuildButton1;
        private Guna.UI2.WinForms.Guna2ControlBox MinimizeButton;
        private Guna.UI2.WinForms.Guna2ControlBox CloseButton;
        private Guna.UI2.WinForms.Guna2Separator Separator;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm;
        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel AppTitleLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel VersionLabelCustom;
        private Guna.UI2.WinForms.Guna2GradientButton GradientBuildButtonCustom;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Elipse ButtonElipseCustom;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasonForm));
            this.SelectButton2 = new Guna.UI2.WinForms.Guna2Button();
            this.BuildButton1 = new Guna.UI2.WinForms.Guna2Button();
            this.AppTitleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.VersionLabelCustom = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MinimizeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.CloseButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Separator = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2ShadowForm = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.AppNamelabel = new System.Windows.Forms.Label();
            this.AssemblyCheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.IconCheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.SelectButton = new Guna.UI2.WinForms.Guna2Button();
            this.PathTextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.GradientBuildButtonCustom = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.ButtonElipseCustom = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.CopyRight = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.MainPanel.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectButton2
            // 
            this.SelectButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SelectButton2.ForeColor = System.Drawing.Color.White;
            this.SelectButton2.Location = new System.Drawing.Point(0, 0);
            this.SelectButton2.Name = "SelectButton2";
            this.SelectButton2.Size = new System.Drawing.Size(180, 45);
            this.SelectButton2.TabIndex = 0;
            // 
            // BuildButton1
            // 
            this.BuildButton1.Animated = true;
            this.BuildButton1.BackColor = System.Drawing.Color.Transparent;
            this.BuildButton1.BorderRadius = 12;
            this.BuildButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BuildButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BuildButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BuildButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BuildButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BuildButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(180)))));
            this.BuildButton1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.BuildButton1.ForeColor = System.Drawing.Color.White;
            this.BuildButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.BuildButton1.Location = new System.Drawing.Point(0, 0);
            this.BuildButton1.Name = "BuildButton1";
            this.BuildButton1.ShadowDecoration.BorderRadius = 12;
            this.BuildButton1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.BuildButton1.ShadowDecoration.Depth = 15;
            this.BuildButton1.ShadowDecoration.Enabled = true;
            this.BuildButton1.Size = new System.Drawing.Size(470, 50);
            this.BuildButton1.TabIndex = 5;
            this.BuildButton1.Text = "Build Service";
            this.BuildButton1.Visible = false;
            this.BuildButton1.Click += new System.EventHandler(this.BuildButton1_Click);
            // 
            // AppTitleLabel
            // 
            this.AppTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.AppTitleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.AppTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.AppTitleLabel.Location = new System.Drawing.Point(51, 3);
            this.AppTitleLabel.Name = "AppTitleLabel";
            this.AppTitleLabel.Size = new System.Drawing.Size(200, 27);
            this.AppTitleLabel.TabIndex = 3;
            this.AppTitleLabel.Text = "Mason Service Builder";
            this.AppTitleLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VersionLabelCustom
            // 
            this.VersionLabelCustom.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabelCustom.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.VersionLabelCustom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(140)))), ((int)(((byte)(220)))));
            this.VersionLabelCustom.Location = new System.Drawing.Point(51, 26);
            this.VersionLabelCustom.Name = "VersionLabelCustom";
            this.VersionLabelCustom.Size = new System.Drawing.Size(60, 15);
            this.VersionLabelCustom.TabIndex = 5;
            this.VersionLabelCustom.Text = "Version 1.0";
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.Animated = true;
            this.MinimizeButton.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeButton.FillColor = System.Drawing.Color.Transparent;
            this.MinimizeButton.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.MinimizeButton.HoverState.IconColor = System.Drawing.Color.Transparent;
            this.MinimizeButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(140)))), ((int)(((byte)(220)))));
            this.MinimizeButton.Location = new System.Drawing.Point(409, 0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(50, 47);
            this.MinimizeButton.TabIndex = 2;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Animated = true;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.FillColor = System.Drawing.Color.Transparent;
            this.CloseButton.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.CloseButton.HoverState.IconColor = System.Drawing.Color.Transparent;
            this.CloseButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(140)))), ((int)(((byte)(220)))));
            this.CloseButton.Location = new System.Drawing.Point(458, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(53, 47);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Separator
            // 
            this.Separator.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.Separator.Location = new System.Drawing.Point(0, 200);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(500, 1);
            this.Separator.TabIndex = 7;
            // 
            // guna2ShadowForm
            // 
            this.guna2ShadowForm.BorderRadius = 25;
            this.guna2ShadowForm.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(200)))));
            this.guna2ShadowForm.TargetForm = this;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.MainPanel.Controls.Add(this.guna2Panel3);
            this.MainPanel.Controls.Add(this.guna2Panel4);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(535, 235);
            this.MainPanel.TabIndex = 8;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderRadius = 6;
            this.guna2Panel3.Controls.Add(this.guna2ComboBox1);
            this.guna2Panel3.Controls.Add(this.AppNamelabel);
            this.guna2Panel3.Controls.Add(this.AssemblyCheckBox1);
            this.guna2Panel3.Controls.Add(this.pictureBox2);
            this.guna2Panel3.Controls.Add(this.IconCheckBox1);
            this.guna2Panel3.Controls.Add(this.SelectButton);
            this.guna2Panel3.Controls.Add(this.PathTextBox1);
            this.guna2Panel3.Controls.Add(this.GradientBuildButtonCustom);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(1)))), ((int)(((byte)(50)))));
            this.guna2Panel3.Location = new System.Drawing.Point(12, 75);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.BorderRadius = 10;
            this.guna2Panel3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(180)))));
            this.guna2Panel3.ShadowDecoration.Depth = 50;
            this.guna2Panel3.ShadowDecoration.Enabled = true;
            this.guna2Panel3.Size = new System.Drawing.Size(511, 147);
            this.guna2Panel3.TabIndex = 72;
            this.guna2Panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel3_Paint);
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.Animated = true;
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.guna2ComboBox1.BorderRadius = 6;
            this.guna2ComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.guna2ComboBox1.ItemHeight = 16;
            this.guna2ComboBox1.Items.AddRange(new object[] {
            ".exe",
            ".scr",
            ".com",
            ".pif",
            ".bat",
            ".cmd"});
            this.guna2ComboBox1.Location = new System.Drawing.Point(148, 55);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(76, 22);
            this.guna2ComboBox1.TabIndex = 174;
            this.guna2ComboBox1.Tag = "";
            this.guna2ComboBox1.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // AppNamelabel
            // 
            this.AppNamelabel.AutoSize = true;
            this.AppNamelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.AppNamelabel.Location = new System.Drawing.Point(227, 59);
            this.AppNamelabel.Name = "AppNamelabel";
            this.AppNamelabel.Size = new System.Drawing.Size(0, 15);
            this.AppNamelabel.TabIndex = 40;
            this.AppNamelabel.Click += new System.EventHandler(this.AppNamelabel_Click);
            // 
            // AssemblyCheckBox1
            // 
            this.AssemblyCheckBox1.AutoSize = true;
            this.AssemblyCheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.AssemblyCheckBox1.CheckedState.BorderRadius = 1;
            this.AssemblyCheckBox1.CheckedState.BorderThickness = 2;
            this.AssemblyCheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.AssemblyCheckBox1.Location = new System.Drawing.Point(10, 58);
            this.AssemblyCheckBox1.Name = "AssemblyCheckBox1";
            this.AssemblyCheckBox1.Size = new System.Drawing.Size(77, 19);
            this.AssemblyCheckBox1.TabIndex = 39;
            this.AssemblyCheckBox1.Text = "Assembly";
            this.AssemblyCheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.AssemblyCheckBox1.UncheckedState.BorderRadius = 2;
            this.AssemblyCheckBox1.UncheckedState.BorderThickness = 1;
            this.AssemblyCheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.AssemblyCheckBox1.CheckedChanged += new System.EventHandler(this.AssemblyCheckBox1_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(383, 53);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // IconCheckBox1
            // 
            this.IconCheckBox1.AutoSize = true;
            this.IconCheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.IconCheckBox1.CheckedState.BorderRadius = 1;
            this.IconCheckBox1.CheckedState.BorderThickness = 2;
            this.IconCheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.IconCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconCheckBox1.Location = new System.Drawing.Point(93, 58);
            this.IconCheckBox1.Name = "IconCheckBox1";
            this.IconCheckBox1.Size = new System.Drawing.Size(49, 19);
            this.IconCheckBox1.TabIndex = 37;
            this.IconCheckBox1.Text = "Icon";
            this.IconCheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.IconCheckBox1.UncheckedState.BorderRadius = 2;
            this.IconCheckBox1.UncheckedState.BorderThickness = 1;
            this.IconCheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.IconCheckBox1.CheckedChanged += new System.EventHandler(this.IconCheckBox1_CheckedChanged);
            // 
            // SelectButton
            // 
            this.SelectButton.Animated = true;
            this.SelectButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.SelectButton.BorderRadius = 9;
            this.SelectButton.BorderThickness = 1;
            this.SelectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectButton.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.SelectButton.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.SelectButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.SelectButton.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.SelectButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.SelectButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.SelectButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.SelectButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.SelectButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))));
            this.SelectButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.SelectButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectButton.Image")));
            this.SelectButton.Location = new System.Drawing.Point(409, 12);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(97, 38);
            this.SelectButton.TabIndex = 34;
            this.SelectButton.Text = "Browse";
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // PathTextBox1
            // 
            this.PathTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.PathTextBox1.BorderRadius = 8;
            this.PathTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PathTextBox1.DefaultText = "";
            this.PathTextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
            this.PathTextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.PathTextBox1.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.PathTextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.PathTextBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.PathTextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.PathTextBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PathTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.PathTextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.PathTextBox1.Location = new System.Drawing.Point(8, 12);
            this.PathTextBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PathTextBox1.Name = "PathTextBox1";
            this.PathTextBox1.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.PathTextBox1.PlaceholderText = "Select file or drag and drop here...";
            this.PathTextBox1.SelectedText = "";
            this.PathTextBox1.Size = new System.Drawing.Size(393, 38);
            this.PathTextBox1.TabIndex = 26;
            this.PathTextBox1.TextChanged += new System.EventHandler(this.PathTextBox1_TextChanged);
            // 
            // GradientBuildButtonCustom
            // 
            this.GradientBuildButtonCustom.Animated = true;
            this.GradientBuildButtonCustom.BackColor = System.Drawing.Color.Transparent;
            this.GradientBuildButtonCustom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.GradientBuildButtonCustom.BorderRadius = 12;
            this.GradientBuildButtonCustom.BorderThickness = 2;
            this.GradientBuildButtonCustom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GradientBuildButtonCustom.CustomizableEdges.BottomLeft = false;
            this.GradientBuildButtonCustom.CustomizableEdges.BottomRight = false;
            this.GradientBuildButtonCustom.CustomizableEdges.TopLeft = false;
            this.GradientBuildButtonCustom.CustomizableEdges.TopRight = false;
            this.GradientBuildButtonCustom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GradientBuildButtonCustom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GradientBuildButtonCustom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GradientBuildButtonCustom.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GradientBuildButtonCustom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GradientBuildButtonCustom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(200)))));
            this.GradientBuildButtonCustom.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.GradientBuildButtonCustom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.GradientBuildButtonCustom.ForeColor = System.Drawing.Color.White;
            this.GradientBuildButtonCustom.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.GradientBuildButtonCustom.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.GradientBuildButtonCustom.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GradientBuildButtonCustom.ImageOffset = new System.Drawing.Point(-10, 0);
            this.GradientBuildButtonCustom.ImageSize = new System.Drawing.Size(30, 30);
            this.GradientBuildButtonCustom.Location = new System.Drawing.Point(8, 85);
            this.GradientBuildButtonCustom.Name = "GradientBuildButtonCustom";
            this.GradientBuildButtonCustom.ShadowDecoration.BorderRadius = 12;
            this.GradientBuildButtonCustom.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(200)))));
            this.GradientBuildButtonCustom.ShadowDecoration.Depth = 20;
            this.GradientBuildButtonCustom.ShadowDecoration.Enabled = true;
            this.GradientBuildButtonCustom.Size = new System.Drawing.Size(498, 50);
            this.GradientBuildButtonCustom.TabIndex = 5;
            this.GradientBuildButtonCustom.Text = "Build Service";
            this.GradientBuildButtonCustom.TextOffset = new System.Drawing.Point(10, 0);
            this.GradientBuildButtonCustom.Click += new System.EventHandler(this.BuildButton1_Click);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderRadius = 6;
            this.guna2Panel4.Controls.Add(this.pictureBox1);
            this.guna2Panel4.Controls.Add(this.AppTitleLabel);
            this.guna2Panel4.Controls.Add(this.VersionLabelCustom);
            this.guna2Panel4.Controls.Add(this.CloseButton);
            this.guna2Panel4.Controls.Add(this.MinimizeButton);
            this.guna2Panel4.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.guna2Panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(1)))), ((int)(((byte)(50)))));
            this.guna2Panel4.Location = new System.Drawing.Point(12, 15);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.BorderRadius = 10;
            this.guna2Panel4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(180)))));
            this.guna2Panel4.ShadowDecoration.Depth = 50;
            this.guna2Panel4.ShadowDecoration.Enabled = true;
            this.guna2Panel4.Size = new System.Drawing.Size(511, 47);
            this.guna2Panel4.TabIndex = 74;
            this.guna2Panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel4_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ButtonElipseCustom
            // 
            this.ButtonElipseCustom.BorderRadius = 9;
            this.ButtonElipseCustom.TargetControl = this;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.TargetControl = this.guna2Panel4;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // CopyRight
            // 
            this.CopyRight.AllowLinksHandling = true;
            this.CopyRight.AutoPopDelay = 9000;
            this.CopyRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.CopyRight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.CopyRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.CopyRight.InitialDelay = 500;
            this.CopyRight.MaximumSize = new System.Drawing.Size(0, 0);
            this.CopyRight.ReshowDelay = 100;
            this.CopyRight.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.CopyRight.Popup += new System.Windows.Forms.PopupEventHandler(this.CopyRight_Popup);
            // 
            // MasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(535, 235);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.Separator);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MasonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mason Service Builder v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainPanel.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2TextBox PathTextBox1;
        private Guna.UI2.WinForms.Guna2Button SelectButton;
        private Guna.UI2.WinForms.Guna2CheckBox IconCheckBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2CheckBox AssemblyCheckBox1;
        private System.Windows.Forms.Label AppNamelabel;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        internal Guna.UI2.WinForms.Guna2HtmlToolTip CopyRight;
    }
}