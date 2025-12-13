using System;
using System.Windows.Forms;

namespace MasonServiceBuilder
{
    static class MasonProgram
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MasonForm());
        }
    }
}