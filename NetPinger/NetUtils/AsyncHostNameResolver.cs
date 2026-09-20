
 

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace NetUtils
{
	class AsyncHostNameResolver
	{

		private delegate IPHostEntry GetHostEntryDelegate(string addr);

		private IPHostEntry GetHostEntry(string addr)
		{
			try { return Dns.GetHostEntry(addr); }
			catch { return null; }
		}

		private class AsyncStateUni
		{
			public GetHostEntryDelegate _resolveMethod;
			public AsyncStateUni(GetHostEntryDelegate resolveMethod) { _resolveMethod = resolveMethod; }
		}

		#region ResolveHostName

		public delegate void StoreHostNameDelegate(string hostName);

		private class AsyncStateForName : AsyncStateUni
		{
			public StoreHostNameDelegate _storeResultMethod;
			public AsyncStateForName(GetHostEntryDelegate resolveMethod, StoreHostNameDelegate storeResultMethod) : base(resolveMethod) { _storeResultMethod = storeResultMethod; }
		}

		public void ResolveHostName(IPAddress address, StoreHostNameDelegate callback)
		{
			AsyncStateForName state = new AsyncStateForName(new GetHostEntryDelegate(GetHostEntry), callback);
			state._resolveMethod.BeginInvoke(address.ToString(), new AsyncCallback(HostNameResolved), state);
		}

		private void HostNameResolved(IAsyncResult result)
		{
			try
			{
				AsyncStateForName state = (AsyncStateForName)result.AsyncState;
				IPHostEntry entry = state._resolveMethod.EndInvoke(result);
				if (entry != null)
					state._storeResultMethod(entry.HostName);
			}
			catch { }
		}

		#endregion

		#region ResolveHostIP

		public delegate void StoreHostIPDelegate(IPAddress[] addreses);

		private class AsyncStateForIP : AsyncStateUni
		{
			public StoreHostIPDelegate _storeResultMethod;
			public AsyncStateForIP(GetHostEntryDelegate resolveMethod, StoreHostIPDelegate storeResultMethod) : base(resolveMethod) { _storeResultMethod = storeResultMethod; }
		}

		public void ResolveHostIP(string name, StoreHostIPDelegate callback)
		{
			AsyncStateForIP state = new AsyncStateForIP(new GetHostEntryDelegate(GetHostEntry), callback);
			state._resolveMethod.BeginInvoke(name, new AsyncCallback(HostIPResolved), state);
		}

		private void HostIPResolved(IAsyncResult result)
		{
			try
			{
				AsyncStateForIP state = (AsyncStateForIP)result.AsyncState;
				IPHostEntry entry = state._resolveMethod.EndInvoke(result);
				if(entry != null)
					state._storeResultMethod(entry.AddressList);
			}
			catch { }
		}

		#endregion

	}
}
