using System;
using System.IO;

using DBMS.StorageEngine.Utility;

namespace DBMS.StorageEngine.PermanentMemoryManager
{
	public static class PMM
	{
		private static string DBDirectoryPath;

		public static void Initialization()
		{
			var ExePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

			DBDirectoryPath = Path.Combine (ExePath, "../../../Databases/");

			Console.WriteLine (DBDirectoryPath);

		}

		public static Database CreateDB(string DBName)
		{	

			if (File.Exists (DBDirectoryPath + DBName)) {
				return null;
			}

			var DBFile = File.Create (DBDirectoryPath + DBName + ".db");

			return new Database (DBName);
		}

		public static void RemoveDB()
		{

		}
	}
}

