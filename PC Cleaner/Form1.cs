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
using Microsoft.Office.Interop.Excel;
using Action = System.Action;
using Application = Microsoft.Office.Interop.Excel.Application;


namespace Build
{
    enum RecycleFlag : int
    {
        SHERB_NOCONFIRMATION = 0x00000001, // No confirmation, when emptying 
        SHERB_NOPROGRESSUI = 0x00000001, // No progress tracking window during the emptying of the recycle bin
        SHERB_NOSOUND = 0x00000004 // No sound whent the emptying of the recycle bin is complete
    }
    public partial class Form1 : Form
    {
        [DllImport("Shell32.dll")]
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            desktop.Checked = true;

            pem.Checked = true;

            recycle.Checked = true;

            systemp.Checked = true;
            loctemp.Checked = true;
            removeDll.Checked = true;
            comtemp.Checked = true;

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
            if (comtemp.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {comtemp.Text}.."; }));
                Clean("C:\\Temp");
            }
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
            if (removeDll.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {removeDll.Text}.."; }));
                Clean("C:\\SVN\\ComTests\\Develop\\ComTests\\bin");
            }
            if (recycle.Checked)
            {
                Invoke(new Action(() => { label1.Text = $"Cleaning {recycle.Text}.."; }));
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
            }
            if (pem.Checked)
            {
                var path = $@"{user}\Documents";
                var assembly = Assembly.GetExecutingAssembly();
                var reader = assembly.GetManifestResourceStream("Build.Files.letsencrypt-f1wall-dd.ipetronik.com.pem");
                var file = Path.Combine(path, "letsencrypt-f1wall-dd.ipetronik.com.pem");
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                using (Stream s = File.Create(file))
                {
                    reader.CopyTo(s);
                }
                var reader02 = assembly.GetManifestResourceStream("Build.Files.letsencrypt-f1wall.ipetronik.com.pem");
                var file02 = Path.Combine(path, "letsencrypt-f1wall.ipetronik.com.pem");
                if (File.Exists(file02))
                {
                    File.Delete(file02);
                }
                using (Stream s = File.Create(file02))
                {
                    reader02.CopyTo(s);
                }
                Invoke(new Action(() => { label1.Text = "Copying PEM Files To Documents.."; }));
                
            }
            Invoke(new Action(() => { button1.Text = "Clean"; }));
            Invoke(new Action(() => { button1.Enabled = true; }));
            Invoke(new Action(() => { label1.Text = string.Empty; }));
            MessageBox.Show("Clean Finished!");
        }
        private void Clean(string path)
        {
            /*if (CultureInfo.CurrentCulture.ToString().Equals("de-DE"))
            {
                path = path.Replace("Users","Benutzer");
            }*/
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
            pem.Checked = false;

            recycle.Checked = false;
            desktop.Checked = false;
            systemp.Checked = false;
            loctemp.Checked = false;
            removeDll.Checked = false;
            comtemp.Checked = false;

            ThreeD.Checked = false;

            document.Checked = false;
            download.Checked = false;
            Music.Checked = false;
            pictures.Checked = false;
            videos.Checked = false;
        }
    }
}


