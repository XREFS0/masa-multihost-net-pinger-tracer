using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
 
using System.Threading;

namespace Coolsoft.NetPinger
{
	 

	public partial class Registration : Form
	{

		#region ProxyAddress

		private string _proxyAddress = string.Empty;

		public string ProxyAddress
		{
			get { return _proxyAddress; }
		}

		#endregion

		#region ProxyPort

		private int _proxyPort = 8080;

		public int ProxyPort
		{
			get { return _proxyPort; }
		}

		#endregion

		#region UseProxy

		private bool _useProxy;

		public bool UseProxy
		{
			get { return _useProxy; }
		}

		#endregion

		public Registration()
		{
			InitializeComponent();

			_grpLicenceFile.Enabled = _rbLicenceFile.Checked = false;
			_grpLicenceKey.Enabled = _rbLicenceKey.Checked = false;

			 
		}

		private void _rbLicenceKey_CheckedChanged(object sender, EventArgs e)
		{
			_grpLicenceFile.Enabled = _rbLicenceFile.Checked;
			_grpLicenceKey.Enabled = _rbLicenceKey.Checked;
		}

		private void _rbLicenceFile_CheckedChanged(object sender, EventArgs e)
		{
			_grpLicenceFile.Enabled = _rbLicenceFile.Checked;
			_grpLicenceKey.Enabled = _rbLicenceKey.Checked;
		}

		 

		private void _btnBrowse_Click(object sender, EventArgs e)
		{
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
		}

		private void _lnkRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(_lnkRegistration.Text);
			}
			catch
			{
				MessageBox.Show("Cannot start web browser!");
			}
		}

		private void _lnkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(_lnkDownload.Text);
			}
			catch
			{
				MessageBox.Show("Cannot start web browser!");
			}
		}

		private void _btnProxy_Click(object sender, EventArgs e)
		{
			ProxyOptions dlg = new ProxyOptions();
			dlg.ProxyAddress = _proxyAddress;
			dlg.ProxyPort = _proxyPort;
			dlg.UseProxy = _useProxy;

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				_proxyAddress = dlg.ProxyAddress;
				_proxyPort = dlg.ProxyPort;
				_useProxy = dlg.UseProxy;
			}
		}

		private void _btnHostID_Click(object sender, EventArgs e)
		{
			 
			 
			 
		}

		private void _txtLicenceKey_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!((e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
				(e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
				(e.KeyChar >= '0' && e.KeyChar <= '9') || char.IsControl(e.KeyChar)))
				e.Handled = true;
		}

		private void _btnOK_Click(object sender, EventArgs e)
		{
			 
			 
			 
			 
			 
			 
			 
			 
			 

			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
		}

		RegistrationProcess _registrationProcessDlg = new RegistrationProcess();

		 

		private void ProcessRegistration(object licenceKey)
		{
			 

			 
			 
		}

		private void ProcessLicenceFile(object licenceFile)
		{
			 

			 
			 
		}

		 

		 
		 
		 
		 
		 
		 
		 

		 
		 

		 
		 
		 
		 
		 
		 
		 

		 
		 
		 

		 
		 
		 

		 
		 
		 
		 
		 
		 

	}
}