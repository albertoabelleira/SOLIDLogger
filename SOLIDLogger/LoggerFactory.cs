/*
 * Created by SharpDevelop.
 * User: alberto.abelleira
 * Date: 07/01/2019
 * Time: 17:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SOLIDLogger.Loggers;
using SOLIDLogger.Loggers.ConsoleLog;
using SOLIDLogger.Loggers.DatabaseLog;
using SOLIDLogger.Loggers.EmailLog;

namespace SOLIDLogger
{
	
	public enum LoggerType
	{
		All,
		Console,
		Database,
		Email
	}
	/// <summary>
	/// Description of LoggerFactory.
	/// </summary>
	public class LoggerFactory
	{
		public LoggerFactory()
		{
		}
		
		public static ILoggable GetLogger()
		{
			return GetLogger("DEFAULT", LoggerType.All);			
		}
		
		public static ILoggable GetLogger(string userId)
		{
			return GetLogger(userId, LoggerType.All);			
		}
		
		public static ILoggable GetLogger(LoggerType type)
		{
			return GetLogger("DEFAULT", type);			
		}
		
		public static ILoggable GetLogger(string userId, LoggerType type)
		{
			ILoggable logger = null;
			switch(type)
			{
				case LoggerType.All:
					logger= new Logger(new DefaultConsoleLogger(userId),
					                   new DefaultDatabaseLogger(),
					                   new DefaultEmailLogger());
					break;
				case LoggerType.Console:
					logger= new Logger(new DefaultConsoleLogger(userId));
					break;
				case LoggerType.Database:
					logger= new Logger(new DefaultDatabaseLogger());
					break;
				case LoggerType.Email:
					logger= new Logger(new DefaultEmailLogger());
					break;
				default:
					logger= new Logger(new DefaultConsoleLogger(userId),
					                   new DefaultDatabaseLogger(),
					                   new DefaultEmailLogger());
					break;
			}
			
			return logger;
			
		}
	}
}
