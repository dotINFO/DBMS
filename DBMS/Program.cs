using System;
using System.Configuration;

namespace DBMS
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var StEn = new StorageEngine.StorageEngine();
				StEn.Start();

			Console.Read ();
		}
	}
}
