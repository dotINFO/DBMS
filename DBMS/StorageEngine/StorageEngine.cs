using System;

namespace DBMS.StorageEngine
{
	public class StorageEngine
	{
		public StorageEngine ()
		{
		}

		public void Start()
		{
			PermanentMemoryManager.Start ();
			BufferManager.Start ();
		}

		public void Stop()
		{
			PermanentMemoryManager.Stop ();
			BufferManager.Stop ();
		}

		public void Prova()
		{
			PermanentMemoryManager.CreateDB ("Antani");
			//PMM.RemoveDB ("Antani");
		}

	}
}

