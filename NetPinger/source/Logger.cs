
 

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NetUtils;

namespace NetPinger
{
	class DefaultLogger : IPingLogger
	{

		#region Private Attributes

		private static readonly string LOG_ROW_FORMAT = "{0,-21}| ({1,-15}) {2,-30} | {3}";

		private StreamWriter _fileWriter;

		#endregion

		#region Instance

		static private object _syncInstance = new object();

		static private DefaultLogger _instance;

		static public DefaultLogger Instance
		{
			get
			{
				lock (_syncInstance)
				{
					if (_instance == null)
						_instance = new DefaultLogger();

					return _instance;

				}
			}
		}

		#endregion

		#region Constructor

		public DefaultLogger()
		{
			_fileWriter = new StreamWriter(
				File.Open(Program.GetAppFilePath("pinger.log"), FileMode.Append, FileAccess.Write, FileShare.Read));
		}

		#endregion

		#region Log

		public void Log(HostPinger host, string message)
		{
			PingForm.NotifyMessage(host, message);

			lock (this)
			{
				_fileWriter.WriteLine(LOG_ROW_FORMAT, DateTime.Now, host.HostIP, host.HostName, message);
				_fileWriter.Flush();
			}
		}

		#endregion

		#region IPingLogger Members

		public void LogStart(HostPinger host)
		{
			Log(host, "Pinging started");
		}

		public void LogStop(HostPinger host)
		{
			Log(host, "Pinging stopped");
		}

		public void LogStatusChange(HostPinger host, HostStatus oldStatus, HostStatus newStatus)
		{
			switch (newStatus)
			{
				case HostStatus.Alive:
					Log(host, "Host is now alive!");
					break;

				case HostStatus.Dead:
					Log(host, "Host died!");
					break;

				case HostStatus.DnsError:
					Log(host, "Host name couldn't be resolved (DNS error)!");
					break;
			}
		}

		#endregion

	}
}
