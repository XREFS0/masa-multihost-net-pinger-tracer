namespace NetPinger
{
	partial class PingForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PingForm));
			this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this._notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this._nimRestore = new System.Windows.Forms.ToolStripMenuItem();
			this._nimMaximize = new System.Windows.Forms.ToolStripMenuItem();
			this._nimMinimize = new System.Windows.Forms.ToolStripMenuItem();
			this._nimExit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this._nimStartAll = new System.Windows.Forms.ToolStripMenuItem();
			this._nimStopAll = new System.Windows.Forms.ToolStripMenuItem();
			this._tbStartAll = new System.Windows.Forms.ToolStripButton();
			this._tbStopAll = new System.Windows.Forms.ToolStripButton();
			this._tbClearAllStatistics = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this._tbStartHost = new System.Windows.Forms.ToolStripButton();
			this._tbStopHost = new System.Windows.Forms.ToolStripButton();
			this._tbClearStatistics = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this._tbAddNewHost = new System.Windows.Forms.ToolStripButton();
			this._tbHostOptions = new System.Windows.Forms.ToolStripButton();
			this._tbRemoveHost = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this._tbOptions = new System.Windows.Forms.ToolStripButton();
			this._tbAbout = new System.Windows.Forms.ToolStripButton();
			this._toolbar = new System.Windows.Forms.ToolStrip();
			this._tbDataSeriesOptions = new System.Windows.Forms.ToolStripButton();
			this._tbIPScan = new System.Windows.Forms.ToolStripButton();
			this._tbTraceroute = new System.Windows.Forms.ToolStripButton();
			this._tbGraphs = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this._tbSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this._lvHosts = new NetPinger.ListViewDB();
			this._colIpAddr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colHostDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colPacketSent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colPacketReceived = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colPacketReceivedPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colPacketLost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colPacketLostPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colLastPacketLost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colConsecutivePacketsLost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colMaxConsecutivePacketsLost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colRecPacketReceived = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colRecPacketReceivedPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colRecPacketLost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colRecPacketLostPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colCurrentResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colAverageResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colMinResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colMaxResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colStatusDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colAliveStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colDeadStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colDnsErrorStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colUnknownStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colAvailability = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colTestDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colCurTestDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._notifyIconMenu.SuspendLayout();
			this._toolbar.SuspendLayout();
			this.SuspendLayout();
			 
			 
			 
			this._notifyIcon.ContextMenuStrip = this._notifyIconMenu;
			this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
			this._notifyIcon.Text = "NetPinger";
			this._notifyIcon.Visible = true;
			this._notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this._notifyIcon_MouseClick);
			this._notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._notifyIcon_MouseDoubleClick);
			 
			 
			 
			this._notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this._nimRestore,
			this._nimMaximize,
			this._nimMinimize,
			this._nimExit,
			this.toolStripMenuItem1,
			this._nimStartAll,
			this._nimStopAll});
			this._notifyIconMenu.Name = "_notifyIconMenu";
			this._notifyIconMenu.Size = new System.Drawing.Size(125, 142);
			 
			 
			 
			this._nimRestore.Name = "_nimRestore";
			this._nimRestore.Size = new System.Drawing.Size(124, 22);
			this._nimRestore.Text = "Restore";
			this._nimRestore.Click += new System.EventHandler(this._nimRestore_Click);
			 
			 
			 
			this._nimMaximize.Name = "_nimMaximize";
			this._nimMaximize.Size = new System.Drawing.Size(124, 22);
			this._nimMaximize.Text = "Maximize";
			this._nimMaximize.Click += new System.EventHandler(this._nimMaximize_Click);
			 
			 
			 
			this._nimMinimize.Name = "_nimMinimize";
			this._nimMinimize.Size = new System.Drawing.Size(124, 22);
			this._nimMinimize.Text = "Minimize";
			this._nimMinimize.Click += new System.EventHandler(this._nimMinimize_Click);
			 
			 
			 
			this._nimExit.Name = "_nimExit";
			this._nimExit.Size = new System.Drawing.Size(124, 22);
			this._nimExit.Text = "Exit";
			this._nimExit.Click += new System.EventHandler(this._nimExit_Click);
			 
			 
			 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
			 
			 
			 
			this._nimStartAll.Name = "_nimStartAll";
			this._nimStartAll.Size = new System.Drawing.Size(124, 22);
			this._nimStartAll.Text = "Start All";
			this._nimStartAll.Click += new System.EventHandler(this._tbStartAll_Click);
			 
			 
			 
			this._nimStopAll.Name = "_nimStopAll";
			this._nimStopAll.Size = new System.Drawing.Size(124, 22);
			this._nimStopAll.Text = "Stop All";
			this._nimStopAll.Click += new System.EventHandler(this._tbStopAll_Click);
			 
			 
			 
			this._tbStartAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbStartAll.Image = ((System.Drawing.Image)(resources.GetObject("_tbStartAll.Image")));
			this._tbStartAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbStartAll.Name = "_tbStartAll";
			this._tbStartAll.Size = new System.Drawing.Size(36, 36);
			this._tbStartAll.Text = "Start All";
			this._tbStartAll.Click += new System.EventHandler(this._tbStartAll_Click);
			 
			 
			 
			this._tbStopAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbStopAll.Image = ((System.Drawing.Image)(resources.GetObject("_tbStopAll.Image")));
			this._tbStopAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbStopAll.Name = "_tbStopAll";
			this._tbStopAll.Size = new System.Drawing.Size(36, 36);
			this._tbStopAll.Text = "Stop All";
			this._tbStopAll.Click += new System.EventHandler(this._tbStopAll_Click);
			 
			 
			 
			this._tbClearAllStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbClearAllStatistics.Image = ((System.Drawing.Image)(resources.GetObject("_tbClearAllStatistics.Image")));
			this._tbClearAllStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbClearAllStatistics.Name = "_tbClearAllStatistics";
			this._tbClearAllStatistics.Size = new System.Drawing.Size(36, 36);
			this._tbClearAllStatistics.Text = "Clear All Statistics";
			this._tbClearAllStatistics.Click += new System.EventHandler(this._tbClearAllStatistics_Click);
			 
			 
			 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			 
			 
			 
			this._tbStartHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbStartHost.Enabled = false;
			this._tbStartHost.Image = ((System.Drawing.Image)(resources.GetObject("_tbStartHost.Image")));
			this._tbStartHost.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbStartHost.Name = "_tbStartHost";
			this._tbStartHost.Size = new System.Drawing.Size(36, 36);
			this._tbStartHost.Text = "Start Host";
			this._tbStartHost.Click += new System.EventHandler(this._tbStartHost_Click);
			 
			 
			 
			this._tbStopHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbStopHost.Enabled = false;
			this._tbStopHost.Image = ((System.Drawing.Image)(resources.GetObject("_tbStopHost.Image")));
			this._tbStopHost.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbStopHost.Name = "_tbStopHost";
			this._tbStopHost.Size = new System.Drawing.Size(36, 36);
			this._tbStopHost.Text = "Stop Host";
			this._tbStopHost.Click += new System.EventHandler(this._tbStopHost_Click);
			 
			 
			 
			this._tbClearStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbClearStatistics.Enabled = false;
			this._tbClearStatistics.Image = ((System.Drawing.Image)(resources.GetObject("_tbClearStatistics.Image")));
			this._tbClearStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbClearStatistics.Name = "_tbClearStatistics";
			this._tbClearStatistics.Size = new System.Drawing.Size(36, 36);
			this._tbClearStatistics.Text = "Clear Statistics";
			this._tbClearStatistics.Click += new System.EventHandler(this._tbClearStatistics_Click);
			 
			 
			 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
			 
			 
			 
			this._tbAddNewHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbAddNewHost.Image = ((System.Drawing.Image)(resources.GetObject("_tbAddNewHost.Image")));
			this._tbAddNewHost.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbAddNewHost.Name = "_tbAddNewHost";
			this._tbAddNewHost.Size = new System.Drawing.Size(36, 36);
			this._tbAddNewHost.Text = "Add New Host";
			this._tbAddNewHost.Click += new System.EventHandler(this._tbAddNewHost_Click);
			 
			 
			 
			this._tbHostOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbHostOptions.Enabled = false;
			this._tbHostOptions.Image = ((System.Drawing.Image)(resources.GetObject("_tbHostOptions.Image")));
			this._tbHostOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbHostOptions.Name = "_tbHostOptions";
			this._tbHostOptions.Size = new System.Drawing.Size(36, 36);
			this._tbHostOptions.Text = "Host Options";
			this._tbHostOptions.Click += new System.EventHandler(this._tbHostOptions_Click);
			 
			 
			 
			this._tbRemoveHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbRemoveHost.Enabled = false;
			this._tbRemoveHost.Image = ((System.Drawing.Image)(resources.GetObject("_tbRemoveHost.Image")));
			this._tbRemoveHost.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbRemoveHost.Name = "_tbRemoveHost";
			this._tbRemoveHost.Size = new System.Drawing.Size(36, 36);
			this._tbRemoveHost.Text = "Remove Host";
			this._tbRemoveHost.Click += new System.EventHandler(this._tbRemoveHost_Click);
			 
			 
			 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
			 
			 
			 
			this._tbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbOptions.Image = ((System.Drawing.Image)(resources.GetObject("_tbOptions.Image")));
			this._tbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbOptions.Name = "_tbOptions";
			this._tbOptions.Size = new System.Drawing.Size(36, 36);
			this._tbOptions.Text = "Options";
			this._tbOptions.Click += new System.EventHandler(this._tbOptions_Click);
			 
			 
			 
			this._tbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbAbout.Image = ((System.Drawing.Image)(resources.GetObject("_tbAbout.Image")));
			this._tbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbAbout.Name = "_tbAbout";
			this._tbAbout.Size = new System.Drawing.Size(36, 36);
			this._tbAbout.Text = "About NetPinger";
			this._tbAbout.Click += new System.EventHandler(this._tbAbout_Click);
			 
			 
			 
			this._toolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
			this._toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this._tbStartAll,
			this._tbStopAll,
			this._tbClearAllStatistics,
			this.toolStripSeparator1,
			this._tbStartHost,
			this._tbStopHost,
			this._tbClearStatistics,
			this.toolStripSeparator5,
			this._tbAddNewHost,
			this._tbRemoveHost,
			this._tbHostOptions,
			this._tbDataSeriesOptions,
			this.toolStripSeparator3,
			this._tbIPScan,
			this._tbTraceroute,
			this._tbGraphs,
			this.toolStripSeparator2,
			this._tbSave,
			this._tbOptions,
			this.toolStripSeparator4,
			this._tbAbout});
			this._toolbar.Location = new System.Drawing.Point(0, 0);
			this._toolbar.Name = "_toolbar";
			this._toolbar.Size = new System.Drawing.Size(962, 39);
			this._toolbar.TabIndex = 3;
			this._toolbar.Text = "Toolbar";
			 
			 
			 
			this._tbDataSeriesOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbDataSeriesOptions.Enabled = false;
			this._tbDataSeriesOptions.Image = ((System.Drawing.Image)(resources.GetObject("_tbDataSeriesOptions.Image")));
			this._tbDataSeriesOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbDataSeriesOptions.Name = "_tbDataSeriesOptions";
			this._tbDataSeriesOptions.Size = new System.Drawing.Size(36, 36);
			this._tbDataSeriesOptions.Text = "Data Series Options";
			this._tbDataSeriesOptions.Click += new System.EventHandler(this._tbDataSeriesOptions_Click);
			 
			 
			 
			this._tbIPScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbIPScan.Image = ((System.Drawing.Image)(resources.GetObject("_tbIPScan.Image")));
			this._tbIPScan.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbIPScan.Name = "_tbIPScan";
			this._tbIPScan.Size = new System.Drawing.Size(36, 36);
			this._tbIPScan.Text = "Scan IP Address Range";
			this._tbIPScan.Click += new System.EventHandler(this._tbIPScan_Click);
			 
			 
			 
			this._tbTraceroute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbTraceroute.Image = ((System.Drawing.Image)(resources.GetObject("_tbTraceroute.Image")));
			this._tbTraceroute.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbTraceroute.Name = "_tbTraceroute";
			this._tbTraceroute.Size = new System.Drawing.Size(36, 36);
			this._tbTraceroute.Text = "Trace IP Route";
			this._tbTraceroute.Click += new System.EventHandler(this._tbTraceroute_Click);
			 
			 
			 
			this._tbGraphs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbGraphs.Image = ((System.Drawing.Image)(resources.GetObject("_tbGraphs.Image")));
			this._tbGraphs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbGraphs.Name = "_tbGraphs";
			this._tbGraphs.Size = new System.Drawing.Size(36, 36);
			this._tbGraphs.Text = "Show Graphs";
			this._tbGraphs.Click += new System.EventHandler(this._tbGraphs_Click);
			 
			 
			 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
			 
			 
			 
			this._tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._tbSave.Image = ((System.Drawing.Image)(resources.GetObject("_tbSave.Image")));
			this._tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tbSave.Name = "_tbSave";
			this._tbSave.Size = new System.Drawing.Size(36, 36);
			this._tbSave.Text = "Save Hosts";
			this._tbSave.Click += new System.EventHandler(this._tbSave_Click);
			 
			 
			 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
			 
			 
			 
			this._lvHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this._lvHosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this._colIpAddr,
			this._colHostName,
			this._colHostDescription,
			this._colStatus,
			this._colPacketSent,
			this._colPacketReceived,
			this._colPacketReceivedPercent,
			this._colPacketLost,
			this._colPacketLostPercent,
			this._colLastPacketLost,
			this._colConsecutivePacketsLost,
			this._colMaxConsecutivePacketsLost,
			this._colRecPacketReceived,
			this._colRecPacketReceivedPercent,
			this._colRecPacketLost,
			this._colRecPacketLostPercent,
			this._colCurrentResponseTime,
			this._colAverageResponseTime,
			this._colMinResponseTime,
			this._colMaxResponseTime,
			this._colStatusDuration,
			this._colAliveStatus,
			this._colDeadStatus,
			this._colDnsErrorStatus,
			this._colUnknownStatus,
			this._colAvailability,
			this._colTestDuration,
			this._colCurTestDuration});
			this._lvHosts.FullRowSelect = true;
			this._lvHosts.GridLines = true;
			this._lvHosts.Location = new System.Drawing.Point(0, 44);
			this._lvHosts.MultiSelect = false;
			this._lvHosts.Name = "_lvHosts";
			this._lvHosts.Size = new System.Drawing.Size(962, 217);
			this._lvHosts.TabIndex = 0;
			this._lvHosts.UseCompatibleStateImageBehavior = false;
			this._lvHosts.View = System.Windows.Forms.View.Details;
			this._lvHosts.SelectedIndexChanged += new System.EventHandler(this._lvHosts_SelectedIndexChanged);
			this._lvHosts.DoubleClick += new System.EventHandler(this._lvHosts_DoubleClick);
			this._lvHosts.MouseUp += new System.Windows.Forms.MouseEventHandler(this._lvHosts_MouseUp);
			 
			 
			 
			this._colIpAddr.Text = "IP Address";
			this._colIpAddr.Width = 108;
			 
			 
			 
			this._colHostName.Text = "Host Name";
			this._colHostName.Width = 127;
			 
			 
			 
			this._colHostDescription.Text = "Host Description";
			this._colHostDescription.Width = 164;
			 
			 
			 
			this._colStatus.Text = "Status";
			this._colStatus.Width = 61;
			 
			 
			 
			this._colPacketSent.Text = "Sent";
			this._colPacketSent.Width = 50;
			 
			 
			 
			this._colPacketReceived.Text = "Received";
			 
			 
			 
			this._colPacketReceivedPercent.Text = "Received %";
			this._colPacketReceivedPercent.Width = 74;
			 
			 
			 
			this._colPacketLost.Text = "Lost";
			this._colPacketLost.Width = 50;
			 
			 
			 
			this._colPacketLostPercent.Text = "Lost %";
			this._colPacketLostPercent.Width = 55;
			 
			 
			 
			this._colLastPacketLost.Text = "Last Packet Lost";
			 
			 
			 
			this._colConsecutivePacketsLost.Text = "Consecutive Packets Lost";
			 
			 
			 
			this._colMaxConsecutivePacketsLost.Text = "Max Consecutive Packets Lost";
			 
			 
			 
			this._colRecPacketReceived.Text = "Received (Recent)";
			 
			 
			 
			this._colRecPacketReceivedPercent.Text = "Received % (Recent)";
			 
			 
			 
			this._colRecPacketLost.Text = "Lost (Recent)";
			 
			 
			 
			this._colRecPacketLostPercent.Text = "Lost % (Recent)";
			 
			 
			 
			this._colCurrentResponseTime.Text = "Current R.T.";
			this._colCurrentResponseTime.Width = 70;
			 
			 
			 
			this._colAverageResponseTime.Text = "Average R.T.";
			this._colAverageResponseTime.Width = 70;
			 
			 
			 
			this._colMinResponseTime.Text = "Min Response Time";
			 
			 
			 
			this._colMaxResponseTime.Text = "Max Response Time";
			 
			 
			 
			this._colStatusDuration.Text = "Status Duration";
			this._colStatusDuration.Width = 86;
			 
			 
			 
			this._colAliveStatus.Text = "Alive Status";
			 
			 
			 
			this._colDeadStatus.Text = "Dead Status";
			 
			 
			 
			this._colDnsErrorStatus.Text = "Dns Error Status";
			 
			 
			 
			this._colUnknownStatus.Text = "Unknown Status";
			 
			 
			 
			this._colAvailability.Text = "Host Availability";
			 
			 
			 
			this._colTestDuration.Text = "Test Duration";
			this._colTestDuration.Width = 76;
			 
			 
			 
			this._colCurTestDuration.Text = "Current Test Duration";
			 
			 
			 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(962, 271);
			this.Controls.Add(this._toolbar);
			this.Controls.Add(this._lvHosts);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PingForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MASA - NetPinger 2.0";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PingForm_FormClosing);
			this.Load += new System.EventHandler(this.PingForm_Load);
			this.SizeChanged += new System.EventHandler(this.PingForm_SizeChanged);
			this._notifyIconMenu.ResumeLayout(false);
			this._toolbar.ResumeLayout(false);
			this._toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ColumnHeader _colHostName;
		private System.Windows.Forms.ColumnHeader _colIpAddr;
		private System.Windows.Forms.ColumnHeader _colStatus;
		private System.Windows.Forms.ColumnHeader _colPacketSent;
		private System.Windows.Forms.ColumnHeader _colPacketLost;
		private System.Windows.Forms.ColumnHeader _colPacketLostPercent;
		private System.Windows.Forms.ColumnHeader _colCurrentResponseTime;
		private System.Windows.Forms.ColumnHeader _colAverageResponseTime;
		private System.Windows.Forms.ColumnHeader _colStatusDuration;
		private System.Windows.Forms.ColumnHeader _colTestDuration;
		private System.Windows.Forms.NotifyIcon _notifyIcon;
		private System.Windows.Forms.ContextMenuStrip _notifyIconMenu;
		private System.Windows.Forms.ToolStripMenuItem _nimRestore;
		private System.Windows.Forms.ToolStripMenuItem _nimMaximize;
		private System.Windows.Forms.ToolStripMenuItem _nimMinimize;
		private System.Windows.Forms.ToolStripMenuItem _nimStartAll;
		private System.Windows.Forms.ToolStripMenuItem _nimStopAll;
		private System.Windows.Forms.ToolStripMenuItem _nimExit;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ColumnHeader _colRecPacketReceived;
		private System.Windows.Forms.ColumnHeader _colRecPacketLost;
		private System.Windows.Forms.ColumnHeader _colRecPacketLostPercent;
		private System.Windows.Forms.ColumnHeader _colHostDescription;
		private System.Windows.Forms.ColumnHeader _colPacketReceived;
		private System.Windows.Forms.ColumnHeader _colPacketReceivedPercent;
		private System.Windows.Forms.ColumnHeader _colLastPacketLost;
		private System.Windows.Forms.ColumnHeader _colRecPacketReceivedPercent;
		private System.Windows.Forms.ColumnHeader _colDeadStatus;
		private System.Windows.Forms.ColumnHeader _colAliveStatus;
		private System.Windows.Forms.ColumnHeader _colDnsErrorStatus;
		private System.Windows.Forms.ColumnHeader _colUnknownStatus;
		private System.Windows.Forms.ColumnHeader _colAvailability;
		private System.Windows.Forms.ColumnHeader _colCurTestDuration;
		private ListViewDB _lvHosts;
		private System.Windows.Forms.ToolStripButton _tbStartAll;
		private System.Windows.Forms.ToolStripButton _tbStopAll;
		private System.Windows.Forms.ToolStripButton _tbClearAllStatistics;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton _tbStartHost;
		private System.Windows.Forms.ToolStripButton _tbStopHost;
		private System.Windows.Forms.ToolStripButton _tbClearStatistics;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton _tbAddNewHost;
		private System.Windows.Forms.ToolStripButton _tbHostOptions;
		private System.Windows.Forms.ToolStripButton _tbRemoveHost;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton _tbOptions;
		private System.Windows.Forms.ToolStripButton _tbAbout;
		private System.Windows.Forms.ToolStrip _toolbar;
		private System.Windows.Forms.ToolStripButton _tbSave;
		private System.Windows.Forms.ToolStripButton _tbGraphs;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ColumnHeader _colConsecutivePacketsLost;
		private System.Windows.Forms.ColumnHeader _colMaxConsecutivePacketsLost;
		private System.Windows.Forms.ColumnHeader _colMinResponseTime;
		private System.Windows.Forms.ColumnHeader _colMaxResponseTime;
		private System.Windows.Forms.ToolStripButton _tbDataSeriesOptions;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton _tbIPScan;
		private System.Windows.Forms.ToolStripButton _tbTraceroute;
	}
}

