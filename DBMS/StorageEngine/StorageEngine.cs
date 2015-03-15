using System;
using DBMS.StorageEngine.PermanentMemoryManager;

namespace DBMS.StorageEngine
{
	public class SE
	{
		public SE ()
		{
		}

		public void Start()
		{
			PMM.Initialization ();
			PMM.CreateDB ("Antani");
			//PMM.RemoveDB ("Antani");
		}


	}
}

