
 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using NetUtils;

namespace NetPinger
{
	public delegate void UpdateIPAddressDelegate(IPHostEntry dnsEntry);
	public delegate void ShowErrorDelegate(string error);

	public partial class HostOptions : Form
	{
		public HostOptions()
		{
			InitializeComponent();
		}

		HostPinger _host = null;

		public HostPinger Host
		{
			get { return _host; }
		}

		public DialogResult ShowDialog(IWin32Window owner, HostPinger host)
		{
			_host = host;

			DialogResult res = ShowDialog(owner);
			if (res == DialogResult.OK)
			{
				if (_host == null)
				{
					bool ne = string.IsNullOrEmpty(_tbHostName.Text);
					bool ae = string.IsNullOrEmpty(_tbHostIp.Text);
					try
					{
						if (!ne && ae)
							_host = new HostPinger(_tbHostName.Text);
						else if (ne && !ae)
							_host = new HostPinger(IPAddress.Parse(_tbHostIp.Text));
						else if (!ne && !ae)
							_host = new HostPinger(_tbHostName.Text, IPAddress.Parse(_tbHostIp.Text));

						if (_host != null)
							_host.Logger = DefaultLogger.Instance;

					}
					catch
					{
						_host = null;
						return DialogResult.Cancel;
					}
				}

				_host.HostName = _tbHostName.Text;
				_host.HostDescription = _tbDescription.Text;
				_host.Timeout = (int)_spTimeout.Value;
				_host.PingInterval = (int)_spInterval.Value;
				_host.DnsQueryInterval = (int)_spDnsInterval.Value;
				_host.PingsBeforeDead = (int)_spPingsBeforeDeath.Value;
				_host.RecentHisoryDepth = (int)_spRecentDepth.Value;
				_host.BufferSize = (int)_spBufferSize.Value;
				_host.TTL = (int)_spTtl.Value;
				_host.DontFragment = _chkbDontFragent.Checked;
			}

			return res;
		}

		private void _btnResolve_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(new ParameterizedThreadStart(Resolve));
			thread.Start(_tbHostName.Text);
		}

		private void UpdateIPAddress(IPHostEntry dnsEntry)
		{
			if (InvokeRequired)
			{
				Invoke(new UpdateIPAddressDelegate(UpdateIPAddress), dnsEntry);
				return;
			}

			if (dnsEntry.AddressList.Length > 1)
			{
				ChooseIPForm dlg = new ChooseIPForm();
				if (dlg.ShowDialog(this, dnsEntry.AddressList) == DialogResult.OK)
					_tbHostIp.Text = dlg.SelectedIPAddress.ToString();
			}
			else
				_tbHostIp.Text = dnsEntry.AddressList[0].ToString();
		}

		private void ShowError(string error)
		{
			if (InvokeRequired)
			{
				Invoke(new ShowErrorDelegate(ShowError), error);
				return;
			}

			MessageBox.Show(error, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void Resolve(object name)
		{
			try
			{
				UpdateIPAddress(Dns.GetHostEntry((string)name));
			}
			catch (Exception ex)
			{
				ShowError(ex.Message);
			}
		}

		private void HostOptions_Load(object sender, EventArgs e)
		{
			if (_host != null)
			{
				_tbHostName.Text = _host.HostName;
				_tbHostIp.Text = _host.HostIP.ToString();
				_tbDescription.Text = _host.HostDescription;

				_btnResolve.Enabled = false;
				_tbHostIp.Enabled = false;

				_spTimeout.Value = _host.Timeout;
				_spInterval.Value = _host.PingInterval;
				_spDnsInterval.Value = _host.DnsQueryInterval;
				_spPingsBeforeDeath.Value = _host.PingsBeforeDead;
				_spRecentDepth.Value = _host.RecentHisoryDepth;
				_spBufferSize.Value = _host.BufferSize;
				_spTtl.Value = _host.TTL;
				_chkbDontFragent.Checked = _host.DontFragment;
			}
			else
			{
				_spTimeout.Value = HostPinger.DEFAULT_TIMEOUT;
				_spInterval.Value = HostPinger.DEFAULT_PING_INTERVAL;
				_spDnsInterval.Value = HostPinger.DEFAULT_DNS_QUERY_INTERVAL;
				_spRecentDepth.Value = PingResultsBuffer.DEFAULT_BUFFER_SIZE;
				_spPingsBeforeDeath.Value = HostPinger.DEFALUT_PINGS_BEFORE_DEAD;
				_spBufferSize.Value = HostPinger.DEFAULT_BUFFER_SIZE;
				_spTtl.Value = HostPinger.DEFAULT_TTL;
				_chkbDontFragent.Checked = HostPinger.DEFALUT_FRAGMENT;
			}
		}
	}
}