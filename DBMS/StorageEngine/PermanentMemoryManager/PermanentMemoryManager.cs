using System;
using System.IO;

using DBMS.StorageEngine.Utility;

namespace DBMS.StorageEngine
{
	public static class PermanentMemoryManager
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
			var DBPath = GetDatabasePath (DBName);

			if (Directory.Exists (DBPath)) {
				if (Settings.VERBOSE) {
					Console.WriteLine ("Error: Database " + DBName + " already exists");
				}

				return null;
			}

			var DBDirectory = Directory.CreateDirectory (DBPath);

			return new Database (DBName);
		}

		public static void RemoveDB(string DBName)
		{
			var DBPath = GetDatabasePath (DBName);

			if (Directory.Exists (DBPath)) {
				Directory.Delete (DBPath);
			} else {
				if (Settings.VERBOSE) {
					Console.WriteLine ("Error: Database " + DBName + " does not exist");
				}
			}

		}

		private static string GetDatabasePath(string DBName)
		{
			return DBDirectoryPath + DBName;
		}
	}
}

