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
			PermanentMemoryManager.Initialization ();
			PermanentMemoryManager.CreateDB ("Antani");
			//PMM.RemoveDB ("Antani");
		}


	}
}

