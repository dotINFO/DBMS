using System;
using System.Collections.Generic;

namespace DBMS.StorageEngine
{
	public static class BufferManager
	{
		private static FrameDescriptor[] BufferPool = new FrameDescriptor[DBMS.Settings.BUFFER_POOL_SIZE];
		private static Dictionary<Pid, FrameDescriptor> FrameDescriptorFromPid = new Dictionary<Pid, FrameDescriptor> ();

		public static void Start()
		{
			for(int i = 0; i < BufferPool.Length; i++) {
				BufferPool [i] = new FrameDescriptor (i);
			}
		}

		public static void Stop()
		{
			FlushAllPages ();
		}

		public static void GetAndPinPage()
		{


		}

		
		public static void UnpinPage(Pid pid)
		{
			Logger.Log ("Unpinning page " + pid.ToString());

			FrameDescriptor fd;

			if (!FrameDescriptorFromPid.TryGetValue (pid, out fd)) {
				Logger.Error ("Could not find frame descriptor for " + pid.ToString ());
				return;
			}

			fd.PinCount--;
			if (fd.PinCount == 0) {
				
			}

			Logger.Log ("Unpinned page " + pid.ToString() + ", " + fd.PinCount + " pins remaining");
		}

		public static void SetDirty(Pid pid)
		{
			Logger.Log ("Setting dirty to page " + pid.ToString ());

			FrameDescriptor fd;

			if (!FrameDescriptorFromPid.TryGetValue (pid, out fd)) {
				Logger.Error ("Could not find frame descriptor for " + pid.ToString ());
				return;
			}

			fd.Dirty = true;

		}
			
		private static void InvalidatePage()
		{

		}
			
		private static void FlushAllPages()
		{

		}



	}
}

