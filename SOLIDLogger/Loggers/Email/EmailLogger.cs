/*
 * Created by SharpDevelop.
 * User: alberto.abelleira
 * Date: 30/11/2018
 * Time: 10:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SOLIDLogger.Loggers.EmailLog
{
	/// <summary>
	/// Description of EmailLogger.
	/// </summary>
	public class DefaultEmailLogger: ILoggable, IActivable
	{
		public DefaultEmailLogger()
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
			System.Console.WriteLine("Email Error: " + e.Message);
		}

		public void Warning(string message)
		{
			System.Console.WriteLine("Email Warning: " + message);
		}

		public void Info(string message)
		{
			System.Console.WriteLine("Email Info: "+message);
		}

		public void Debug(string message)
		{
			System.Console.WriteLine("Email Debug: "+ message);
		}

		public void Trace(string message)
		{
			System.Console.WriteLine("Email Trace: "+message);
		}

		#endregion
	}
}
