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
        List<DiskInfo> disks = new List<DiskInfo>();


        Screen[] screens = Screen.AllScreens;

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
                cpuUsageChart.Series[0].ChartType = SeriesChartType.SplineArea;

                series.Points.Add(0);
                for (int klm = 0; klm < 20; ++klm)
                {
                    cpuUsageChart.Series[0].Points.Add(0);
                }

                cpuUsageChart.Series[0].YAxisType = AxisType.Primary;
                cpuUsageChart.Series[0].YValueType = ChartValueType.Int32;
                cpuUsageChart.Series[0].IsXValueIndexed = false;
                cpuUsageChart.Series[0].Color = Color.FromArgb(180, 255, 0, 0);
                

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
                    setValue(processorNameLabel, processorNameBox, getValue(obj, "Name"));
                    setValue(coresLabel, coresBox, getValue(obj, "NumberOfCores"));
                    setValue(threadsLabel, threadsBox, getValue(obj, "NumberOfLogicalProcessors"));

                    if (getValue(obj, "Manufacturer").IndexOf("Intel") != -1) processorLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.Intel;
                    else if (getValue(obj, "Manufacturer").IndexOf("AMD") != -1) processorLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.AMD;


                }

                // Cache memory //
                searcher.Query = new ObjectQuery("SELECT * FROM Win32_CacheMemory");
                foreach (ManagementObject obj in searcher.Get())
                {
                    string size = "";
                    size = getValue(obj, "InstalledSize");

                    switch (getValue(obj, "Level"))
                    {
                        case "3":
                            setValue(cache1Label, cache1Box, size, null, null, " kB");
                            break;

                        case "4":
                            setValue(cache2Label, cache2Box, size, null, null, " kB");
                            break;

                        case "5":
                            setValue(cache3Label, cache3Box, size, null, null, " kB");
                            break;
                    }
                }

                // Motherboard //
                searcher.Query = new ObjectQuery("SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject obj in searcher.Get())
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          {
                    setValue(moboManuLabel, moboManuBox, getValue(obj, "Manufacturer"));
                    setValue(moboModelLabel, moboModelBox, getValue(obj, "Product"));
                    setValue(moboSerialLabel, moboSerialTextBox, getValue(obj, "SerialNumber"));
                }

                // BIOS //
                searcher.Query = new ObjectQuery("SELECT * FROM Win32_BIOS");
                foreach (ManagementObject obj in searcher.Get())
                {
                    setValue(biosManuLabel, biosManuBox, getValue(obj, "Manufacturer"));
                    setValue(biosVerLabel, biosVerBox, getValue(obj, "SMBIOSBIOSVersion"));
                    setValue(biosSerialLabel, biosSerialTextBox, getValue(obj, "SerialNumber"));
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

                // Disk Storage //
                searcher.Query = new ObjectQuery("SELECT * FROM Win32_DiskDrive");
                
                i = 1;
                ulong diskSize;
                foreach (ManagementObject obj in searcher.Get())
                {
                    diskSize = 0;
                    diskSelectionBox.Items.Add("Disk " + i++.ToString());

                    diskSize += ulong.Parse(getValue(obj, "Size"));
                    string model = getValue(obj, "Model");
                    string partitions = getValue(obj, "Partitions");
                    string bps = getValue(obj, "BytesPerSector");

                    DiskInfo disk;

                    disk.size = (diskSize / 1000 / 1000 / 1000).ToString();
                    disk.model = model;
                    disk.partitions = partitions;
                    disk.bps = bps;

                    disks.Add(disk);
                }
                diskSelectionBox.SelectedIndex = 0;

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

                // Monitors //
                int ile = 1;
                foreach (Screen screen in screens)
                {
                    monitorDropDownBox.Items.Add("Monitor " + ile);
                    ++ile;
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
                            bool is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));

                            if (is64bit)
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
                MessageBox.Show("An exception occured. Program may not work properly.\nException content will be saved to file: log.txt");
                System.IO.File.WriteAllText(".\\log.txt", ex.ToString() + "\n" + ex.Message.ToString());
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
                        MessageBox.Show("An exception occured. Program may not work properly.\nException content will be saved to file: log.txt");
                        System.IO.File.WriteAllText(".\\log.txt", ex.ToString() + "\n" + ex.Message.ToString());
                    }
                }));

                thread.Priority = ThreadPriority.Normal;
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception occured. Program may not work properly.\nException content will be saved to file: log.txt");
                System.IO.File.WriteAllText(".\\log.txt", ex.ToString() + "\n" + ex.Message.ToString());
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

        // Check if property is available and set it
        private void setValue(Label label, TextBox textbox, string text, string between = null, string text2 = null, 
                                string additional = null)
        {
            if (text == "0" || text2 == "0")
            {
                label.Enabled = false;
                textbox.Enabled = false;
                textbox.Text = "Not available";
            }
            else
            {
                label.Enabled = true;
                textbox.Enabled = true;
                textbox.Text = text + between + text2 + additional;
            }
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

            setValue(resolutionLabel, resolutionBox, width, " x ", height);
            setValue(videoCardRamLabel, videoCardRamBox, memory, " MB");
            setValue(videoCardDriverLabel, videoCardDriverBox, driver);

            if (processor.IndexOf("Intel") != -1) 
                videoCardLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.IntelGraphics;
            else if (processor.IndexOf("GeForce") != -1)
				videoCardLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.GeForce;
			else if (processor.IndexOf("Radeon") != -1) 
                videoCardLogoBox.Image = ProgramDiagnostyczny.Properties.Resources.Radeon;
            else
                videoCardLogoBox.Image = null;
        }

		private void memorySelectionBox_SelectedIndexChanged(object sender, EventArgs e)
		{
            string bank = ramSticks[memorySelectionBox.SelectedIndex].bank;
            string size = ramSticks[memorySelectionBox.SelectedIndex].size.ToString();
            string speed = ramSticks[memorySelectionBox.SelectedIndex].speed.ToString();
            string part = ramSticks[memorySelectionBox.SelectedIndex].partNumber;
            string serial = ramSticks[memorySelectionBox.SelectedIndex].serialNumber;

            setValue(memoryBankLabel, memoryBankBox, bank);
            setValue(memoryModuleSizeLabel, memoryModuleSizeBox, size, " MB");
            setValue(memoryFreqencyLabel, memoryFrequencyBox, speed, " MHz");
            setValue(memoryPartLabel, memoryPartBox, part);
            setValue(memorySerialLabel, memorySerialBox, serial);
		}

        private void monitorDropDownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string width = screens[monitorDropDownBox.SelectedIndex].WorkingArea.Width.ToString();
            string height = screens[monitorDropDownBox.SelectedIndex].WorkingArea.Height.ToString();
            string bpp = screens[monitorDropDownBox.SelectedIndex].BitsPerPixel.ToString();
            string primary = screens[monitorDropDownBox.SelectedIndex].Primary.ToString();
            
            setValue(monitorBppLabel, monitorIdTextBox, bpp);
            setValue(monitorResolutionLabel, monitorResolutionTextBox, width, " x ", height);
            setValue(monitorPrimaryLabel, monitorPrimaryBox, primary);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
        }

        private void diskSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string size = disks[diskSelectionBox.SelectedIndex].size;
            string model = disks[diskSelectionBox.SelectedIndex].model;
            string partitions = disks[diskSelectionBox.SelectedIndex].partitions;
            string bps = disks[diskSelectionBox.SelectedIndex].bps;


            setValue(diskSizeLabel, diskSizeBox, size, null, null, " GB");
            setValue(diskModelLabel, diskModelBox, model);
            setValue(diskPartitionsLabel, diskPartitionsBox, partitions);
            setValue(diskBpsLabel, diskBpsBox, bps);
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

    struct DiskInfo
    {
        public string model;
        public string size;
        public string partitions;
        public string bps;
    }
}
