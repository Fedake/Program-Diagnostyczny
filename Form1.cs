using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using System.Management;
using System.Diagnostics;


namespace Diag
{
    public partial class Form1 : Form
    {
		List<VideoCardInfo> videoCards = new List<VideoCardInfo>();
		List<MemoryInfo> ramSticks = new List<MemoryInfo>();
        List<MonitorInfo> monitorsList = new List<MonitorInfo>();

        Screen[] monitors = Screen.AllScreens;

        PerformanceCounter cpuCounter = new PerformanceCounter();

        bool running = true;

        DateTime m_bootTime;

        /* CONSTRUCTOR */
        public Form1()
        {
            try
            {
                InitializeComponent();

                // Processor //
                string seriesStr = "CPU Usage";

                this.cpuUsageChart.Palette = ChartColorPalette.SeaGreen;
                this.cpuUsageChart.Titles.Add("CPU Usage");

                this.cpuUsageChart.Series.Clear();
                Series series = this.cpuUsageChart.Series.Add(seriesStr);
                cpuUsageChart.Series[0].ChartType = SeriesChartType.Line;

                series.Points.Add(0);

                cpuUsageChart.Series[0].YAxisType = AxisType.Primary;
                cpuUsageChart.Series[0].YValueType = ChartValueType.Int32;
                cpuUsageChart.Series[0].IsXValueIndexed = false;
                cpuUsageChart.Series[0].Color = Color.Red;

                cpuUsageChart.ResetAutoValues();
                cpuUsageChart.ChartAreas[0].AxisY.Maximum = 100;//Max Y 
                cpuUsageChart.ChartAreas[0].AxisY.Minimum = 0;
                cpuUsageChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;


                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";

                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

                foreach (ManagementObject obj in searcher.Get())
                {
                    this.processorName.Text = getValue(obj, "Name");
                    this.cores.Text = getValue(obj, "NumberOfCores");
                    this.threads.Text = getValue(obj, "NumberOfLogicalProcessors");

                    if (getValue(obj, "Manufacturer").IndexOf("Intel") != -1) processorLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.Intel;
                    else if (getValue(obj, "Manufacturer").IndexOf("AMD") != -1) processorLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.AMD;


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
                        if (data.Name == "SerialNumber") this.moboSerialTextBox.Text = data.Value.ToString();
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
                        if (data.Name == "SerialNumber") this.biosSerialTextBox.Text = data.Value.ToString();
                    }
                }

                // Physical Memory //
                searcher.Query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");

                ulong totalSize = 0;
                int i = 0;
                foreach (ManagementObject obj in searcher.Get())
                {
                    memorySelectionBox.Items.Add("#" + i++.ToString());

                    totalSize += ulong.Parse(getValue(obj, "Capacity"));

                    MemoryInfo stick;
                    stick.bank = getValue(obj, "BankLabel");

                    stick.size = ulong.Parse(getValue(obj, "Capacity")) / 1024 / 1024;
                    stick.speed = uint.Parse(getValue(obj, "Speed"));
                    stick.partNumber = getValue(obj, "PartNumber");
                    stick.serialNumber = getValue(obj, "SerialNumber");

                    ramSticks.Add(stick);

                }
                memorySelectionBox.SelectedIndex = 0;
                totalSize = totalSize / 1024 / 1024;
                this.memoryTotalSizeBox.Text = totalSize.ToString() + " MB";

                // Video Controller //
                searcher.Query = new ObjectQuery("SELECT * FROM Win32_VideoController");
                foreach (ManagementObject obj in searcher.Get())
                {
                    VideoCardDropDownBox.Items.Add(getValue(obj, "Name"));

                    VideoCardInfo info;
                    info.width = getValue(obj, "CurrentHorizontalResolution");
                    info.height = getValue(obj, "CurrentVerticalResolution");

                    info.memory = (ulong.Parse(getValue(obj, "AdapterRAM")) / 1024 / 1024).ToString();

                    info.driverVersion = getValue(obj, "DriverVersion");

                    info.processor = getValue(obj, "VideoProcessor");

                    videoCards.Add(info);
                }
                VideoCardDropDownBox.SelectedIndex = 0;

                searcher.Query = new ObjectQuery("SELECT * FROM Win32_DesktopMonitor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    monitorDropDownBox.Items.Add(getValue(obj, "Name"));

                    MonitorInfo info;
                    info.id = getValue(obj, "DeviceID");
                    info.width = getValue(obj, "ScreenWidth");
                    info.height = getValue(obj, "ScreenHeight");

                    monitorsList.Add(info);
                }
                monitorDropDownBox.SelectedIndex = 0;


                // System //
                searcher.Query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject obj in searcher.Get())
                {
                    if ((bool)obj["Primary"] == true)
                    {
                        osVersionBox.Text = getValue(obj, "Caption");
                        
                        osBuildBox.Text = getValue(obj, "BuildNumber");

                        DateTime installDate = ManagementDateTimeConverter.ToDateTime(obj["InstallDate"].ToString());
                        DateTime bootTime = ManagementDateTimeConverter.ToDateTime(obj["LastBootUpTime"].ToString());
                        m_bootTime = bootTime;
                        osInstallBox.Text = installDate.GetDateTimeFormats()[2];
                        osBootBox.Text = bootTime.GetDateTimeFormats()[4];

                        string ver = getValue(obj, "Version").Substring(0, 3);

                        if (ver == "5.1" || ver == "5.2")
                        {
                            bool is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));                            if (is64bit)
                                osArchitectureBox.Text = "64 bit";
                            else
                                osArchitectureBox.Text = "32 bit";

                            systemLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.WinXP;
                        }
                        else
                        {
                            osArchitectureBox.Text = getValue(obj, "OSArchitecture");
                            if (ver == "6.0") systemLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.WinVista;
                            else if (ver == "6.1") systemLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.Win7;
                            else if (ver == "6.2") systemLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.Win8;
                        }

                    }
                }

                update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n" + ex.Message.ToString());
            }
        }

        private void update()
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(delegate()
                {
                    try
                    {
                        while (running)
                        {
                            if (InvokeRequired)
                                this.Invoke(new System.Windows.Forms.MethodInvoker(delegate()
                                {
                                    updateCPUUsage();
                                    updateUpTime();
                                }));
                            else
                            {
                                updateCPUUsage();
                                updateUpTime();
                            }
                            Thread.Sleep(1000);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception while invoking in CPU Usage thread");
                    }
                }));

                thread.Priority = ThreadPriority.Normal;
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception while running CPU Usage thread");
            }
        }

        // Get value of object property
        private string getValue(ManagementObject obj, string str)
        {
            if (obj[str] != null)
                return obj[str].ToString();
            else
                return "0";
        }

        private void updateCPUUsage()
        {
            float usage = cpuCounter.NextValue();
            cpuUsageBox.Text = Math.Round(usage).ToString() + "%";
            cpuUsageChart.Series[0].Points.AddY(usage);
            
            if (cpuUsageChart.Series[0].Points.Count > 20)
                cpuUsageChart.Series[0].Points.RemoveAt(0);
        }

        private void updateUpTime()
        {
            TimeSpan interwał_czasowyxD = DateTime.Now - m_bootTime;
            osUpTimeTextBox.Text = (interwał_czasowyxD.Days*24 + interwał_czasowyxD.Hours).ToString() + "h " 
                + (interwał_czasowyxD.Minutes).ToString() + "m " + (interwał_czasowyxD.Seconds).ToString() + "s";
        }

        private void VideoCardDropDownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string width = videoCards[VideoCardDropDownBox.SelectedIndex].width;
            string height = videoCards[VideoCardDropDownBox.SelectedIndex].height;
			string memory = videoCards[VideoCardDropDownBox.SelectedIndex].memory;
			string driver = videoCards[VideoCardDropDownBox.SelectedIndex].driverVersion;
			string processor = videoCards[VideoCardDropDownBox.SelectedIndex].processor;

            if (width == "0" || height == "0")
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

            if (processor.IndexOf("Intel") != -1) videoCardLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.Intel;
			if (processor.IndexOf("GeForce") != -1) videoCardLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.GeForce;
			if (processor.IndexOf("Radeon") != -1) videoCardLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.Radeon;
        }

		private void memorySelectionBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			memoryBankBox.Text = ramSticks[memorySelectionBox.SelectedIndex].bank;

			memoryModuleSizeBox.Text = ramSticks[memorySelectionBox.SelectedIndex].size.ToString() + " MB";
			memoryFrequencyBox.Text = ramSticks[memorySelectionBox.SelectedIndex].speed.ToString() + " MHz";

			memoryPartBox.Text = ramSticks[memorySelectionBox.SelectedIndex].partNumber;
			memorySerialBox.Text = ramSticks[memorySelectionBox.SelectedIndex].serialNumber;
		}

        private void monitorDropDownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = monitorsList[monitorDropDownBox.SelectedIndex].id;
            string width = monitorsList[monitorDropDownBox.SelectedIndex].width;
            string height = monitorsList[monitorDropDownBox.SelectedIndex].height;
            

            monitorIdTextBox.Text = id;
            monitorResolutionTextBox.Text = width + " x " + height;
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
		public string processor;
    }

	struct MemoryInfo
	{
		public string bank;

		public ulong size;
		public uint speed;
		public string partNumber;
		public string serialNumber;
	}

    struct MonitorInfo
    {
        public string id;
        public string width;
        public string height;
    }
}
