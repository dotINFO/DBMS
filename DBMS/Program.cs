using System;
using System.Configuration;

namespace DBMS
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ((int)DebugLevel.ERROR_WARNING_LOG);
			var StEn = new StorageEngine.StorageEngine();
				StEn.Start();

			Console.Read ();
		}
	}
}
