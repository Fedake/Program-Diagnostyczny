namespace Diag
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.processorPage = new System.Windows.Forms.TabPage();
            this.cacheGroup = new System.Windows.Forms.GroupBox();
            this.cache3Box = new System.Windows.Forms.TextBox();
            this.cache2Box = new System.Windows.Forms.TextBox();
            this.cache1Label = new System.Windows.Forms.Label();
            this.cache2Label = new System.Windows.Forms.Label();
            this.cache1Box = new System.Windows.Forms.TextBox();
            this.cache3Label = new System.Windows.Forms.Label();
            this.processorGeneralGroup = new System.Windows.Forms.GroupBox();
            this.addressWidthLabel = new System.Windows.Forms.Label();
            this.coresLabel = new System.Windows.Forms.Label();
            this.cores = new System.Windows.Forms.TextBox();
            this.processorName = new System.Windows.Forms.TextBox();
            this.processorNameLabel = new System.Windows.Forms.Label();
            this.threads = new System.Windows.Forms.TextBox();
            this.threadsLabel = new System.Windows.Forms.Label();
            this.moboPage = new System.Windows.Forms.TabPage();
            this.moboBiosGroup = new System.Windows.Forms.GroupBox();
            this.biosVerBox = new System.Windows.Forms.TextBox();
            this.biosManuBox = new System.Windows.Forms.TextBox();
            this.biosManuLabel = new System.Windows.Forms.Label();
            this.biosVerLabel = new System.Windows.Forms.Label();
            this.moboGeneralGroup = new System.Windows.Forms.GroupBox();
            this.moboModelBox = new System.Windows.Forms.TextBox();
            this.moboManuBox = new System.Windows.Forms.TextBox();
            this.moboModelLabel = new System.Windows.Forms.Label();
            this.moboManuLabel = new System.Windows.Forms.Label();
            this.memoryPage = new System.Windows.Forms.TabPage();
            this.memoryGeneralGroup = new System.Windows.Forms.GroupBox();
            this.memorySizeBox = new System.Windows.Forms.TextBox();
            this.memorySizeLabel = new System.Windows.Forms.Label();
            this.videoPage = new System.Windows.Forms.TabPage();
            this.VideoCardDropDownBox = new System.Windows.Forms.ComboBox();
            this.VideoSelectLabel = new System.Windows.Forms.Label();
            this.videoGeneralGroup = new System.Windows.Forms.GroupBox();
            this.resolutionBox = new System.Windows.Forms.TextBox();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.addressWidthTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.processorPage.SuspendLayout();
            this.cacheGroup.SuspendLayout();
            this.processorGeneralGroup.SuspendLayout();
            this.moboPage.SuspendLayout();
            this.moboBiosGroup.SuspendLayout();
            this.moboGeneralGroup.SuspendLayout();
            this.memoryPage.SuspendLayout();
            this.memoryGeneralGroup.SuspendLayout();
            this.videoPage.SuspendLayout();
            this.videoGeneralGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.processorPage);
            this.tabControl1.Controls.Add(this.moboPage);
            this.tabControl1.Controls.Add(this.memoryPage);
            this.tabControl1.Controls.Add(this.videoPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(348, 319);
            this.tabControl1.TabIndex = 0;
            // 
            // processorPage
            // 
            this.processorPage.Controls.Add(this.cacheGroup);
            this.processorPage.Controls.Add(this.processorGeneralGroup);
            this.processorPage.Location = new System.Drawing.Point(4, 22);
            this.processorPage.Name = "processorPage";
            this.processorPage.Padding = new System.Windows.Forms.Padding(3);
            this.processorPage.Size = new System.Drawing.Size(340, 293);
            this.processorPage.TabIndex = 0;
            this.processorPage.Text = "Processor";
            this.processorPage.UseVisualStyleBackColor = true;
            // 
            // cacheGroup
            // 
            this.cacheGroup.Controls.Add(this.cache3Box);
            this.cacheGroup.Controls.Add(this.cache2Box);
            this.cacheGroup.Controls.Add(this.cache1Label);
            this.cacheGroup.Controls.Add(this.cache2Label);
            this.cacheGroup.Controls.Add(this.cache1Box);
            this.cacheGroup.Controls.Add(this.cache3Label);
            this.cacheGroup.Location = new System.Drawing.Point(3, 88);
            this.cacheGroup.Name = "cacheGroup";
            this.cacheGroup.Size = new System.Drawing.Size(166, 102);
            this.cacheGroup.TabIndex = 7;
            this.cacheGroup.TabStop = false;
            this.cacheGroup.Text = "Cache";
            // 
            // cache3Box
            // 
            this.cache3Box.Location = new System.Drawing.Point(54, 71);
            this.cache3Box.Name = "cache3Box";
            this.cache3Box.ReadOnly = true;
            this.cache3Box.Size = new System.Drawing.Size(93, 20);
            this.cache3Box.TabIndex = 5;
            this.cache3Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cache2Box
            // 
            this.cache2Box.Location = new System.Drawing.Point(54, 45);
            this.cache2Box.Name = "cache2Box";
            this.cache2Box.ReadOnly = true;
            this.cache2Box.Size = new System.Drawing.Size(93, 20);
            this.cache2Box.TabIndex = 4;
            this.cache2Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cache1Label
            // 
            this.cache1Label.AutoSize = true;
            this.cache1Label.Location = new System.Drawing.Point(6, 22);
            this.cache1Label.Name = "cache1Label";
            this.cache1Label.Size = new System.Drawing.Size(42, 13);
            this.cache1Label.TabIndex = 0;
            this.cache1Label.Text = "Level 1";
            // 
            // cache2Label
            // 
            this.cache2Label.AutoSize = true;
            this.cache2Label.Location = new System.Drawing.Point(6, 48);
            this.cache2Label.Name = "cache2Label";
            this.cache2Label.Size = new System.Drawing.Size(42, 13);
            this.cache2Label.TabIndex = 1;
            this.cache2Label.Text = "Level 2";
            // 
            // cache1Box
            // 
            this.cache1Box.Location = new System.Drawing.Point(54, 19);
            this.cache1Box.Name = "cache1Box";
            this.cache1Box.ReadOnly = true;
            this.cache1Box.Size = new System.Drawing.Size(93, 20);
            this.cache1Box.TabIndex = 3;
            this.cache1Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cache3Label
            // 
            this.cache3Label.AutoSize = true;
            this.cache3Label.Location = new System.Drawing.Point(6, 74);
            this.cache3Label.Name = "cache3Label";
            this.cache3Label.Size = new System.Drawing.Size(42, 13);
            this.cache3Label.TabIndex = 2;
            this.cache3Label.Text = "Level 3";
            // 
            // processorGeneralGroup
            // 
            this.processorGeneralGroup.Controls.Add(this.addressWidthTextBox);
            this.processorGeneralGroup.Controls.Add(this.addressWidthLabel);
            this.processorGeneralGroup.Controls.Add(this.coresLabel);
            this.processorGeneralGroup.Controls.Add(this.cores);
            this.processorGeneralGroup.Controls.Add(this.processorName);
            this.processorGeneralGroup.Controls.Add(this.processorNameLabel);
            this.processorGeneralGroup.Controls.Add(this.threads);
            this.processorGeneralGroup.Controls.Add(this.threadsLabel);
            this.processorGeneralGroup.Location = new System.Drawing.Point(3, 3);
            this.processorGeneralGroup.Name = "processorGeneralGroup";
            this.processorGeneralGroup.Size = new System.Drawing.Size(334, 79);
            this.processorGeneralGroup.TabIndex = 6;
            this.processorGeneralGroup.TabStop = false;
            this.processorGeneralGroup.Text = "General";
            // 
            // addressWidthLabel
            // 
            this.addressWidthLabel.AutoSize = true;
            this.addressWidthLabel.Location = new System.Drawing.Point(151, 48);
            this.addressWidthLabel.Name = "addressWidthLabel";
            this.addressWidthLabel.Size = new System.Drawing.Size(76, 13);
            this.addressWidthLabel.TabIndex = 6;
            this.addressWidthLabel.Text = "Address Width";
            // 
            // coresLabel
            // 
            this.coresLabel.AutoSize = true;
            this.coresLabel.Location = new System.Drawing.Point(7, 48);
            this.coresLabel.Name = "coresLabel";
            this.coresLabel.Size = new System.Drawing.Size(34, 13);
            this.coresLabel.TabIndex = 2;
            this.coresLabel.Text = "Cores";
            // 
            // cores
            // 
            this.cores.Location = new System.Drawing.Point(47, 45);
            this.cores.Name = "cores";
            this.cores.ReadOnly = true;
            this.cores.Size = new System.Drawing.Size(20, 20);
            this.cores.TabIndex = 3;
            this.cores.Text = "99";
            this.cores.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // processorName
            // 
            this.processorName.Location = new System.Drawing.Point(47, 19);
            this.processorName.Name = "processorName";
            this.processorName.ReadOnly = true;
            this.processorName.Size = new System.Drawing.Size(271, 20);
            this.processorName.TabIndex = 1;
            this.processorName.Text = "Witamson";
            // 
            // processorNameLabel
            // 
            this.processorNameLabel.AutoSize = true;
            this.processorNameLabel.Location = new System.Drawing.Point(6, 22);
            this.processorNameLabel.Name = "processorNameLabel";
            this.processorNameLabel.Size = new System.Drawing.Size(35, 13);
            this.processorNameLabel.TabIndex = 0;
            this.processorNameLabel.Text = "Name";
            // 
            // threads
            // 
            this.threads.Location = new System.Drawing.Point(125, 45);
            this.threads.Name = "threads";
            this.threads.ReadOnly = true;
            this.threads.Size = new System.Drawing.Size(20, 20);
            this.threads.TabIndex = 5;
            this.threads.Text = "99";
            this.threads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.threads.TextChanged += new System.EventHandler(this.threads_TextChanged);
            // 
            // threadsLabel
            // 
            this.threadsLabel.AutoSize = true;
            this.threadsLabel.Location = new System.Drawing.Point(73, 48);
            this.threadsLabel.Name = "threadsLabel";
            this.threadsLabel.Size = new System.Drawing.Size(46, 13);
            this.threadsLabel.TabIndex = 4;
            this.threadsLabel.Text = "Threads";
            // 
            // moboPage
            // 
            this.moboPage.Controls.Add(this.moboBiosGroup);
            this.moboPage.Controls.Add(this.moboGeneralGroup);
            this.moboPage.Location = new System.Drawing.Point(4, 22);
            this.moboPage.Name = "moboPage";
            this.moboPage.Padding = new System.Windows.Forms.Padding(3);
            this.moboPage.Size = new System.Drawing.Size(340, 293);
            this.moboPage.TabIndex = 2;
            this.moboPage.Text = "Motherboard";
            this.moboPage.UseVisualStyleBackColor = true;
            // 
            // moboBiosGroup
            // 
            this.moboBiosGroup.Controls.Add(this.biosVerBox);
            this.moboBiosGroup.Controls.Add(this.biosManuBox);
            this.moboBiosGroup.Controls.Add(this.biosManuLabel);
            this.moboBiosGroup.Controls.Add(this.biosVerLabel);
            this.moboBiosGroup.Location = new System.Drawing.Point(3, 89);
            this.moboBiosGroup.Name = "moboBiosGroup";
            this.moboBiosGroup.Size = new System.Drawing.Size(334, 100);
            this.moboBiosGroup.TabIndex = 5;
            this.moboBiosGroup.TabStop = false;
            this.moboBiosGroup.Text = "BIOS";
            // 
            // biosVerBox
            // 
            this.biosVerBox.Location = new System.Drawing.Point(82, 45);
            this.biosVerBox.Name = "biosVerBox";
            this.biosVerBox.ReadOnly = true;
            this.biosVerBox.Size = new System.Drawing.Size(240, 20);
            this.biosVerBox.TabIndex = 5;
            this.biosVerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // biosManuBox
            // 
            this.biosManuBox.Location = new System.Drawing.Point(82, 19);
            this.biosManuBox.Name = "biosManuBox";
            this.biosManuBox.ReadOnly = true;
            this.biosManuBox.Size = new System.Drawing.Size(240, 20);
            this.biosManuBox.TabIndex = 4;
            this.biosManuBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // biosManuLabel
            // 
            this.biosManuLabel.AutoSize = true;
            this.biosManuLabel.Location = new System.Drawing.Point(6, 22);
            this.biosManuLabel.Name = "biosManuLabel";
            this.biosManuLabel.Size = new System.Drawing.Size(70, 13);
            this.biosManuLabel.TabIndex = 6;
            this.biosManuLabel.Text = "Manufacturer";
            // 
            // biosVerLabel
            // 
            this.biosVerLabel.AutoSize = true;
            this.biosVerLabel.Location = new System.Drawing.Point(34, 48);
            this.biosVerLabel.Name = "biosVerLabel";
            this.biosVerLabel.Size = new System.Drawing.Size(42, 13);
            this.biosVerLabel.TabIndex = 7;
            this.biosVerLabel.Text = "Version";
            // 
            // moboGeneralGroup
            // 
            this.moboGeneralGroup.Controls.Add(this.moboModelBox);
            this.moboGeneralGroup.Controls.Add(this.moboManuBox);
            this.moboGeneralGroup.Controls.Add(this.moboModelLabel);
            this.moboGeneralGroup.Controls.Add(this.moboManuLabel);
            this.moboGeneralGroup.Location = new System.Drawing.Point(3, 3);
            this.moboGeneralGroup.Name = "moboGeneralGroup";
            this.moboGeneralGroup.Size = new System.Drawing.Size(334, 79);
            this.moboGeneralGroup.TabIndex = 4;
            this.moboGeneralGroup.TabStop = false;
            this.moboGeneralGroup.Text = "General";
            // 
            // moboModelBox
            // 
            this.moboModelBox.Location = new System.Drawing.Point(82, 45);
            this.moboModelBox.Name = "moboModelBox";
            this.moboModelBox.ReadOnly = true;
            this.moboModelBox.Size = new System.Drawing.Size(240, 20);
            this.moboModelBox.TabIndex = 1;
            this.moboModelBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // moboManuBox
            // 
            this.moboManuBox.Location = new System.Drawing.Point(82, 19);
            this.moboManuBox.Name = "moboManuBox";
            this.moboManuBox.ReadOnly = true;
            this.moboManuBox.Size = new System.Drawing.Size(240, 20);
            this.moboManuBox.TabIndex = 0;
            this.moboManuBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // moboModelLabel
            // 
            this.moboModelLabel.AutoSize = true;
            this.moboModelLabel.Location = new System.Drawing.Point(40, 48);
            this.moboModelLabel.Name = "moboModelLabel";
            this.moboModelLabel.Size = new System.Drawing.Size(36, 13);
            this.moboModelLabel.TabIndex = 3;
            this.moboModelLabel.Text = "Model";
            // 
            // moboManuLabel
            // 
            this.moboManuLabel.AutoSize = true;
            this.moboManuLabel.Location = new System.Drawing.Point(6, 22);
            this.moboManuLabel.Name = "moboManuLabel";
            this.moboManuLabel.Size = new System.Drawing.Size(70, 13);
            this.moboManuLabel.TabIndex = 2;
            this.moboManuLabel.Text = "Manufacturer";
            // 
            // memoryPage
            // 
            this.memoryPage.Controls.Add(this.memoryGeneralGroup);
            this.memoryPage.Location = new System.Drawing.Point(4, 22);
            this.memoryPage.Name = "memoryPage";
            this.memoryPage.Size = new System.Drawing.Size(340, 293);
            this.memoryPage.TabIndex = 3;
            this.memoryPage.Text = "Memory";
            this.memoryPage.UseVisualStyleBackColor = true;
            // 
            // memoryGeneralGroup
            // 
            this.memoryGeneralGroup.Controls.Add(this.memorySizeBox);
            this.memoryGeneralGroup.Controls.Add(this.memorySizeLabel);
            this.memoryGeneralGroup.Location = new System.Drawing.Point(3, 3);
            this.memoryGeneralGroup.Name = "memoryGeneralGroup";
            this.memoryGeneralGroup.Size = new System.Drawing.Size(334, 155);
            this.memoryGeneralGroup.TabIndex = 0;
            this.memoryGeneralGroup.TabStop = false;
            this.memoryGeneralGroup.Text = "General";
            // 
            // memorySizeBox
            // 
            this.memorySizeBox.Location = new System.Drawing.Point(39, 19);
            this.memorySizeBox.Name = "memorySizeBox";
            this.memorySizeBox.ReadOnly = true;
            this.memorySizeBox.Size = new System.Drawing.Size(100, 20);
            this.memorySizeBox.TabIndex = 1;
            this.memorySizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // memorySizeLabel
            // 
            this.memorySizeLabel.AutoSize = true;
            this.memorySizeLabel.Location = new System.Drawing.Point(6, 22);
            this.memorySizeLabel.Name = "memorySizeLabel";
            this.memorySizeLabel.Size = new System.Drawing.Size(27, 13);
            this.memorySizeLabel.TabIndex = 0;
            this.memorySizeLabel.Text = "Size";
            // 
            // videoPage
            // 
            this.videoPage.Controls.Add(this.VideoCardDropDownBox);
            this.videoPage.Controls.Add(this.VideoSelectLabel);
            this.videoPage.Controls.Add(this.videoGeneralGroup);
            this.videoPage.Location = new System.Drawing.Point(4, 22);
            this.videoPage.Name = "videoPage";
            this.videoPage.Size = new System.Drawing.Size(340, 293);
            this.videoPage.TabIndex = 1;
            this.videoPage.Text = "Video";
            this.videoPage.UseVisualStyleBackColor = true;
            // 
            // VideoCardDropDownBox
            // 
            this.VideoCardDropDownBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VideoCardDropDownBox.FormattingEnabled = true;
            this.VideoCardDropDownBox.Location = new System.Drawing.Point(105, 13);
            this.VideoCardDropDownBox.Name = "VideoCardDropDownBox";
            this.VideoCardDropDownBox.Size = new System.Drawing.Size(225, 21);
            this.VideoCardDropDownBox.TabIndex = 6;
            this.VideoCardDropDownBox.SelectedIndexChanged += new System.EventHandler(this.VideoCardDropDownBox_SelectedIndexChanged);
            // 
            // VideoSelectLabel
            // 
            this.VideoSelectLabel.AutoSize = true;
            this.VideoSelectLabel.Location = new System.Drawing.Point(9, 16);
            this.VideoSelectLabel.Name = "VideoSelectLabel";
            this.VideoSelectLabel.Size = new System.Drawing.Size(92, 13);
            this.VideoSelectLabel.TabIndex = 5;
            this.VideoSelectLabel.Text = "Select Video Card";
            // 
            // videoGeneralGroup
            // 
            this.videoGeneralGroup.Controls.Add(this.resolutionBox);
            this.videoGeneralGroup.Controls.Add(this.resolutionLabel);
            this.videoGeneralGroup.Location = new System.Drawing.Point(3, 40);
            this.videoGeneralGroup.Name = "videoGeneralGroup";
            this.videoGeneralGroup.Size = new System.Drawing.Size(334, 135);
            this.videoGeneralGroup.TabIndex = 2;
            this.videoGeneralGroup.TabStop = false;
            this.videoGeneralGroup.Text = "General";
            // 
            // resolutionBox
            // 
            this.resolutionBox.Location = new System.Drawing.Point(102, 19);
            this.resolutionBox.Name = "resolutionBox";
            this.resolutionBox.ReadOnly = true;
            this.resolutionBox.Size = new System.Drawing.Size(152, 20);
            this.resolutionBox.TabIndex = 3;
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(6, 22);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(89, 13);
            this.resolutionLabel.TabIndex = 2;
            this.resolutionLabel.Text = "Current resolution";
            // 
            // addressWidthTextBox
            // 
            this.addressWidthTextBox.Location = new System.Drawing.Point(233, 45);
            this.addressWidthTextBox.Name = "addressWidthTextBox";
            this.addressWidthTextBox.ReadOnly = true;
            this.addressWidthTextBox.Size = new System.Drawing.Size(22, 20);
            this.addressWidthTextBox.TabIndex = 7;
            this.addressWidthTextBox.Text = "99";
            this.addressWidthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 343);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Program Diagnostyczny";
            this.tabControl1.ResumeLayout(false);
            this.processorPage.ResumeLayout(false);
            this.cacheGroup.ResumeLayout(false);
            this.cacheGroup.PerformLayout();
            this.processorGeneralGroup.ResumeLayout(false);
            this.processorGeneralGroup.PerformLayout();
            this.moboPage.ResumeLayout(false);
            this.moboBiosGroup.ResumeLayout(false);
            this.moboBiosGroup.PerformLayout();
            this.moboGeneralGroup.ResumeLayout(false);
            this.moboGeneralGroup.PerformLayout();
            this.memoryPage.ResumeLayout(false);
            this.memoryGeneralGroup.ResumeLayout(false);
            this.memoryGeneralGroup.PerformLayout();
            this.videoPage.ResumeLayout(false);
            this.videoPage.PerformLayout();
            this.videoGeneralGroup.ResumeLayout(false);
            this.videoGeneralGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage processorPage;
        private System.Windows.Forms.TextBox processorName;
        private System.Windows.Forms.Label processorNameLabel;
        private System.Windows.Forms.TextBox threads;
        private System.Windows.Forms.Label threadsLabel;
        private System.Windows.Forms.TextBox cores;
        private System.Windows.Forms.Label coresLabel;
        private System.Windows.Forms.TabPage videoPage;
        private System.Windows.Forms.GroupBox processorGeneralGroup;
        private System.Windows.Forms.GroupBox cacheGroup;
        private System.Windows.Forms.TextBox cache3Box;
        private System.Windows.Forms.TextBox cache2Box;
        private System.Windows.Forms.TextBox cache1Box;
        private System.Windows.Forms.Label cache3Label;
        private System.Windows.Forms.Label cache2Label;
        private System.Windows.Forms.Label cache1Label;
        private System.Windows.Forms.TabPage moboPage;
        private System.Windows.Forms.GroupBox moboGeneralGroup;
        private System.Windows.Forms.TextBox moboModelBox;
        private System.Windows.Forms.TextBox moboManuBox;
        private System.Windows.Forms.Label moboModelLabel;
        private System.Windows.Forms.Label moboManuLabel;
		private System.Windows.Forms.GroupBox moboBiosGroup;
		private System.Windows.Forms.TextBox biosVerBox;
		private System.Windows.Forms.TextBox biosManuBox;
		private System.Windows.Forms.Label biosManuLabel;
		private System.Windows.Forms.Label biosVerLabel;
		private System.Windows.Forms.TabPage memoryPage;
		private System.Windows.Forms.GroupBox memoryGeneralGroup;
		private System.Windows.Forms.TextBox memorySizeBox;
		private System.Windows.Forms.Label memorySizeLabel;
		private System.Windows.Forms.GroupBox videoGeneralGroup;
		private System.Windows.Forms.TextBox resolutionBox;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.Label VideoSelectLabel;
        private System.Windows.Forms.ComboBox VideoCardDropDownBox;
        private System.Windows.Forms.Label addressWidthLabel;
        private System.Windows.Forms.TextBox addressWidthTextBox;
    }
}

