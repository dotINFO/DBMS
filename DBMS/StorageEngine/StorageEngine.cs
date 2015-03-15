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
			PermanentMemoryManager.CreateDB ("Antani");
			//PMM.RemoveDB ("Antani");
		}


	}
}

