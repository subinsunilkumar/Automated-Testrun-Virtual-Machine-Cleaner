namespace Build
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.comtemp = new System.Windows.Forms.CheckBox();
            this.systemp = new System.Windows.Forms.CheckBox();
            this.loctemp = new System.Windows.Forms.CheckBox();
            this.desktop = new System.Windows.Forms.CheckBox();
            this.document = new System.Windows.Forms.CheckBox();
            this.download = new System.Windows.Forms.CheckBox();
            this.Music = new System.Windows.Forms.CheckBox();
            this.pictures = new System.Windows.Forms.CheckBox();
            this.videos = new System.Windows.Forms.CheckBox();
            this.ThreeD = new System.Windows.Forms.CheckBox();
            this.removeDll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recycle = new System.Windows.Forms.CheckBox();
            this.pem = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clean";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comtemp
            // 
            this.comtemp.AutoSize = true;
            this.comtemp.Location = new System.Drawing.Point(12, 23);
            this.comtemp.Name = "comtemp";
            this.comtemp.Size = new System.Drawing.Size(120, 17);
            this.comtemp.TabIndex = 1;
            this.comtemp.Text = "COM Test Temp Dir";
            this.comtemp.UseVisualStyleBackColor = true;
            // 
            // systemp
            // 
            this.systemp.AutoSize = true;
            this.systemp.Location = new System.Drawing.Point(138, 23);
            this.systemp.Name = "systemp";
            this.systemp.Size = new System.Drawing.Size(85, 17);
            this.systemp.TabIndex = 2;
            this.systemp.Text = "Sytem Temp";
            this.systemp.UseVisualStyleBackColor = true;
            // 
            // loctemp
            // 
            this.loctemp.AutoSize = true;
            this.loctemp.Location = new System.Drawing.Point(229, 23);
            this.loctemp.Name = "loctemp";
            this.loctemp.Size = new System.Drawing.Size(82, 17);
            this.loctemp.TabIndex = 3;
            this.loctemp.Text = "Local Temp";
            this.loctemp.UseVisualStyleBackColor = true;
            // 
            // desktop
            // 
            this.desktop.AutoSize = true;
            this.desktop.Location = new System.Drawing.Point(12, 56);
            this.desktop.Name = "desktop";
            this.desktop.Size = new System.Drawing.Size(66, 17);
            this.desktop.TabIndex = 5;
            this.desktop.Text = "Desktop";
            this.desktop.UseVisualStyleBackColor = true;
            // 
            // document
            // 
            this.document.AutoSize = true;
            this.document.Location = new System.Drawing.Point(84, 56);
            this.document.Name = "document";
            this.document.Size = new System.Drawing.Size(80, 17);
            this.document.TabIndex = 6;
            this.document.Text = "Documents";
            this.document.UseVisualStyleBackColor = true;
            // 
            // download
            // 
            this.download.AutoSize = true;
            this.download.Location = new System.Drawing.Point(170, 56);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(79, 17);
            this.download.TabIndex = 7;
            this.download.Text = "Downloads";
            this.download.UseVisualStyleBackColor = true;
            // 
            // Music
            // 
            this.Music.AutoSize = true;
            this.Music.Location = new System.Drawing.Point(255, 56);
            this.Music.Name = "Music";
            this.Music.Size = new System.Drawing.Size(54, 17);
            this.Music.TabIndex = 8;
            this.Music.Text = "Music";
            this.Music.UseVisualStyleBackColor = true;
            // 
            // pictures
            // 
            this.pictures.AutoSize = true;
            this.pictures.Location = new System.Drawing.Point(317, 56);
            this.pictures.Name = "pictures";
            this.pictures.Size = new System.Drawing.Size(64, 17);
            this.pictures.TabIndex = 9;
            this.pictures.Text = "Pictures";
            this.pictures.UseVisualStyleBackColor = true;
            // 
            // videos
            // 
            this.videos.AutoSize = true;
            this.videos.Location = new System.Drawing.Point(12, 90);
            this.videos.Name = "videos";
            this.videos.Size = new System.Drawing.Size(58, 17);
            this.videos.TabIndex = 10;
            this.videos.Text = "Videos";
            this.videos.UseVisualStyleBackColor = true;
            // 
            // ThreeD
            // 
            this.ThreeD.AutoSize = true;
            this.ThreeD.Location = new System.Drawing.Point(317, 23);
            this.ThreeD.Name = "ThreeD";
            this.ThreeD.Size = new System.Drawing.Size(79, 17);
            this.ThreeD.TabIndex = 11;
            this.ThreeD.Text = "3D Objects";
            this.ThreeD.UseVisualStyleBackColor = true;
            // 
            // removeDll
            // 
            this.removeDll.AutoSize = true;
            this.removeDll.Location = new System.Drawing.Point(84, 90);
            this.removeDll.Name = "removeDll";
            this.removeDll.Size = new System.Drawing.Size(87, 17);
            this.removeDll.TabIndex = 12;
            this.removeDll.Text = " Old COM Dll";
            this.removeDll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 13;
            // 
            // recycle
            // 
            this.recycle.AutoSize = true;
            this.recycle.Location = new System.Drawing.Point(171, 90);
            this.recycle.Name = "recycle";
            this.recycle.Size = new System.Drawing.Size(83, 17);
            this.recycle.TabIndex = 14;
            this.recycle.Text = "Recycle Bin";
            this.recycle.UseVisualStyleBackColor = true;
            // 
            // pem
            // 
            this.pem.AutoSize = true;
            this.pem.Location = new System.Drawing.Point(255, 227);
            this.pem.Name = "pem";
            this.pem.Size = new System.Drawing.Size(100, 17);
            this.pem.TabIndex = 15;
            this.pem.Text = "Copy PEM Files";
            this.pem.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(317, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Uncheck All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 269);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pem);
            this.Controls.Add(this.recycle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeDll);
            this.Controls.Add(this.ThreeD);
            this.Controls.Add(this.videos);
            this.Controls.Add(this.pictures);
            this.Controls.Add(this.Music);
            this.Controls.Add(this.download);
            this.Controls.Add(this.document);
            this.Controls.Add(this.desktop);
            this.Controls.Add(this.loctemp);
            this.Controls.Add(this.systemp);
            this.Controls.Add(this.comtemp);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Test PC Cleaner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox comtemp;
        private System.Windows.Forms.CheckBox systemp;
        private System.Windows.Forms.CheckBox loctemp;
        private System.Windows.Forms.CheckBox desktop;
        private System.Windows.Forms.CheckBox document;
        private System.Windows.Forms.CheckBox download;
        private System.Windows.Forms.CheckBox Music;
        private System.Windows.Forms.CheckBox pictures;
        private System.Windows.Forms.CheckBox videos;
        private System.Windows.Forms.CheckBox ThreeD;
        private System.Windows.Forms.CheckBox removeDll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox recycle;
        private System.Windows.Forms.CheckBox pem;
        private System.Windows.Forms.Button button2;
    }
}

