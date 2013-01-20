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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cacheGroup = new System.Windows.Forms.GroupBox();
            this.cache3Box = new System.Windows.Forms.TextBox();
            this.cache2Box = new System.Windows.Forms.TextBox();
            this.cache1Box = new System.Windows.Forms.TextBox();
            this.cache3Label = new System.Windows.Forms.Label();
            this.cache2Label = new System.Windows.Forms.Label();
            this.cache1Label = new System.Windows.Forms.Label();
            this.coresNthreadsGroup = new System.Windows.Forms.GroupBox();
            this.coresLabel = new System.Windows.Forms.Label();
            this.cores = new System.Windows.Forms.TextBox();
            this.threads = new System.Windows.Forms.TextBox();
            this.threadsLabel = new System.Windows.Forms.Label();
            this.processorName = new System.Windows.Forms.TextBox();
            this.processorNameLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.videoCardName = new System.Windows.Forms.TextBox();
            this.videoCardLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cacheGroup.SuspendLayout();
            this.coresNthreadsGroup.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(348, 319);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cacheGroup);
            this.tabPage1.Controls.Add(this.coresNthreadsGroup);
            this.tabPage1.Controls.Add(this.processorName);
            this.tabPage1.Controls.Add(this.processorNameLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(340, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Processor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cacheGroup
            // 
            this.cacheGroup.Controls.Add(this.cache3Box);
            this.cacheGroup.Controls.Add(this.cache2Box);
            this.cacheGroup.Controls.Add(this.cache1Label);
            this.cacheGroup.Controls.Add(this.cache2Label);
            this.cacheGroup.Controls.Add(this.cache1Box);
            this.cacheGroup.Controls.Add(this.cache3Label);
            this.cacheGroup.Location = new System.Drawing.Point(10, 76);
            this.cacheGroup.Name = "cacheGroup";
            this.cacheGroup.Size = new System.Drawing.Size(159, 103);
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
            // 
            // cache2Box
            // 
            this.cache2Box.Location = new System.Drawing.Point(54, 45);
            this.cache2Box.Name = "cache2Box";
            this.cache2Box.ReadOnly = true;
            this.cache2Box.Size = new System.Drawing.Size(93, 20);
            this.cache2Box.TabIndex = 4;
            // 
            // cache1Box
            // 
            this.cache1Box.Location = new System.Drawing.Point(54, 19);
            this.cache1Box.Name = "cache1Box";
            this.cache1Box.ReadOnly = true;
            this.cache1Box.Size = new System.Drawing.Size(93, 20);
            this.cache1Box.TabIndex = 3;
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
            // cache2Label
            // 
            this.cache2Label.AutoSize = true;
            this.cache2Label.Location = new System.Drawing.Point(6, 48);
            this.cache2Label.Name = "cache2Label";
            this.cache2Label.Size = new System.Drawing.Size(42, 13);
            this.cache2Label.TabIndex = 1;
            this.cache2Label.Text = "Level 2";
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
            // coresNthreadsGroup
            // 
            this.coresNthreadsGroup.Controls.Add(this.coresLabel);
            this.coresNthreadsGroup.Controls.Add(this.cores);
            this.coresNthreadsGroup.Controls.Add(this.threads);
            this.coresNthreadsGroup.Controls.Add(this.threadsLabel);
            this.coresNthreadsGroup.Location = new System.Drawing.Point(10, 30);
            this.coresNthreadsGroup.Name = "coresNthreadsGroup";
            this.coresNthreadsGroup.Size = new System.Drawing.Size(159, 40);
            this.coresNthreadsGroup.TabIndex = 6;
            this.coresNthreadsGroup.TabStop = false;
            // 
            // coresLabel
            // 
            this.coresLabel.AutoSize = true;
            this.coresLabel.Location = new System.Drawing.Point(6, 16);
            this.coresLabel.Name = "coresLabel";
            this.coresLabel.Size = new System.Drawing.Size(34, 13);
            this.coresLabel.TabIndex = 2;
            this.coresLabel.Text = "Cores";
            // 
            // cores
            // 
            this.cores.Location = new System.Drawing.Point(48, 13);
            this.cores.Name = "cores";
            this.cores.ReadOnly = true;
            this.cores.Size = new System.Drawing.Size(20, 20);
            this.cores.TabIndex = 3;
            this.cores.Text = "99";
            // 
            // threads
            // 
            this.threads.Location = new System.Drawing.Point(127, 13);
            this.threads.Name = "threads";
            this.threads.ReadOnly = true;
            this.threads.Size = new System.Drawing.Size(20, 20);
            this.threads.TabIndex = 5;
            this.threads.Text = "99";
            // 
            // threadsLabel
            // 
            this.threadsLabel.AutoSize = true;
            this.threadsLabel.Location = new System.Drawing.Point(75, 16);
            this.threadsLabel.Name = "threadsLabel";
            this.threadsLabel.Size = new System.Drawing.Size(46, 13);
            this.threadsLabel.TabIndex = 4;
            this.threadsLabel.Text = "Threads";
            // 
            // processorName
            // 
            this.processorName.Location = new System.Drawing.Point(48, 4);
            this.processorName.Name = "processorName";
            this.processorName.ReadOnly = true;
            this.processorName.Size = new System.Drawing.Size(286, 20);
            this.processorName.TabIndex = 1;
            this.processorName.Text = "Witamson";
            // 
            // processorNameLabel
            // 
            this.processorNameLabel.AutoSize = true;
            this.processorNameLabel.Location = new System.Drawing.Point(7, 7);
            this.processorNameLabel.Name = "processorNameLabel";
            this.processorNameLabel.Size = new System.Drawing.Size(35, 13);
            this.processorNameLabel.TabIndex = 0;
            this.processorNameLabel.Text = "Name";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.videoCardName);
            this.tabPage2.Controls.Add(this.videoCardLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(340, 293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Video";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // videoCardName
            // 
            this.videoCardName.Location = new System.Drawing.Point(99, 4);
            this.videoCardName.Name = "videoCardName";
            this.videoCardName.ReadOnly = true;
            this.videoCardName.Size = new System.Drawing.Size(238, 20);
            this.videoCardName.TabIndex = 1;
            // 
            // videoCardLabel
            // 
            this.videoCardLabel.AutoSize = true;
            this.videoCardLabel.Location = new System.Drawing.Point(3, 7);
            this.videoCardLabel.Name = "videoCardLabel";
            this.videoCardLabel.Size = new System.Drawing.Size(90, 13);
            this.videoCardLabel.TabIndex = 0;
            this.videoCardLabel.Text = "Video Card Name";
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.cacheGroup.ResumeLayout(false);
            this.cacheGroup.PerformLayout();
            this.coresNthreadsGroup.ResumeLayout(false);
            this.coresNthreadsGroup.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox processorName;
        private System.Windows.Forms.Label processorNameLabel;
        private System.Windows.Forms.TextBox threads;
        private System.Windows.Forms.Label threadsLabel;
        private System.Windows.Forms.TextBox cores;
        private System.Windows.Forms.Label coresLabel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox videoCardName;
        private System.Windows.Forms.Label videoCardLabel;
        private System.Windows.Forms.GroupBox coresNthreadsGroup;
        private System.Windows.Forms.GroupBox cacheGroup;
        private System.Windows.Forms.TextBox cache3Box;
        private System.Windows.Forms.TextBox cache2Box;
        private System.Windows.Forms.TextBox cache1Box;
        private System.Windows.Forms.Label cache3Label;
        private System.Windows.Forms.Label cache2Label;
        private System.Windows.Forms.Label cache1Label;
    }
}

