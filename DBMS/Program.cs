using System;
using System.Configuration;
using DBMS.StorageEngine;

namespace DBMS
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var StEn = new SE ();
				StEn.Start();

			Console.Read ();
		}
	}
}
