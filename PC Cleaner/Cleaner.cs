using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Action = System.Action;


namespace Build
{
    enum RecycleFlag : int
    {
        SHERB_NOCONFIRMATION = 0x00000001, // No confirmation, when emptying 
        SHERB_NOPROGRESSUI = 0x00000001, // No progress tracking window during the emptying of the recycle bin
        SHERB_NOSOUND = 0x00000004 // No sound whent the emptying of the recycle bin is complete
    }
    public partial class Cleaner : Form
    {
        [DllImport("Shell32.dll")]
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);

        public Cleaner()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            desktop.Checked = true;


            recycle.Checked = true;

            systemp.Checked = true;
            loctemp.Checked = true;

            ThreeD.Checked = true;

            document.Checked = true;
            download.Checked = true;
            Music.Checked = true;
            pictures.Checked = true;
            videos.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            failedTestWorker = new BackgroundWorker();
            failedTestWorker.DoWork += (obj, ea) => CheckValuesAndClean();
            failedTestWorker.RunWorkerAsync();
        }

        private BackgroundWorker failedTestWorker;

        private void CheckValuesAndClean()
        {
            var user = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetTempPath()).FullName).FullName).FullName);
            Invoke(new Action(() => { button1.Text = "Please wait.."; }));
            Invoke(new Action(() => { button1.Enabled = false; }));
            if (systemp.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {systemp.Text}.."; }));
                Clean(@"C:\Windows\Temp");
            }
            if (loctemp.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {loctemp.Text}.."; }));
                Clean(Path.GetTempPath());
            }
            if (ThreeD.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {ThreeD.Text}.."; }));
                Clean($@"{user}\3D Objects");
            }
            if (desktop.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {desktop.Text}.."; }));
                Clean($@"{user}\Desktop");
                
            }
            if (document.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {document.Text}.."; }));
                Clean($@"{user}\Documents");
            }
            if (download.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {download.Text}.."; }));
                Clean(Path.Combine($@"{user}\Downloads"));
            }
            if (Music.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {Music.Text}.."; }));
                Clean($@"{user}\Music");
            }
            if (pictures.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {pictures.Text}.."; }));
                Clean($@"{user}\Pictures");
            }
            if (videos.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {videos.Text}.."; }));
                Clean($@"{user}\Videos");
            }
            if (recycle.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {recycle.Text}.."; }));
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
            }
            Invoke(new Action(() => { button1.Text = "Clean"; }));
            Invoke(new Action(() => { button1.Enabled = true; }));
            Invoke(new Action(() => { label1.Text = string.Empty; }));
            MessageBox.Show("Finished Cleaning");
        }
        private void Clean(string path)
        {
            var command = $"Remove-Item -Recurse -Force \"{path}\\*\"";
            ExecuteCommandWithAdminPowerShell(command);


        }

        public static void ExecuteCommandWithAdminPowerShell(string command)
        {
            var psFile = Path.Combine(Environment.CurrentDirectory, "Powershell.ps1");
            if (File.Exists(psFile))
            {
                File.Delete(psFile);
            }
            File.WriteAllText(psFile, command);
            var process = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy unrestricted -file \"{psFile}\"",
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas",
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
            if (File.Exists(psFile))
            {
                File.Delete(psFile);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            recycle.Checked = false;
            desktop.Checked = false;
            systemp.Checked = false;
            loctemp.Checked = false;

            ThreeD.Checked = false;

            document.Checked = false;
            download.Checked = false;
            Music.Checked = false;
            pictures.Checked = false;
            videos.Checked = false;
        }

        private void checkAllButton_Click(object sender, EventArgs e)
        {
            recycle.Checked = true;
            desktop.Checked = true;
            systemp.Checked = true;
            loctemp.Checked = true;

            ThreeD.Checked = true;

            document.Checked = true;
            download.Checked = true;
            Music.Checked = true;
            pictures.Checked = true;
            videos.Checked = true;
        }
    }
}


