using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Win11ContextMenu
{
    public partial class Form1 : Form
    {
        const string CLASSIC_REG = @"SOFTWARE\CLASSES\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}";
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonClassic_Click(object sender, EventArgs e)
        {
            RegistryKey newKey = Registry.CurrentUser.CreateSubKey(CLASSIC_REG + @"\InprocServer32");
            newKey.SetValue("", "", RegistryValueKind.String);
            MessageBox.Show("OK");
        }
        private void buttonDefault_Click(object sender, EventArgs e)
        {
            if (Registry.CurrentUser.OpenSubKey(CLASSIC_REG) != null)
                Registry.CurrentUser.DeleteSubKeyTree(CLASSIC_REG);
            MessageBox.Show("OK");
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Process[] ps_list = Process.GetProcessesByName("explorer");
            foreach (Process ps_explorer in ps_list)
            {
                ps_explorer.Kill();
                ps_explorer.WaitForExit(1000);
            }
            ps_list = Process.GetProcessesByName("explorer");
            for (int i = 0; i < 3; i++)
            {
                if (ps_list.Length > 0)
                    break;
                Thread.Sleep(200);
            }
            if (ps_list.Length == 0)
            {
                Process.Start("explorer.exe");
            }
        }
    }
}
