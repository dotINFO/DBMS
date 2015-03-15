using System;
using System.IO;
using System.Collections.Generic;

using DBMS.StorageEngine.Utility;


namespace DBMS.StorageEngine
{
	public static class PermanentMemoryManager
	{

		private static string DBDirectoryPath;
		private static Dictionary<int, FileStream> FileStreamFromFileId = new Dictionary<int, FileStream>();


		public static void Start()
		{
			var ExePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

			DBDirectoryPath = Path.Combine (ExePath, "../../../Databases/");

			Console.WriteLine (DBDirectoryPath);

		}

		public static void Stop()
		{
		}

		public static Database CreateDB(string DBName)
		{	
			var DBPath = GetDatabasePath (DBName);

			if (Directory.Exists (DBPath)) {
				Logger.Error("Database " + DBName + " already exists");

				return null;
			}

			Directory.CreateDirectory (DBPath);

			return new Database (DBName);
		}

		public static void RemoveDB(string DBName)
		{
			var DBPath = GetDatabasePath (DBName);

			if (Directory.Exists (DBPath)) {
				Directory.Delete (DBPath);
			} else {
				Logger.Error ("Database " + DBName + " does not exist.");
			}
		}
   		
		public static Pid AddPage(int fileId, string page)
		{
			Logger.Log ("Adding new page to " + fileId);

			FileStream fs;

			if (!FileStreamFromFileId.TryGetValue (fileId, out fs)) {
				Logger.Error ("Could not find the file.");

				/* Sollevare eccezione */
				return null;
			}

			var PageId = GetPageNumber (fileId);
		
			fs.Seek (0, SeekOrigin.End);

			Pid PagePid = new Pid(fileId, PageId);

			WritePage (PagePid, page);

			return PagePid;

		}

		public static String ReadPage(Pid pid)
		{

			char[] PageData = new char[Settings.PAGE_DIMENSION];

			FileStream fs;

			if (!FileStreamFromFileId.TryGetValue (pid.GetFileId (), out fs)) {
				Logger.Error ("Could not find the file.");
			}

			fs.Seek (pid.GetPageId() * Settings.PAGE_DIMENSION, SeekOrigin.Begin);

			using (StreamReader sr = new StreamReader (fs)) {
				sr.Read (PageData, 0, Settings.PAGE_DIMENSION);
			}

			return new String(PageData);
		}

		public static void WritePage(Pid pid, string page)
		{
			FileStream fs;

			if (!FileStreamFromFileId.TryGetValue (pid.GetFileId (), out fs)) {
				Logger.Error ("Could not find the file.");
			}

			fs.Seek (pid.GetPageId() * Settings.PAGE_DIMENSION, SeekOrigin.Begin);

			using (StreamWriter sw = new StreamWriter (fs)) {
				sw.Write (page, 0, Settings.PAGE_DIMENSION);
			}
		}

		public static int GetPageNumber(int fileId)
		{
			FileStream fs;

			if (!FileStreamFromFileId.TryGetValue (fileId, out fs)) {
				Logger.Error ("Could not find the file.");
			}

			return (int) Math.Ceiling ((double) fs.Length / Settings.PAGE_DIMENSION);
		}

		private static string GetDatabasePath(string DBName)
		{
			return DBDirectoryPath + DBName;
		}
	}
}

