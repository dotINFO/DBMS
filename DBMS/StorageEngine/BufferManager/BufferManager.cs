using System;

namespace DBMS.StorageEngine
{
	public static class BufferManager
	{
		private static FrameDescriptor[] BufferPool = new FrameDescriptor[DBMS.Settings.BUFFER_POOL_SIZE];

		public static void Start()
		{
			for(int i = 0; i < BufferPool.Length; i++) {
				BufferPool [i] = new FrameDescriptor (i);
			}
		}


		public static void Terminate()
		{
			FlushAllPages ();
		}


		private static void GetAndPinPage()
		{


		}

		private static void FlushAllPages()
		{

		}



	}
}

