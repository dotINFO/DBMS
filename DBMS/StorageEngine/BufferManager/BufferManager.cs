using System;
using System.Collections.Generic;

namespace DBMS.StorageEngine
{
	/** The data page requests are handled by the Buffer Manager, which
		transfers the request to the Permanent Memory Manager only if the page is not
		already in the buffer pool. The pages in use are pinned and cannot be removed
		from the buffer pool. The modified pages are considered dirty and, when they are
		not pinned, they are written back to the permanent memory.
	*/
	public static class BufferManager
	{

		private static FrameDescriptor[] BufferPool = new FrameDescriptor[DBMS.Settings.BUFFER_POOL_SIZE];
		/** A hash resident pages table, called directory, used to know if a permanent memory page,
		 **	with a given page identifier PID, is in the buffer pool, and which frame
		 **	contains it.
		  */
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

		/** When the requestor of a page releases the page no longer needed,
		 **	it asks the buffer manager to unpin it, so that the frame containing the page 
		 **	can be reused if the pin count becomes 0.
		*/
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

		/** If the requestor modifies a page, it asks the buffer manager to set the
			dirty bit of the frame.
		*/
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


		public static void FlushPage(Pid pid)
		{
			Logger.Log ("Flushing " + pid.ToString());

			FrameDescriptor fd;

			if (!FrameDescriptorFromPid.TryGetValue (pid, out fd)) {
				Logger.Error ("Could not find frame descriptor for " + pid.ToString ());
				return;
			}

			fd.Dirty = false;
			PermanentMemoryManager.WritePage (pid, fd.Page.ToString());
		}

		public static void FlushAllPages()
		{
			Logger.Log ("Flushing all pages.");

			foreach (Pid pid in FrameDescriptorFromPid.Keys) {
				FlushPage (pid);
			}
		}
	}
}

