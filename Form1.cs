using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

// Last Modified: Saturday, July 19, 2025, 12:18:36 AM GMT+2

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
                
                if (File.Exists("iconlaunchh.ico"))
                {
                    this.Icon = new Icon("iconlaunchh.ico");
                }
                else
                {
                    MessageBox.Show("Icon file not found. Please ensure iconlaunchh.ico exists in the application directory. Using Fallback icon...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Icon = SystemIcons.Application;
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

        private void button19_Click(object sender, EventArgs e)
        {
            Process.Start("\\Stardew Valley - 668MB\\Stardew Valley.exe");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Process.Start("\\Stray - 6.21GB\\Stray.exe");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Process.Start("\\Teardown - 8.72GB\\teardown.exe");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Process.Start("\\ULTRAKILL - 2.59GB\\ULTRAKILL.exe");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Process.Start("\\Undertale - 157MB\\Undertale.exe");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button25_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/kosmos90/Cracked-Games-Launcher/releases",
                UseShellExecute = true
            });
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/kosmos90/Cracked-Games-Launcher",
                UseShellExecute = true
            });
        }
    }
}
