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
        public Form1()
        {
            InitializeComponent();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

            foreach (ManagementObject obj in searcher.Get())
            {
                foreach (PropertyData data in obj.Properties)
                {
                    if (data.Name == "Name") this.processorName.Text = data.Value.ToString();
                    if (data.Name == "NumberOfCores") this.cores.Text = data.Value.ToString();
                    if (data.Name == "NumberOfLogicalProcessors") this.threads.Text = data.Value.ToString();
                }
            }

            searcher.Query = new ObjectQuery("SELECT * FROM Win32_CacheMemory");
            foreach (ManagementObject obj in searcher.Get())
            {
                string size = "";
                foreach (PropertyData data in obj.Properties)
                {
                    if (data.Name == "InstalledSize") size = data.Value.ToString() + " kB";
                    if (data.Name == "Purpose")
                    {
                        switch (data.Value.ToString())
                        {
                            case "L1-Cache":
                                cache1Box.Text = size;
                            break;

                            case "L2-Cache":
                                cache2Box.Text = size;
                            break;

                            case "L3-Cache":
                                cache3Box.Text = size;
                            break;
                        }
                    }
                }
            }

			searcher.Query = new ObjectQuery("SELECT * FROM Win32_BaseBoard");
			foreach (ManagementObject obj in searcher.Get())
			{
				foreach (PropertyData data in obj.Properties)
				{
					if (data.Name == "Manufacturer") this.moboManuBox.Text = data.Value.ToString();
					if (data.Name == "Product") this.moboModelBox.Text = data.Value.ToString();
				}
			}

			searcher.Query = new ObjectQuery("SELECT * FROM Win32_BIOS");
			foreach (ManagementObject obj in searcher.Get())
			{
				foreach (PropertyData data in obj.Properties)
				{
					if (data.Name == "Manufacturer") this.biosManuBox.Text = data.Value.ToString();
					if (data.Name == "SMBIOSBIOSVersion") this.biosVerBox.Text = data.Value.ToString();
				}
			}

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


            searcher.Query = new ObjectQuery("SELECT * FROM Win32_VideoController");
			uint w = 0, h = 0, r = 0;
            foreach (ManagementObject obj in searcher.Get())
            {
                foreach (PropertyData data in obj.Properties)
                {
                    if (data.Name == "Name") this.videoCardName.Text = data.Value.ToString();

					if (data.Name == "CurrentHorizontalResolution") w = (uint)data.Value;
					if (data.Name == "CurrentVerticalResolution") h = (uint)data.Value;
					if (data.Name == "CurrentRefreshRate") r = (uint)data.Value;
                }
            }
			resolutionBox.Text = w.ToString() + " x " + h.ToString() + " @ " + r.ToString() + "Hz";
        }

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
    }
}
