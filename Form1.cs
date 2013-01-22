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
                this.processorName.Text = getValue(obj, "Name");
                this.cores.Text = getValue(obj, "NumberOfCores");
                this.threads.Text = getValue(obj, "NumberOfLogicalProcessors");
                
            }

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
                VideoCardDropDownBox.Items.Add(obj["Name"]);
                foreach (PropertyData data in obj.Properties)
                {

//	          		if (data.Name == "CurrentHorizontalResolution") w = (uint)(data.Value);
//    				if (data.Name == "CurrentVerticalResolution") h = (uint)data.Value;
//					if (data.Name == "CurrentRefreshRate") r = (uint)data.Value;
                }
            }
			resolutionBox.Text = w.ToString() + " x " + h.ToString() + " @ " + r.ToString() + "Hz";
            VideoCardDropDownBox.SelectedIndex = 0;
        }

        private string getValue(ManagementObject obj, string str)
        {
            if (obj[str] != null)
                return obj[str].ToString();
            else
                return "Brak informacyji";
        }
    }
}
