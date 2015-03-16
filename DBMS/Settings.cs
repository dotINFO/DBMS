using System;

namespace DBMS
{
	public static class Settings
	{
		public static DebugLevel DEBUG_LEVEL = DebugLevel.ERROR_WARNING_LOG; 
		public static int BUFFER_POOL_SIZE = 200;
		public static int PAGE_DIMENSION = 1024;


	}

	public enum DebugLevel:int
	{
		NO_LOG,
		ERROR,
		ERROR_WARNING,
		ERROR_WARNING_LOG
	};
}

