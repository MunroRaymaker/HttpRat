using System;
using System.Management;
using System.Net;

namespace Client
{
    public static class EnvironmentHelper
    {
        public static string GetMacAddress()
        {
            string mac = string.Empty;
            string query = "SELECT MacAddress FROM Win32_NetworkAdapter";
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);
            ManagementObjectCollection coll = search.Get();
            foreach (var obj in coll)
            {
                if (obj["MacAddress"] != null)
                {
                    mac += obj["MacAddress"].ToString();
                }
            }

            return mac;
        }
        public static string GetRamSerial()
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

        public static string GetWanIp()
        {
            string ip;

            using (var wc = new WebClient())
            {
                ip = wc.DownloadString("https://api.ipify.org");
            }

            return ip;
        }
        
        public static string GetOs()
        {
            return Environment.OSVersion.ToString();
        }

        public static string GetHostName()
        {
            return Environment.MachineName + " - " + Environment.UserName;
        }
    }
}
