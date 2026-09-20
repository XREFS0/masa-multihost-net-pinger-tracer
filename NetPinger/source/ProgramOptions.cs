
 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetPinger
{
	public partial class ProgramOptions : Form
	{
		public ProgramOptions()
		{
			InitializeComponent();

			_cbStartWithWindows.Checked = Options.Instance.StartWithWindows;
			_cbShowErrorMessages.Checked = Options.Instance.ShowErrorMessages;
			_cbStartPinging.Checked = Options.Instance.StartPingingOnProgramStart;
			_cbClearTimes.Checked = Options.Instance.ClearTimeStatistics;
		}

		public CheckedListBox SelectedColumns
		{
			get { return _clColumns; }
		}

		public bool StartWithWindows
		{
			get { return _cbStartWithWindows.Checked; }
		}

		public bool ShowErrorMessages
		{
			get { return _cbShowErrorMessages.Checked; }
		}

		public bool StartPingingOnProgramStart
		{
			get { return _cbStartPinging.Checked; }
		}

		public bool ClearTimeStatistics
		{
			get { return _cbClearTimes.Checked; }
		}

	}
}