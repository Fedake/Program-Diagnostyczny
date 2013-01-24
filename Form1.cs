using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Management;


namespace Diag
{
    public partial class Form1 : Form
    {
        List<VideoCardInfo> videoCards = new List<VideoCardInfo>();

        /* CONSTRUCTOR */
        public Form1()
        {
            InitializeComponent();

            // Processor //
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
        
            foreach (ManagementObject obj in searcher.Get())
            {
                this.processorName.Text = getValue(obj, "Name");
                this.cores.Text = getValue(obj, "NumberOfCores");
                this.threads.Text = getValue(obj, "NumberOfLogicalProcessors");
                
            }

            // Cache memory //
            searcher.Query = new ObjectQuery("SELECT * FROM Win32_CacheMemory");
            foreach (ManagementObject obj in searcher.Get())
            {
                string size = "";
                size = obj["InstalledSize"].ToString() + " kB";

                switch (obj["Level"].ToString())
                {
                    case "3":
                        cache1Box.Text = size;
                    break;

                    case "4":
                        cache2Box.Text = size;
                    break;

                    case "5":
                        cache3Box.Text = size;
                    break;
                }
            }

            // Motherboard //
			searcher.Query = new ObjectQuery("SELECT * FROM Win32_BaseBoard");
			foreach (ManagementObject obj in searcher.Get())
			{
				foreach (PropertyData data in obj.Properties)
				{
					if (data.Name == "Manufacturer") this.moboManuBox.Text = data.Value.ToString();
					if (data.Name == "Product") this.moboModelBox.Text = data.Value.ToString();
				}
			}

            // BIOS //
			searcher.Query = new ObjectQuery("SELECT * FROM Win32_BIOS");
			foreach (ManagementObject obj in searcher.Get())
			{
				foreach (PropertyData data in obj.Properties)
				{
					if (data.Name == "Manufacturer") this.biosManuBox.Text = data.Value.ToString();
					if (data.Name == "SMBIOSBIOSVersion") this.biosVerBox.Text = data.Value.ToString();
				}
			}

            // Physical Memory //
			searcher.Query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");

			ulong totalSize = 0;
			foreach (ManagementObject obj in searcher.Get())
			{
				foreach (PropertyData data in obj.Properties)
				{
					if (data.Name == "Capacity") totalSize += (ulong)data.Value;
				}
			}
			totalSize = totalSize/1024/1024;
			this.memorySizeBox.Text = totalSize.ToString() + " MB";

            // Video Controller //
            searcher.Query = new ObjectQuery("SELECT * FROM Win32_VideoController");
            foreach (ManagementObject obj in searcher.Get())
            {
                VideoCardDropDownBox.Items.Add(obj["Name"]);

                VideoCardInfo info;
                info.width = getValue(obj, "CurrentHorizontalResolution");
                info.height = getValue(obj, "CurrentVerticalResolution");

				info.memory = (Convert.ToUInt64(getValue(obj, "AdapterRAM"))/1024/1024).ToString();

				info.driverVersion = getValue(obj, "DriverVersion");

                videoCards.Add(info);
            }
            VideoCardDropDownBox.SelectedIndex = 0;

			// System //
			searcher.Query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
			foreach (ManagementObject obj in searcher.Get())
			{
				if ((bool)obj["Primary"] == true)
				{
					osVersionBox.Text = getValue(obj, "Caption");
					osArchitectureBox.Text = getValue(obj, "OSArchitecture");
					osBuildBox.Text = getValue(obj, "BuildNumber");

					
				}
			}
        }

        // Get value of object property
        private string getValue(ManagementObject obj, string str)
        {
            if (obj[str] != null)
                return obj[str].ToString();
            else
                return "NULL";
        }

        private void VideoCardDropDownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string width = videoCards[VideoCardDropDownBox.SelectedIndex].width;
            string height = videoCards[VideoCardDropDownBox.SelectedIndex].height;
			string memory = videoCards[VideoCardDropDownBox.SelectedIndex].memory;
			string driver = videoCards[VideoCardDropDownBox.SelectedIndex].driverVersion;

            if (width == "NULL" || height == "NULL")
            {
                resolutionBox.Enabled = false;
                resolutionLabel.Enabled = false;
                resolutionBox.Text = "No information available";
            }
            else
            {
                resolutionBox.Enabled = true;
                resolutionLabel.Enabled = true;
                resolutionBox.Text = width + " x " + height;
            }

			videoCardRamBox.Text = memory + " MB";
			videoCardDriverBox.Text = driver;
        }

        private void threads_TextChanged(object sender, EventArgs e)
        {

        }
    }

    struct VideoCardInfo
    {
        public string width, height;
		public string memory;
		public string driverVersion;
        
    }
}
