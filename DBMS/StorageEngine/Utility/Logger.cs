using System;

namespace DBMS
{
	public static class Logger
	{
		public static void Log(string message)
		{

			if (Settings.DEBUG_LEVEL >= DebugLevel.ERROR_WARNING_LOG) {
				Console.WriteLine ("LOG: " + message);
			}

		}

		public static void Warning(string message)
		{
			if (Settings.DEBUG_LEVEL >= DebugLevel.ERROR_WARNING) {
				Console.WriteLine ("WARNING: " + message);
			}
		}

		public static void Error(string message)
		{
			if (Settings.DEBUG_LEVEL >= DebugLevel.ERROR) {
				Console.WriteLine ("ERROR: " + message);
			}
		}

	}
}

