using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Management;
using System.Diagnostics;


namespace Diag
{
    public partial class Form1 : Form
    {
		List<VideoCardInfo> videoCards = new List<VideoCardInfo>();
		List<MemoryInfo> ramSticks = new List<MemoryInfo>();

        PerformanceCounter cpuCounter = new PerformanceCounter();

        bool running = true;

        /* CONSTRUCTOR */
        public Form1()
        {
            InitializeComponent();

            // Processor //
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

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
			int i = 0;
			foreach (ManagementObject obj in searcher.Get())
			{
				memorySelectionBox.Items.Add("#" + i++.ToString());

				totalSize += (ulong)obj["Capacity"];

				MemoryInfo stick;
				stick.bank = obj["BankLabel"].ToString();

				stick.size = (ulong)obj["Capacity"]/1024/1024;
				stick.speed = (uint)obj["Speed"];
				stick.partNumber = obj["PartNumber"].ToString();
				stick.serialNumber = obj["SerialNumber"].ToString();

				ramSticks.Add(stick);
				
			}
			memorySelectionBox.SelectedIndex = 0;
			totalSize = totalSize/1024/1024;
			this.memoryTotalSizeBox.Text = totalSize.ToString() + " MB";

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

					DateTime installDate = ManagementDateTimeConverter.ToDateTime(obj["InstallDate"].ToString());
					DateTime bootTime = ManagementDateTimeConverter.ToDateTime(obj["LastBootUpTime"].ToString());

					osInstallBox.Text = installDate.GetDateTimeFormats()[2];
					osBootBox.Text = bootTime.GetDateTimeFormats()[4];

					string ver = obj["Version"].ToString().Substring(0, 3);

					if (ver == "5.1" || ver == "5.2") systemLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.WinXP;
					else if (ver == "6.0") systemLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.WinVista;
					else if (ver == "6.1") systemLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.Win7;
					else if (ver == "6.2") systemLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.Win8;
					
				}
			}

            getCPUUsage();
        }

        private void getCPUUsage()
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(delegate()
                {
                    try
                    {
                        while (running)
                        {
                            this.Invoke(new System.Windows.Forms.MethodInvoker(delegate()
                            {
                                cpuUsageBox.Text = Math.Round(cpuCounter.NextValue()) + "%";
                            }));
                            Thread.Sleep(1000);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }));

                thread.Priority = ThreadPriority.Normal;
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {

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

		private void memorySelectionBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			memoryBankBox.Text = ramSticks[memorySelectionBox.SelectedIndex].bank;

			memoryModuleSizeBox.Text = ramSticks[memorySelectionBox.SelectedIndex].size.ToString() + " MB";
			memoryFrequencyBox.Text = ramSticks[memorySelectionBox.SelectedIndex].speed.ToString() + " MHz";

			memoryPartBox.Text = ramSticks[memorySelectionBox.SelectedIndex].partNumber;
			memorySerialBox.Text = ramSticks[memorySelectionBox.SelectedIndex].serialNumber;
		}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
        }
    }

    struct VideoCardInfo
    {
        public string width, height;
		public string memory;
		public string driverVersion;
        
    }

	struct MemoryInfo
	{
		public string bank;

		public ulong size;
		public uint speed;
		public string partNumber;
		public string serialNumber;
	}
}
