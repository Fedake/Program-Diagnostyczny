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

            searcher.Query = new ObjectQuery("SELECT * FROM Win32_VideoController");
            foreach (ManagementObject obj in searcher.Get())
            {
                foreach (PropertyData data in obj.Properties)
                {
                    if (data.Name == "Name") this.videoCardName.Text = data.Value.ToString();
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
        }
    }
}
