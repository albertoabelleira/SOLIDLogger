/*
 * Created by SharpDevelop.
 * User: alberto.abelleira
 * Date: 30/11/2018
 * Time: 10:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SOLIDLogger;
using SOLIDLogger.Loggers;

namespace SOLIDLoggerConsole
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			ILoggable logger = LoggerFactory.GetLogger(LoggerType.All);
			try{
				var i = 3;
				var j = 0;
				
					var l = i/j;
			
			}catch(Exception ex)
			{
				logger.Error(ex);
			}
			logger.Warning("This is a warning");
			logger.Info("This is a info");
			logger.Debug("This is a debug");
			logger.Trace("This is a trace");
			Console.ReadLine();
		}
	}
}