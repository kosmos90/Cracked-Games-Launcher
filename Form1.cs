using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void RunAppAsAdmin()
        {
            if (!IsRunningAsAdmin())
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = Application.ExecutablePath,
                    UseShellExecute = true,
                    Verb = "runas"
                };
                try
                {
                    Process.Start(processInfo);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to restart as administrator: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsRunningAsAdmin()
        {
            using (var identity = System.Security.Principal.WindowsIdentity.GetCurrent())
            {
                var principal = new System.Security.Principal.WindowsPrincipal(identity);
                return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RunAppAsAdmin();
            try
            {
                const string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\AppModelUnlock";
                const string registryKey = "AllowDevelopmentWithoutDevLicense";
                const int registryValueOn = 1;

                using (var key = Registry.LocalMachine.OpenSubKey(registryPath, true))
                {
                    int? currentValue = key?.GetValue(registryKey) as int?;
                    if (currentValue != registryValueOn)
                    {
                        Registry.SetValue(
                            @"HKEY_LOCAL_MACHINE\" + registryPath,
                            registryKey,
                            registryValueOn,
                            RegistryValueKind.DWord
                        );
                    }
                }
                {
                    MessageBox.Show("GDK_Helper.bat not found in Among Us directory. Please ensure it exists in the specified directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (File.Exists("iconlaunchh.ico"))
                {
                    this.Icon = new Icon("iconlaunchh.ico");
                }
                else
                {
                    MessageBox.Show("Icon file not found. Please ensure iconlaunchh.ico exists in the application directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to set registry value: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (File.Exists("iconlaunchh.ico"))
            {
                this.Icon = new Icon("iconlaunchh.ico");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"Among Us - 890MB\Among Us.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("\\Buckshot Roulette - 772MB\\Buckshot Roulette.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("\\Celeste - 2.50GB\\Celeste.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("\\Cities - Skylines - 18.2GB\\Cities.exe");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("\\Contraband Police - 13.8GB\\ContrabandPolice.exe");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("\\Cuphead - 5.39GB\\Cuphead.exe");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("\\Fears to Fathom - Carson House - 5.60GB\\Fears To Fathom - Carson House.exe");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("\\Fears to Fathom Ironbark Lookout - 3.28GB\\Fears to Fathom - Ironbark Lookout.exe");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("\\Garrys Mod - 3.86GB\\gmod.exe");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Process.Start("\\Grand Theft Auto IV - The Complete Edition - 30GB\\GTAIV.exe");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Process.Start("\\GTA - The Trilogy - DE - 31.8GB\\Launcher.exe");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Process.Start("\\Need for Speed - Most Wanted - 6.25GB\\nfs13.exe");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Process.Start("\\Planet Coaster - 9.00GB\\PlanetCoaster.exe");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Process.Start("\\Red Dead Redemption - 9.90GB\\PlayRDR.exe");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Process.Start("\\Redist - 46.1MB");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "steam://",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to launch Steam: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Process.Start("\\REPO - 1.09GB\\REPO.exe");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Process.Start("\\Spider-Man 3 - 5.61GB\\Spider-Man 3.exe");
        }
    }
}
