using System;

namespace DBMS.StorageEngine
{
	public class Pid
	{

		private int FileIdentifier;
		private int PageIdentifier;

		public Pid (int fileIdentifier, int pageIdentifier)
		{
			this.FileIdentifier = fileIdentifier;
			this.PageIdentifier = pageIdentifier;
		}

		public int GetFileId()
		{
			return this.FileIdentifier;
		}

		public int GetPageId ()
		{
			return this.PageIdentifier;
		}
	}
}

