using System;
using System.IO;
using System.Collections.Generic;

using DBMS.StorageEngine.Utility;


namespace DBMS.StorageEngine
{
	public static class PermanentMemoryManager
	{

		private static string DBDirectoryPath;
		private static Dictionary<int, FileStream> FileList = new Dictionary<int, FileStream>();


		public static void Start()
		{
			var ExePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

			DBDirectoryPath = Path.Combine (ExePath, "../../../Databases/");

			Console.WriteLine (DBDirectoryPath);

		}

		public static Database CreateDB(string DBName)
		{	
			var DBPath = GetDatabasePath (DBName);

			if (Directory.Exists (DBPath)) {
				Logger.Error("Database " + DBName + " already exists");

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
				Logger.Error("Database " + DBName + " does not exist.");
			}

		}

		public static String ReadPage(Pid pid)
		{

			char[] PageData = new char[Settings.PAGE_DIMENSION];

			FileStream fs;

			if (!FileList.TryGetValue (pid.GetFileId (), out fs)) {
				Logger.Error ("Could not find the file.");
			}

			fs.Seek (pid.GetPageId() * Settings.PAGE_DIMENSION, SeekOrigin.Begin);

			using (StreamReader sr = new StreamReader (fs)) {
				sr.Read (PageData, 0, Settings.PAGE_DIMENSION);
			}

			return new String(PageData);
		}


		private static string GetDatabasePath(string DBName)
		{
			return DBDirectoryPath + DBName;
		}
	}
}

