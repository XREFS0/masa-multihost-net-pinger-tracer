
 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LiveGraph
{
	public partial class AddGraphDlg : Form
	{
		public string GraphName
		{
			get { return _txtGraphName.Text; }
			set { _txtGraphName.Text = value; }
		}

		public long Resolution
		{
			get { return (long)_spnResolution.Value; }
			set { _spnResolution.Value = value / TimeSpan.TicksPerMillisecond; }
		}

		public bool ShowTimeLabels
		{
			get { return _chkShowTime.Checked; }
			set { _chkShowTime.Checked = value; }
		}

		public AddGraphDlg()
		{
			InitializeComponent();

			_spnResolution.Maximum = TimeSpan.TicksPerHour / TimeSpan.TicksPerMillisecond;
			_spnResolution.Value = TimeSpan.TicksPerSecond / TimeSpan.TicksPerMillisecond;
		}

	}
}
