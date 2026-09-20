namespace Coolsoft.NetPinger
{
	partial class Registration
	{
		 
		 
		 
		private System.ComponentModel.IContainer components = null;

		 
		 
		 
		 
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		 
		 
		 
		 
		private void InitializeComponent()
		{
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnOK = new System.Windows.Forms.Button();
			this._grpLicenceKey = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this._txtLicenceKey = new System.Windows.Forms.TextBox();
			this._grpLicenceFile = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this._lnkDownload = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this._lnkRegistration = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this._btnBrowse = new System.Windows.Forms.Button();
			this._txtLicenceFile = new System.Windows.Forms.TextBox();
			this._rbLicenceKey = new System.Windows.Forms.RadioButton();
			this._rbLicenceFile = new System.Windows.Forms.RadioButton();
			this._dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this._btnProxy = new System.Windows.Forms.Button();
			this._btnHostID = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this._grpLicenceKey.SuspendLayout();
			this._grpLicenceFile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			 
			 
			 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(657, 262);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 7;
			this._btnCancel.Text = "&Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			 
			 
			 
			this._btnOK.Location = new System.Drawing.Point(576, 262);
			this._btnOK.Name = "_btnOK";
			this._btnOK.Size = new System.Drawing.Size(75, 23);
			this._btnOK.TabIndex = 6;
			this._btnOK.Text = "&OK";
			this._btnOK.UseVisualStyleBackColor = true;
			this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
			 
			 
			 
			this._grpLicenceKey.Controls.Add(this.label2);
			this._grpLicenceKey.Controls.Add(this._txtLicenceKey);
			this._grpLicenceKey.Location = new System.Drawing.Point(275, 13);
			this._grpLicenceKey.Name = "_grpLicenceKey";
			this._grpLicenceKey.Size = new System.Drawing.Size(457, 83);
			this._grpLicenceKey.TabIndex = 1;
			this._grpLicenceKey.TabStop = false;
			 
			 
			 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "&Licence key:";
			 
			 
			 
			this._txtLicenceKey.Location = new System.Drawing.Point(9, 44);
			this._txtLicenceKey.Name = "_txtLicenceKey";
			this._txtLicenceKey.Size = new System.Drawing.Size(442, 20);
			this._txtLicenceKey.TabIndex = 1;
			this._txtLicenceKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtLicenceKey_KeyPress);
			 
			 
			 
			this._grpLicenceFile.Controls.Add(this.label6);
			this._grpLicenceFile.Controls.Add(this._lnkDownload);
			this._grpLicenceFile.Controls.Add(this.label5);
			this._grpLicenceFile.Controls.Add(this.label4);
			this._grpLicenceFile.Controls.Add(this._lnkRegistration);
			this._grpLicenceFile.Controls.Add(this.label3);
			this._grpLicenceFile.Controls.Add(this.label1);
			this._grpLicenceFile.Controls.Add(this._btnBrowse);
			this._grpLicenceFile.Controls.Add(this._txtLicenceFile);
			this._grpLicenceFile.Location = new System.Drawing.Point(275, 102);
			this._grpLicenceFile.Name = "_grpLicenceFile";
			this._grpLicenceFile.Size = new System.Drawing.Size(457, 154);
			this._grpLicenceFile.TabIndex = 3;
			this._grpLicenceFile.TabStop = false;
			 
			 
			 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(225, 122);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(129, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "- Product Download Page";
			 
			 
			 
			this._lnkDownload.AutoSize = true;
			this._lnkDownload.Location = new System.Drawing.Point(12, 122);
			this._lnkDownload.Name = "_lnkDownload";
			this._lnkDownload.Size = new System.Drawing.Size(217, 13);
			this._lnkDownload.TabIndex = 4;
			this._lnkDownload.TabStop = true;
			this._lnkDownload.Text = "http://www.coolsoft-sd.com/Download.aspx";
			this._lnkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lnkDownload_LinkClicked);
			 
			 
			 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 105);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(371, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "If you reinstalled already registred product, your licence key file is available " +
				"at:";
			 
			 
			 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(270, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(137, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "- Product Registration Page";
			 
			 
			 
			this._lnkRegistration.AutoSize = true;
			this._lnkRegistration.Location = new System.Drawing.Point(12, 88);
			this._lnkRegistration.Name = "_lnkRegistration";
			this._lnkRegistration.Size = new System.Drawing.Size(262, 13);
			this._lnkRegistration.TabIndex = 3;
			this._lnkRegistration.TabStop = true;
			this._lnkRegistration.Text = "http://www.coolsoft-sd.com/ProductRegistration.aspx";
			this._lnkRegistration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lnkRegistration_LinkClicked);
			 
			 
			 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(423, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "If Internet connection is not available at this computer, you can obtain licence " +
				"key file at:";
			 
			 
			 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Licence key file &path:";
			 
			 
			 
			this._btnBrowse.Location = new System.Drawing.Point(376, 43);
			this._btnBrowse.Name = "_btnBrowse";
			this._btnBrowse.Size = new System.Drawing.Size(75, 23);
			this._btnBrowse.TabIndex = 2;
			this._btnBrowse.Text = "&Browse...";
			this._btnBrowse.UseVisualStyleBackColor = true;
			this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
			 
			 
			 
			this._txtLicenceFile.Location = new System.Drawing.Point(9, 44);
			this._txtLicenceFile.Name = "_txtLicenceFile";
			this._txtLicenceFile.Size = new System.Drawing.Size(361, 20);
			this._txtLicenceFile.TabIndex = 1;
			 
			 
			 
			this._rbLicenceKey.AutoSize = true;
			this._rbLicenceKey.Location = new System.Drawing.Point(282, 10);
			this._rbLicenceKey.Name = "_rbLicenceKey";
			this._rbLicenceKey.Size = new System.Drawing.Size(107, 17);
			this._rbLicenceKey.TabIndex = 0;
			this._rbLicenceKey.TabStop = true;
			this._rbLicenceKey.Text = "Enter licence &key";
			this._rbLicenceKey.UseVisualStyleBackColor = true;
			this._rbLicenceKey.CheckedChanged += new System.EventHandler(this._rbLicenceKey_CheckedChanged);
			 
			 
			 
			this._rbLicenceFile.AutoSize = true;
			this._rbLicenceFile.Location = new System.Drawing.Point(282, 99);
			this._rbLicenceFile.Name = "_rbLicenceFile";
			this._rbLicenceFile.Size = new System.Drawing.Size(97, 17);
			this._rbLicenceFile.TabIndex = 2;
			this._rbLicenceFile.TabStop = true;
			this._rbLicenceFile.Text = "Use licence &file";
			this._rbLicenceFile.UseVisualStyleBackColor = true;
			this._rbLicenceFile.CheckedChanged += new System.EventHandler(this._rbLicenceFile_CheckedChanged);
			 
			 
			 
			this._dlgOpenFile.Filter = "Licence Files (*.lic)|*.lic|All Files (*.*)|*.*";
			this._dlgOpenFile.Title = "Select Licence File";
			 
			 
			 
			this._btnProxy.Location = new System.Drawing.Point(275, 262);
			this._btnProxy.Name = "_btnProxy";
			this._btnProxy.Size = new System.Drawing.Size(106, 23);
			this._btnProxy.TabIndex = 4;
			this._btnProxy.Text = "&Proxy Options...";
			this._btnProxy.UseVisualStyleBackColor = true;
			this._btnProxy.Click += new System.EventHandler(this._btnProxy_Click);
			 
			 
			 
			this._btnHostID.Location = new System.Drawing.Point(387, 262);
			this._btnHostID.Name = "_btnHostID";
			this._btnHostID.Size = new System.Drawing.Size(75, 23);
			this._btnHostID.TabIndex = 5;
			this._btnHostID.Text = "&Host ID...";
			this._btnHostID.UseVisualStyleBackColor = true;
			this._btnHostID.Click += new System.EventHandler(this._btnHostID_Click);
			 
			 
			 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBox1.Image = global::Coolsoft.NetPinger.Properties.Resources.keys;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(256, 256);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			 
			 
			 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(744, 297);
			this.Controls.Add(this._btnHostID);
			this.Controls.Add(this._btnProxy);
			this.Controls.Add(this._rbLicenceKey);
			this.Controls.Add(this._rbLicenceFile);
			this.Controls.Add(this._grpLicenceFile);
			this.Controls.Add(this._grpLicenceKey);
			this.Controls.Add(this._btnOK);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Registration";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MASA - Registration";
			this._grpLicenceKey.ResumeLayout(false);
			this._grpLicenceKey.PerformLayout();
			this._grpLicenceFile.ResumeLayout(false);
			this._grpLicenceFile.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOK;
		private System.Windows.Forms.GroupBox _grpLicenceKey;
		private System.Windows.Forms.GroupBox _grpLicenceFile;
		private System.Windows.Forms.RadioButton _rbLicenceKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _btnBrowse;
		private System.Windows.Forms.TextBox _txtLicenceFile;
		private System.Windows.Forms.RadioButton _rbLicenceFile;
		private System.Windows.Forms.TextBox _txtLicenceKey;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel _lnkRegistration;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.LinkLabel _lnkDownload;
		private System.Windows.Forms.OpenFileDialog _dlgOpenFile;
		private System.Windows.Forms.Button _btnProxy;
		private System.Windows.Forms.Button _btnHostID;
	}
}