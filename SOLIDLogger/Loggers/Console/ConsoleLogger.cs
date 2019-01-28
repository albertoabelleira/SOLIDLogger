/*
 * Created by SharpDevelop.
 * User: alberto.abelleira
 * Date: 30/11/2018
 * Time: 9:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SOLIDLogger.Loggers.ConsoleLog
{
	/// <summary>
	/// Description of ConsoleLogger.
	/// </summary>
	public class DefaultConsoleLogger : ILoggable, IActivable
	{
		readonly string _format = "[{0}] [{1}] [{2}] [{3}]";
		// [TIME] [TYPE] [USERID] [MACHINE] [MESSAGE]
		readonly string _userId;
		
		bool _errorActive = false;
		bool _warningActive = false;
		bool _infoActive = false;
		bool _debugActive = false;
		bool _traceActive = false;
		
		public DefaultConsoleLogger(string userId)
		{
			_userId = userId;
		}

		#region IActivable implementation
		
		public bool Activate()
		{
			bool isConfigured = System.Configuration.ConfigurationManager.AppSettings.Keys["ConsoleLogger"] != null;
			if(isConfigured)
			{
				string[] levels = System.Configuration.ConfigurationManager.AppSettings.Keys["ConsoleLogger"].Split("|");
				foreach(string level in levels)
				{
					if(level.ToUpper() == "ALL")
					{
						_errorActive = true;
						_warningActive = true;
						_infoActive = true;
						_debugActive = true;
						_traceActive = true;
					}
				}
				
			}
		}
	}
	
	#endregion
	
	#region ILoggable implementation

	public void Error(Exception e)
	{
		WriteMessage("ERROR", ConsoleColor.Red, String.Format("Message: {0}. StackTrace: {1}", e.Message, e.StackTrace));
	}

	public void Warning(string message)
	{
		WriteMessage("WARNING", ConsoleColor.Yellow, message);
	}

	public void Info(string message)
	{
		WriteMessage("INFO", ConsoleColor.Green, message);
	}

	public void Debug(string message)
	{
		WriteMessage("DEBUG", ConsoleColor.White, message);
	}

	public void Trace(string message)
	{
		WriteMessage("TRACE", ConsoleColor.Gray, message);
	}
	
	void WriteMessage(string type, ConsoleColor colorText, string message)
	{
		if (IsActive()) {
			ConsoleColor previousColor = System.Console.ForegroundColor;
			System.Console.ForegroundColor = colorText;
			System.Console.WriteLine(String.Format(_format, DateTime.UtcNow.ToString("yyyyMMdd HH:MM:ss UTC"), type, _userId, message));
			System.Console.ForegroundColor = previousColor;
		}

		#endregion
	}
}
}
