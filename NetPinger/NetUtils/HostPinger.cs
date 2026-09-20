
 

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.NetworkInformation;
using System.Xml;

namespace NetUtils
{

	#region HostStatus

	 
	 
	 
	public enum HostStatus
	{
		 
		 
		 
		Dead,
		 
		 
		 
		Alive,
		 
		 
		 
		DnsError,
		 
		 
		 
		 
		Unknown
	};

	#endregion

	#region HostPinger Events' Delegates

	public delegate void OnPingDelegate(HostPinger host);

	public delegate void OnHostStatusChangeDelegate(HostPinger host,
		HostStatus oldStatus, HostStatus newStatus);

	public delegate void OnHostPingerCommandDelegate(HostPinger host);

	public delegate void OnHostNameChangedDelegate(HostPinger host);

	#endregion

	#region IPingLogger

	/// <summary>
	/// Logs commands issued to host pinger and status changes.
	/// </summary>
	public interface IPingLogger
	{
		/// <summary>
		/// Logs command that starts pinging.
		/// </summary>
		/// <param name="host">host pinger that was started.</param>
		void LogStart(HostPinger host);

		/// <summary>
		/// Logs command that stops pinging.
		/// </summary>
		/// <param name="host">host pinger that was stopped.</param>
		void LogStop(HostPinger host);

		/// <summary>
		/// Logs status change of the host.
		/// </summary>
		/// <param name="host">host whose status has been changed.</param>
		/// <param name="oldStatus">old status of the host.</param>
		/// <param name="newStatus">new status of the host.</param>
		void LogStatusChange(HostPinger host, HostStatus oldStatus, HostStatus newStatus);
	}

	#endregion

	#region PingResultsBuffer

	/// <summary>
	/// Keeps recent history (results of most recent pings).
	/// </summary>
	public class PingResultsBuffer
	{

		#region Entry Class

		/// <summary>
		/// Object of this class represent several combined results that has same values in the recent history buffer.
		/// </summary>
		private class Entry
		{
			/// <summary>
			/// Initializes entry of the recent history buffer.
			/// </summary>
			/// <param name="received">indicates whether the combined results was successfull pings or unresponded pings.</param>
			/// <param name="count">number of combined results.</param>
			public Entry(bool received, int count)
			{
				_received = received;
				_count = count;
			}

			/// <summary>
			/// Indicates whether the combined results was successfull pings or unresponded pings.
			/// </summary>
			public bool _received;

			/// <summary>
			/// Number of combined results.
			/// </summary>
			public int _count;
		}

		#endregion

		#region Private Attributes

		/// <summary>
		/// Entries of recent history buffer
		/// </summary>
		private List<Entry> _buffer = new List<Entry>();

		private object _syncObject = new object();

		#endregion

		#region BufferSize

		/// <summary>
		/// Default number of results stored in the buffer.
		/// </summary>
		public static readonly int DEFAULT_BUFFER_SIZE = 100;

		/// <summary>
		/// Number of results stored in the buffer.
		/// </summary>
		private int _bufferSize = DEFAULT_BUFFER_SIZE;

		/// <summary>
		/// Number of results stored in the buffer. When the new buffer size is smaller then previous 
		/// results that cannot fit the new size are removed from the buffer.
		/// </summary>
		public int BufferSize
		{
			get
			{
				lock (_syncObject)
					return _bufferSize;
			}
			set
			{
				lock (_syncObject)
				{
					if (value < 0)
						value = 0;

					if (value > _bufferSize)
						_bufferSize = value;
					else
					{
						// new buffer size is smaller

						// remove those results that cannot fit new size
						for (int diff = _currentSize - value; diff > 0; )
						{
							Entry e = _buffer[0];

							if (e._count <= diff)
							{
								// entire combined entry cannot fit	new size

								// remove the entry complitely
								_buffer.RemoveAt(0);
								DecCount(e._received, e._count);

								diff -= e._count;
							}
							else
							{
								// only part of the combined entry cannot fit new size

								// remove only some	results from the entry
								e._count -= diff;
								DecCount(e._received, diff);

								diff = 0;
							}
						}

						if (_currentSize > value)
							_currentSize = value;

						_bufferSize = value;
					}
				}
			}
		}

		#endregion

		#region CurrentSize

		/// <summary>
		/// Number of results currently stored in the buffer.
		/// </summary>
		private int _currentSize = 0;

		/// <summary>
		/// Number of results currently stored in the buffer.
		/// </summary>
		public int CurrentSize
		{
			get
			{
				lock (_syncObject)
					return _currentSize;
			}
		}

		#endregion

		#region Statistics

		#region LostCount

		/// <summary>
		/// Number of unresponded pings.
		/// </summary>
		private int _lostCount;

		/// <summary>
		/// Number of unresponded pings.
		/// </summary>
		public int LostCount
		{
			get
			{
				lock (_syncObject)
					return _lostCount;
			}
		}

		#endregion

		#region LostCountPercent

		/// <summary>
		/// Percent of unresponded pings.
		/// </summary>
		public float LostCountPercent
		{
			get
			{
				lock (_syncObject)
					return (float)_lostCount / _currentSize * 100;
			}
		}

		#endregion

		#region ReceivedCount

		/// <summary>
		/// Number of successful pings.
		/// </summary>
		private int _receivedCount;

		/// <summary>
		/// Number of successful pings.
		/// </summary>
		public int ReceivedCount
		{
			get
			{
				lock (_syncObject)
					return _receivedCount;
			}
		}

		#endregion

		#region ReceivedCountPercent

		/// <summary>
		/// Percent of successful pings.
		/// </summary>
		public float ReceivedCountPercent
		{
			get
			{
				lock (_syncObject)
					return (float)_receivedCount / _currentSize * 100;
			}
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes recent history buffer with specified size.
		/// </summary>
		/// <param name="size">Number of results of most recent pings that are stored in the buffer.</param>
		public PingResultsBuffer(int size)
		{
			_bufferSize = size;
		}

		public PingResultsBuffer() { }

		#endregion

		#region Counting

		/// <summary>
		/// Increments number of results od specific type.
		/// </summary>
		/// <param name="received">whether to increment number of successful or unsuccessful ping results.</param>
		private void IncCount(bool received)
		{
			if (received)
				_receivedCount++;
			else
				_lostCount++;
		}

		/// <summary>
		/// Decrements number of results od specific type.
		/// </summary>
		/// <param name="received">whether to increment number of successful or unsuccessful ping results.</param>
		/// <param name="count">number by which the number of results are decremented.</param>
		private void DecCount(bool received, int count)
		{
			if (received)
				_receivedCount -= count;
			else
				_lostCount -= count;
		}

		#endregion

		#region AddPingResult

		/// <summary>
		/// Inserts ping results into recent history buffer.
		/// </summary>
		/// <param name="received">whether the ping was successful or not.</param>
		public void AddPingResult(bool received)
		{
			if (_bufferSize < 1)
				return;

			lock (_syncObject)
			{
				// buffer is not full yet?
				if (_currentSize < _bufferSize)
				{
					if (_currentSize == 0)
					{
						// empty buffer create first entry

						_buffer.Add(new Entry(received, 1));
						IncCount(received);
						_currentSize++;
						return;
					}

					_currentSize++;
				}
				else
				{
					// buffer is full

					// remove the oldes result
					Entry first = _buffer[0];
					first._count--;
					DecCount(first._received, 1);

					// if the last result was occpied entire combined entry
					/// remove that entry
					if (first._count == 0)
						_buffer.RemoveAt(0);
				}

				// insert new result
				Entry last = _buffer[_buffer.Count - 1];
				if (last._received == received)
					// the newest result can be combined with newest combined entry
					last._count++;
				else
					// the newest result cannot be combined with newest combined entry 
					// create new entry and add it tho the buffer
					_buffer.Add(new Entry(received, 1));

				// increment number of results os specific type
				IncCount(received);
			}
		}

		#endregion

		#region Clear

		/// <summary>
		/// Clears results of most recent pings.
		/// </summary>
		public void Clear()
		{
			lock (_syncObject)
			{
				_currentSize = 0;
				_lostCount = 0;
				_receivedCount = 0;
				_buffer.Clear();
			}
		}

		#endregion

	}

	#endregion

	#region HostPinger

	/// <summary>
	/// Stores information about host and ping options, performs pinging, statistical calculations and stors statistics.
	/// </summary>
	public class HostPinger
	{

		#region Public Constants

		/// <summary>
		/// Number of defined host statuses.
		/// </summary>
		public const int NUMBER_OF_STATUSES = 4;

		/// <summary>
		/// Name of XML element that contains data of the host.
		/// </summary>
		public readonly string XML_ELEMENT_NAME_HOST = "host";

		#endregion

		#region ID

		/// <summary>
		/// Name of XML element that stores IP address of the host.
		/// </summary>
		public readonly string XML_ELEMENT_NAME_ID = "id";

		/// <summary>
		/// ID of the host that is automatically assigned.
		/// </summary>
		private int _id;

		/// <summary>
		/// ID of the host that is automatically assigned.
		/// </summary>
		public int ID
		{
			get { return _id; }
		}

		/// <summary>
		/// Protects ID assigning process from concurent access.
		/// </summary>
		private static object _idLock = new object();

		/// <summary>
		/// ID that will be assigned to new host.
		/// </summary>
		private static int _nextID;

		/// <summary>
		/// Assigns ID to the host automatically.
		/// </summary>
		private void AssignID()
		{
			lock (_idLock)
				_id = _nextID++;
		}

		/// <summary>
		/// Updates ID tracker with ID of loaded host.
		/// </summary>
		/// <param name="id">ID of loaded host.</param>
		private static void UpdateIDTrack(int id)
		{
			lock (_idLock)
			{
				if (_nextID <= id)
					_nextID = id + 1;
			}
		}

		#endregion

		#region Host Infromation

		#region IPAddres

		/// <summary>
		/// Name of XML element that stores IP address of the host.
		/// </summary>
		public readonly string XML_ELEMENT_NAME_HOST_IP = "ip";

		/// <summary>
		/// Host's IP address.
		 
		private IPAddress _hostIP;

		 
		 
		 
		public IPAddress HostIP
		{
			get
			{
				lock (_syncObject)
					return _hostIP != null ? _hostIP : new IPAddress(0);
			}
			set
			{
				lock (_syncObject)
				{
					_hostIP = value;

					 
					if (_status == HostStatus.DnsError)
						Status = HostStatus.Unknown;
				}
			}
		}

		#endregion

		#region HostName

		 
		 
		 
		public readonly string XML_ELEMENT_NAME_HOST_NAME = "name";

		 
		 
		 
		private string _hostName = string.Empty;

		 
		 
		 
		public string HostName
		{
			get
			{
				lock (_syncObject)
					return _hostName;
			}
			set
			{
				lock (_syncObject)
					_hostName = value;
			}
		}

		#endregion

		#region HostDescription

		 
		 
		 
		public readonly string XML_ELEMENT_NAME_HOST_DESCRIPTION = "description";

		 
		 
		 
		private string _hostDescription = string.Empty;

		 
		 
		 
		public string HostDescription
		{
			get
			{
				lock (_syncObject)
					return _hostDescription;
			}
			set
			{
				lock (_syncObject)
					_hostDescription = value;
			}
		}

		#endregion

		#endregion

		#region Status

		 
		 
		 
		private HostStatus _status = HostStatus.Unknown;

		 
		 
		 
		public HostStatus Status
		{
			get
			{
				lock (_syncObject)
					return _isRunning ? _status : HostStatus.Unknown;
			}

			private set
			{
				 
				if (_status == value && _status != HostStatus.Unknown)
					 
					return;

				DateTime now = DateTime.Now;

				 
				TimeSpan duration = now - _statusReachedAt;

				 
				if (_isRunning)
					_statusDurations[(int)_status] += duration;

				 
				_statusReachedAt = now;

				HostStatus old = _status;
				_status = value;

				 
				ThreadPool.QueueUserWorkItem(new WaitCallback(RaiseOnStatusChange),
					new OnHostStatusChangeParams(old, _status));
			}
		}

		 
		 
		 
		public string StatusName
		{
			get
			{
				HostStatus status = Status;
				switch (status)
				{
					case HostStatus.Dead:
						return "Dead";
					case HostStatus.Alive:
						return "Alive";
					case HostStatus.DnsError:
						return "Dns Error";
				}

				return "Unknown";
			}
		}

		#endregion

		#region Statistics

		#region Counting Statistics

		private int _continousPacketLost = 0;

		#region SentPakets

		private int _sentPackets;

		public int SentPackets
		{
			get
			{
				lock (_syncObject)
					return _sentPackets;
			}
		}

		#endregion

		#region ReceivedPackets

		private int _receivedPackets;

		public int ReceivedPackets
		{
			get
			{
				lock (_syncObject)
					return _receivedPackets;
			}
		}

		#endregion

		#region ReceivedPacketsPercent

		public float ReceivedPacketsPercent
		{
			get
			{
				lock (_syncObject)
					return (float)_receivedPackets / _sentPackets * 100;
			}
		}

		#endregion

		#region LostPackets

		private int _lostPackets;

		public int LostPackets
		{
			get
			{
				lock (_syncObject)
					return _lostPackets;
			}
		}

		#endregion

		#region LostPacketsPercent

		public float LostPacketsPercent
		{
			get
			{
				lock (_syncObject)
					return (float)_lostPackets / _sentPackets * 100;
			}
		}

		#endregion

		#region LastPacketLost

		private bool _lastPacketLost = false;

		public bool LastPacketLost
		{
			get
			{
				lock (_syncObject)
					return _lastPacketLost;
			}
		}

		#endregion

		#region ConsecutivePacketsLost

		private int _consecutivePacketsLost;

		public int ConsecutivePacketsLost
		{
			get
			{
				lock (_syncObject)
					return _consecutivePacketsLost;
			}
		}

		#endregion

		#region MaxConsecutivePacketsLost

		private int _maxConsecutivePacketsLost = 0;

		public int MaxConsecutivePacketsLost
		{
			get
			{
				lock (_syncObject)
					return _maxConsecutivePacketsLost;
			}
		}

		#endregion

		#region Recent History

		#region RecentlyReceivedPackets

		public int RecentlyReceivedPackets
		{
			get
			{
				lock (_syncObject)
					return _recentHistory.ReceivedCount;
			}
		}

		#endregion

		#region RecentlyReceivedPacketsPercent

		public float RecentlyReceivedPacketsPercent
		{
			get
			{
				lock (_syncObject)
					return _recentHistory.ReceivedCountPercent;
			}
		}

		#endregion

		#region RecentlyLostPackets

		public int RecentlyLostPackets
		{
			get
			{
				lock (_syncObject)
					return _recentHistory.LostCount;
			}
		}

		#endregion

		#region RecentlyLostPacketsPercent

		public float RecentlyLostPacketsPercent
		{
			get
			{
				lock (_syncObject)
					return _recentHistory.LostCountPercent;
			}
		}

		#endregion

		#endregion

		#endregion

		#region Time Statistics

		#region CurrentResponseTime

		 
		 
		 
		private long _currentResponseTime;

		 
		 
		 
		public long CurrentResponseTime
		{
			get
			{
				lock (_syncObject)
					return _currentResponseTime;
			}
		}

		#endregion

		#region AverageResponseTime

		 
		 
		 
		private long _totalResponseTime = 0;

		 
		 
		 
		public float AverageResponseTime
		{
			get
			{
				lock (_syncObject)
					return _receivedPackets != 0 ? (float)_totalResponseTime / _receivedPackets : 0;
			}
		}

		#endregion

		#region MinResponseTime

		private long _minResponseTime = long.MaxValue;

		public long MinResponseTime
		{
			get
			{
				lock (_syncObject)
					return _minResponseTime;
			}
		}

		#endregion

		#region MaxResponseTime

		private long _maxResponseTime = 0;

		public long MaxResponseTime
		{
			get
			{
				lock (_syncObject)
					return _maxResponseTime;
			}
		}

		#endregion

		#region CurrentStatusDuration

		 
		 
		 
		private DateTime _statusReachedAt = DateTime.Now;

		 
		 
		 
		public TimeSpan CurrentStatusDuration
		{
			get
			{
				lock (_syncObject)
					return DateTime.Now.Subtract(_statusReachedAt);
			}
		}

		#endregion

		#region StatusDurations

		 
		 
		 
		private TimeSpan[] _statusDurations = new TimeSpan[NUMBER_OF_STATUSES];

		 
		 
		 
		 
		 
		public TimeSpan GetStatusDuration(HostStatus status)
		{
			lock (_syncObject)
			{
				TimeSpan duration = _statusDurations[(int)status];
				if (_status == status && _isRunning)
					duration += DateTime.Now - _statusReachedAt;

				return duration;
			}
		}

		#endregion

		#region HostAvailability

		 
		 
		 
		public float HostAvailability
		{
			get
			{
				lock (_syncObject)
				{
					 
					long total = _totalTestDuration.Ticks;

					 
					long available = _statusDurations[(int)HostStatus.Alive].Ticks;

					 
					if (_isRunning)
					{
						DateTime now = DateTime.Now;

						 
						total += now.Subtract(_startTime).Ticks;

						 
						if (_status == HostStatus.Alive)
							available += (now - _statusReachedAt).Ticks;
					}

					 
					return (float)((double)available / total * 100);
				}
			}
		}

		#endregion

		#region Test Durations

		 
		 
		 
		private DateTime _startTime = DateTime.Now;

		#region CurrentTestDuration

		 
		 
		 
		public TimeSpan CurrentTestDuration
		{
			get
			{
				lock (_syncObject)
				{
					return _isRunning ? DateTime.Now.Subtract(_startTime) : new TimeSpan(0);
				}
			}
		}

		#endregion

		#region TotalTestDuration

		 
		 
		 
		private TimeSpan _totalTestDuration;

		 
		 
		 
		public TimeSpan TotalTestDuration
		{
			get
			{
				lock (_syncObject)
				{
					return _isRunning
						? _totalTestDuration + DateTime.Now.Subtract(_startTime)
						: _totalTestDuration;
				}
			}
		}

		#endregion

		#endregion

		#endregion

		#region Counting

		 
		 
		 
		private void IncLost()
		{
			_sentPackets++;
			_lostPackets++;
			_consecutivePacketsLost++;
			_lastPacketLost = true;

			if (_consecutivePacketsLost > _maxConsecutivePacketsLost)
				_maxConsecutivePacketsLost = _consecutivePacketsLost;

			_recentHistory.AddPingResult(false);

			 
			if (++_continousPacketLost > _pingsBeforeDead && _status != HostStatus.Dead)
				Status = HostStatus.Dead;
		}

		 
		 
		 
		 
		private void IncReceived(long time)
		{
			_sentPackets++;
			_receivedPackets++;
			_consecutivePacketsLost = 0;
			_lastPacketLost = false;

			_recentHistory.AddPingResult(true);

			_totalResponseTime += time;
			_currentResponseTime = time;

			if (time > _maxResponseTime)
				_maxResponseTime = time;

			if (time < _minResponseTime)
				_minResponseTime = time;

			 
			_continousPacketLost = 0;

			if (_status != HostStatus.Alive)
				Status = HostStatus.Alive;
		}

		#endregion

		#region ClearStatistics

		 
		 
		 
		 
		 
		public void ClearStatistics(bool clearTimes)
		{
			lock (_syncObject)
			{
				_sentPackets = 0;
				_receivedPackets = 0;
				_lostPackets = 0;
				_currentResponseTime = 0;
				_totalResponseTime = 0;
				_minResponseTime = long.MaxValue;
				_maxResponseTime = 0;
				_continousPacketLost = 0;
				_consecutivePacketsLost = 0;
				_maxConsecutivePacketsLost = 0;
				_lastPacketLost = false;

				_recentHistory.Clear();

				if (clearTimes)
				{
					_statusReachedAt = DateTime.Now;
					_startTime = DateTime.Now;

					for (int i = _statusDurations.Length - 1; i >= 0; i--)
						_statusDurations[i] = new TimeSpan(0);
				}
			}
		}

		#endregion

		#endregion

		#region Options

		#region TTL

		 
		 
		 
		public readonly string XML_ELEMENT_NAME_TTL = "ttl";

		 
		 
		 
		public static readonly int DEFAULT_TTL = 32;

		 
		 
		 
		private int _ttl = DEFAULT_TTL;

		 
		 
		 
		public int TTL
		{
			get
			{
				lock (_syncObject)
					return _ttl;
			}
			set
			{
				lock (_syncObject)
				{
					if (value > 0 && value != _ttl)
					{
						_ttl = value;
						_pingerOptions.Ttl = value;
					}
				}
			}
		}

		#endregion

		#region DontFragment

		 
		 
		 
		public readonly string XML_ELEMENT_NAME_FRAGMENT = "dontfragment";

		 
		 
		 
		public static readonly bool DEFALUT_FRAGMENT = false;

		 
		 
		 
		private bool _dontFragment;

		 
		 
		 
		public bool DontFragment
		{
			get
			{
				lock (_syncObject)
					return _dontFragment;
			}
			set
			{
				lock (_syncObject)
				{
					if (value != _dontFragment)
					{
						_dontFragment = value;
						_pingerOptions.DontFragment = value;
					}
				}
			}
		}

		#endregion

		#region BufferSize

		 
		 
		 
		public readonly string XML_ELEMENT_NAME_BUFFER_SIZE = "buffersize";

		 
		 
		 
		public static readonly int DEFAULT_BUFFER_SIZE = 32;

		 
		 
		 
		private int _bufferSize = DEFAULT_BUFFER_SIZE;

		 
		 
		 
		public int BufferSize
		{
			get
			{
				lock (_syncObject)
					return _bufferSize;
			}
			set
			{
				lock (_syncObject)
				{
					if (value > 0)
					{
						_bufferSize = value;
						_buffer = new byte[value];
					}
				}
			}
		}

		#endregion

		#region Timeout

		 
		 
		 
		public readonly string XML_ELEMENT_NAME_TIMEOUT = "timeout";

		 
		 
		 
		public static readonly int DEFAULT_TIMEOUT = 2000;

		 
		 
		 
		private int _timeout = DEFAULT_TIMEOUT;

		 
		 
		 
		public int Timeout
		{
			get
			{
				lock (_syncObject)
					return _timeout;
			}
			set
			{
				lock (_syncObject)
					_timeout = value;
			}
		}


		#endregion

		#region PingInterval

		 
		 
		 
		 
		public readonly string XML_ELEMENT_NAME_PING_INTERVAL = "interval";

		 
		 
		 
		 
		public static readonly int DEFAULT_PING_INTERVAL = 1000;

		 
		 
		 
		private int _pingInterval = DEFAULT_PING_INTERVAL;

		 
		 
		 
		public int PingInterval
		{
			get
			{
				lock (_syncObject)
					return _pingInterval;
			}
			set
			{
				lock (_syncObject)
					_pingInterval = value;
			}
		}

		#endregion

		#region DnsQueryInterval

		 
		 
		 
		public readonly string XML_ELEMENT_NAME_DNS_QUERY_INTERVAL = "dnsinterval";

		 
		 
		 
		 
		public static readonly int DEFAULT_DNS_QUERY_INTERVAL = 60000;

		 
		 
		 
		private int _dnsQueryInterval = DEFAULT_DNS_QUERY_INTERVAL;

		 
		 
		 
		public int DnsQueryInterval
		{
			get
			{
				lock (_syncObject)
					return _dnsQueryInterval;
			}

			set
			{
				lock (_syncObject)
					_dnsQueryInterval = value;
			}
		}

		#endregion

		#region PingsBeforeDead

		 
		 
		 
		public readonly string XML_ELEMENT_NAME_PINGS_BEFORE_DEAD = "pingsbeforedead";

		 
		 
		 
		public static readonly int DEFALUT_PINGS_BEFORE_DEAD = 10;

		 
		 
		 
		private int _pingsBeforeDead = DEFALUT_PINGS_BEFORE_DEAD;

		 
		 
		 
		public int PingsBeforeDead
		{
			get
			{
				lock (_syncObject)
					return _pingsBeforeDead;
			}
			set
			{
				lock (_syncObject)
					_pingsBeforeDead = value;
			}
		}

		#endregion

		#region RecentHisoryDepth

		 
		 
		 
		public readonly string XML_ELEMENT_NAME_RECENT_HISTORY_DEPTH = "recenthistorydepth";

		 
		 
		 
		public int RecentHisoryDepth
		{
			get
			{
				lock (_syncObject)
					return _recentHistory.BufferSize;
			}

			set
			{
				lock (_syncObject)
					_recentHistory.BufferSize = value;
			}
		}

		#endregion

		#endregion

		#region Private Attributes

		 
		 
		 
		byte[] _buffer = new byte[DEFAULT_BUFFER_SIZE];

		 
		 
		 
		System.Timers.Timer _timer = new System.Timers.Timer();

		 
		 
		 
		Ping _pinger = new Ping();

		 
		 
		 
		PingOptions _pingerOptions = new PingOptions(DEFAULT_TTL, DEFALUT_FRAGMENT);

		 
		 
		 
		private PingResultsBuffer _recentHistory = new PingResultsBuffer();

		#region Synchronization Object

		object _syncObject = new object();

		#endregion

		#endregion

		#region Logger

		 
		 
		 
		private IPingLogger _logger = null;

		 
		 
		 
		public IPingLogger Logger
		{
			get
			{
				lock (_syncObject)
					return _logger;
			}
			set
			{
				lock (_syncObject)
					_logger = value;
			}
		}

		#endregion

		#region Events

		#region OnPing

		 
		 
		 
		public event OnPingDelegate OnPing;

		 
		 
		 
		private void RaiseOnPing()
		{
			if (OnPing != null)
				OnPing(this);
		}

		#endregion

		#region OnStatusChange

		#region OnHostStatusChangeParams

		 
		 
		 
		private class OnHostStatusChangeParams
		{
			 
			 
			 
			public HostStatus _oldState;

			 
			 
			 
			public HostStatus _newState;

			 
			 
			 
			 
			 
			public OnHostStatusChangeParams(HostStatus oldStatus, HostStatus newStatus)
			{
				_oldState = oldStatus;
				_newState = newStatus;
			}
		}

		#endregion

		 
		 
		 
		public event OnHostStatusChangeDelegate OnStatusChange;

		 
		 
		 
		 
		private void RaiseOnStatusChange(object param)
		{
			OnHostStatusChangeParams p = (OnHostStatusChangeParams)param;

			 
			if (_logger != null)
				_logger.LogStatusChange(this, p._oldState, p._newState);

			if (OnStatusChange != null)
				OnStatusChange(this, p._oldState, p._newState);
		}

		#endregion

		#region OnStartPinging

		 
		 
		 
		public event OnHostPingerCommandDelegate OnStartPinging;

		 
		 
		 
		private void RaiseOnStartPinging()
		{
			 
			if (_logger != null)
				_logger.LogStart(this);

			if (OnStartPinging != null)
				OnStartPinging(this);
		}

		#endregion

		#region OnStopPinging

		 
		 
		 
		public event OnHostPingerCommandDelegate OnStopPinging;

		 
		 
		 
		private void RaiseOnStopPinging()
		{
			 
			if (_logger != null)
				_logger.LogStop(this);

			if (OnStopPinging != null)
				OnStopPinging(this);
		}

		#endregion

		#region OnHostNameChanged

		 
		 
		 
		public event OnHostNameChangedDelegate OnHostNameChanged;

		 
		 
		 
		private void RaiseOnHostNameChanged()
		{
			if (OnHostNameChanged != null)
				OnHostNameChanged(this);
		}

		#endregion

		#endregion

		#region Constructors

		 
		 
		 
		public HostPinger()
		{
			AssignID();

			_hostIP = new IPAddress(new byte[] { 127, 0, 0, 1 });
			_hostName = "localhost";
		}

		 
		 
		 
		 
		public HostPinger(XmlNode xmlNode)
		{
			if (xmlNode[XML_ELEMENT_NAME_ID] != null)
			{
				_id = int.Parse(xmlNode[XML_ELEMENT_NAME_ID].InnerText);
				UpdateIDTrack(_id);
			}
			else
				AssignID();

			if (xmlNode[XML_ELEMENT_NAME_HOST_NAME] != null)
				HostName = xmlNode[XML_ELEMENT_NAME_HOST_NAME].InnerText;
			else
				HostName = "No Name";

			if (xmlNode[XML_ELEMENT_NAME_HOST_IP] != null)
				HostIP = IPAddress.Parse(xmlNode[XML_ELEMENT_NAME_HOST_IP].InnerText);
			else
			{
				try
				{
					_hostIP = GetHostIpByName(_hostName);
				}
				catch
				{
					Status = HostStatus.DnsError;
				}
			}

			if (xmlNode[XML_ELEMENT_NAME_HOST_DESCRIPTION] != null)
				HostDescription = xmlNode[XML_ELEMENT_NAME_HOST_DESCRIPTION].InnerText;

			if (xmlNode[XML_ELEMENT_NAME_TIMEOUT] != null)
				Timeout = int.Parse(xmlNode[XML_ELEMENT_NAME_TIMEOUT].InnerText);

			if (xmlNode[XML_ELEMENT_NAME_PING_INTERVAL] != null)
				PingInterval = int.Parse(xmlNode[XML_ELEMENT_NAME_PING_INTERVAL].InnerText);

			if (xmlNode[XML_ELEMENT_NAME_DNS_QUERY_INTERVAL] != null)
				DnsQueryInterval = int.Parse(xmlNode[XML_ELEMENT_NAME_DNS_QUERY_INTERVAL].InnerText);

			if (xmlNode[XML_ELEMENT_NAME_PINGS_BEFORE_DEAD] != null)
				PingsBeforeDead = int.Parse(xmlNode[XML_ELEMENT_NAME_PINGS_BEFORE_DEAD].InnerText);

			if (xmlNode[XML_ELEMENT_NAME_BUFFER_SIZE] != null)
				BufferSize = int.Parse(xmlNode[XML_ELEMENT_NAME_BUFFER_SIZE].InnerText);

			if (xmlNode[XML_ELEMENT_NAME_RECENT_HISTORY_DEPTH] != null)
				RecentHisoryDepth = int.Parse(xmlNode[XML_ELEMENT_NAME_RECENT_HISTORY_DEPTH].InnerText);

			if (xmlNode[XML_ELEMENT_NAME_TTL] != null)
				TTL = int.Parse(xmlNode[XML_ELEMENT_NAME_TTL].InnerText);

			if (xmlNode[XML_ELEMENT_NAME_FRAGMENT] != null)
				DontFragment = bool.Parse(xmlNode[XML_ELEMENT_NAME_FRAGMENT].InnerText);

			InitTimer();
		}

		 
		 
		 
		 
		public HostPinger(string hostName)
		{
			AssignID();

			_hostName = hostName;

			try
			{
				_hostIP = GetHostIpByName(_hostName);
			}
			catch
			{
				Status = HostStatus.DnsError;
			}

			InitTimer();
		}

		 
		 
		 
		 
		public HostPinger(IPAddress address)
		{
			AssignID();

			_hostName = "No Name";
			_hostIP = address;

			InitTimer();
		}

		 
		 
		 
		 
		 
		public HostPinger(string hostName, IPAddress address)
		{
			AssignID();

			_hostName = hostName;
			_hostIP = address;

			InitTimer();
		}

		 
		 
		 
		 
		 
		private IPAddress GetHostIpByName(string name)
		{
			IPHostEntry dnse;
			try
			{
				dnse = Dns.GetHostEntry(_hostName);
			}
			catch (Exception ex)
			{
				throw new Exception("Error connecting DNS for " + _hostName + " host", ex);
			}

			if (dnse != null)
				return dnse.AddressList[0];
			else
				throw new Exception("Cannot resolve host \"" + _hostName + "\" IP by its name.");
		}

		#endregion

		#region Save

		 
		 
		 
		 
		public delegate void AdditionalSettingsSave(XmlWriter writer);

		 
		 
		 
		 
		 
		public void Save(XmlWriter writer, AdditionalSettingsSave additionalSettings)
		{
			writer.WriteStartElement(XML_ELEMENT_NAME_HOST);

			lock (_syncObject)
			{
				writer.WriteElementString(XML_ELEMENT_NAME_HOST_NAME, _hostName);
				if (_hostIP != null)
					writer.WriteElementString(XML_ELEMENT_NAME_HOST_IP, _hostIP.ToString());
				writer.WriteElementString(XML_ELEMENT_NAME_HOST_DESCRIPTION, _hostDescription);
				writer.WriteElementString(XML_ELEMENT_NAME_TIMEOUT, _timeout.ToString());
				writer.WriteElementString(XML_ELEMENT_NAME_PING_INTERVAL, _pingInterval.ToString());
				writer.WriteElementString(XML_ELEMENT_NAME_DNS_QUERY_INTERVAL, _dnsQueryInterval.ToString());
				writer.WriteElementString(XML_ELEMENT_NAME_PINGS_BEFORE_DEAD, _pingsBeforeDead.ToString());
				writer.WriteElementString(XML_ELEMENT_NAME_RECENT_HISTORY_DEPTH, _recentHistory.BufferSize.ToString());
				writer.WriteElementString(XML_ELEMENT_NAME_BUFFER_SIZE, _bufferSize.ToString());
				writer.WriteElementString(XML_ELEMENT_NAME_TTL, _ttl.ToString());
				writer.WriteElementString(XML_ELEMENT_NAME_FRAGMENT, _dontFragment.ToString());

				if (additionalSettings != null)
					additionalSettings(writer);
			}

			writer.WriteEndElement();
		}

		 
		 
		 
		 
		public void Save(XmlWriter writer) { Save(writer, null); }

		#endregion

		#region Timer

		 
		 
		 
		void InitTimer()
		{
			_timer.AutoReset = false;
			_timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
		}

		 
		 
		 
		 
		 
		void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Pinger();
		}

		#endregion

		#region Control

		#region IsRunning

		 
		 
		 
		private bool _isRunning;

		 
		 
		 
		public bool IsRunning
		{
			get
			{
				lock (_syncObject)
					return _isRunning;
			}

			set
			{
				if (value)
					Start();
				else
					Stop();
			}
		}

		#endregion

		 
		 
		 
		public void Start()
		{
			bool started = false;
			Monitor.Enter(_syncObject);
			if (!_isRunning)
			{
				 
				_startTime = DateTime.Now;

				if (_status != HostStatus.DnsError)
					Status = HostStatus.Unknown;

				started = _isRunning = true;

				 
				if (!_pingScheduled)
				{
					_pingScheduled = true;
					_timer.Interval = _pingInterval;
					_timer.Start();
				}
			}
			Monitor.Exit(_syncObject);

			if (started)
				RaiseOnStartPinging();
		}

		 
		 
		 
		public void Stop()
		{
			bool stopped = false;

			lock (_syncObject)
			{
				if (_isRunning)
				{
					_continousPacketLost = 0;

					if (_status != HostStatus.DnsError)
						Status = HostStatus.Unknown;

					_totalTestDuration += DateTime.Now - _startTime;

					_isRunning = false;
					stopped = true;
				}
			}

			if (stopped)
				RaiseOnStopPinging();
		}

		#endregion

		#region Pinging

		 
		 
		 
		private bool _pingScheduled = false;

		 
		 
		 
		private void Pinger()
		{
			bool ping;

			lock (_syncObject)
				 
				ping = _status != HostStatus.DnsError;

			 
			if (!ping)
			{
				try
				{
					 
					IPAddress addr = GetHostIpByName(HostName);

					lock (_syncObject)
					{
						 
						if (_status == HostStatus.DnsError && _isRunning)
						{
							_hostIP = addr;
							Status = HostStatus.Unknown;
						}
					}
				}
				catch
				{
					 
					lock (_syncObject)
					{
						if (_isRunning)
						{
							 
							_pingScheduled = true;
							_timer.Interval = _dnsQueryInterval;
							_timer.Start();
						}
						else
							_pingScheduled = false;
					}

					RaiseOnPing();
					return;
				}
			}

			PingReply reply;

			IPAddress ip;
			int timeout;
			byte[] buffer;
			PingOptions options;

			lock (_syncObject)
			{
				 
				ip = _hostIP;
				timeout = _timeout;
				buffer = _buffer;
				options = _pingerOptions;
			}

			 
			reply = _pinger.Send(ip, timeout, buffer, options);

			lock (_syncObject)
			{
				ping = false;

				if (_isRunning)
				{
					if (ip == _hostIP)
					{
						switch (reply.Status)
						{
							#region Checking Reply Status

							case IPStatus.BadDestination:
							case IPStatus.BadHeader:
							case IPStatus.BadOption:
							case IPStatus.BadRoute:
							case IPStatus.UnrecognizedNextHeader:
							case IPStatus.PacketTooBig:
							case IPStatus.ParameterProblem:
								 
								IncLost();
								break;

							case IPStatus.DestinationScopeMismatch:
							case IPStatus.Unknown:
							case IPStatus.HardwareError:
							case IPStatus.IcmpError:
							case IPStatus.NoResources:
							case IPStatus.SourceQuench:
								 
								IncLost();
								break;

							case IPStatus.DestinationHostUnreachable:
							case IPStatus.DestinationNetworkUnreachable:
							case IPStatus.DestinationPortUnreachable:
							case IPStatus.DestinationProhibited:
							case IPStatus.DestinationUnreachable:
								 
								IncLost();
								break;

							case IPStatus.TimeExceeded:
							case IPStatus.TimedOut:
							case IPStatus.TtlExpired:
							case IPStatus.TtlReassemblyTimeExceeded:
								 
								IncLost();
								break;

							case IPStatus.Success:
								 
								IncReceived(reply.RoundtripTime);
								break;

							default:
								 
								IncLost();
								break;

							#endregion
						}

						ping = true;
					}

					 
					_pingScheduled = true;
					_timer.Interval = _pingInterval;
					_timer.Start();
				}
				else
					_pingScheduled = false;
			}

			if (ping)
				RaiseOnPing();
		}

		#endregion

	}

	#endregion

}
