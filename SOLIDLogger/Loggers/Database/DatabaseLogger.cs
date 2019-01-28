/*
 * Created by SharpDevelop.
 * User: alberto.abelleira
 * Date: 30/11/2018
 * Time: 10:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SOLIDLogger.Loggers.DatabaseLog
{
	/// <summary>
	/// Description of DatabaseLogger.
	/// </summary>
	public class DefaultDatabaseLogger : ILoggable, IActivable
	{
		public DefaultDatabaseLogger()
		{
		}

		#region IActivable implementation
		
		public bool Activate()
		{
			return true;
		}
		
		#endregion
		
		#region ILoggable implementation

		public void Error(Exception e)
		{
			System.Console.WriteLine("Database Error: " + e.Message);
		}

		public void Warning(string message)
		{
			System.Console.WriteLine("Database Warning: " + message);
		}

		public void Info(string message)
		{
			System.Console.WriteLine("Database Info: "+message);
		}

		public void Debug(string message)
		{
			System.Console.WriteLine("Database Debug: "+ message);
		}

		public void Trace(string message)
		{
			System.Console.WriteLine("Database Trace: "+message);
		}

		#endregion
	}
}
