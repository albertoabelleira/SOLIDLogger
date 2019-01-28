/*
 * Created by SharpDevelop.
 * User: alberto.abelleira
 * Date: 30/11/2018
 * Time: 9:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace SOLIDLogger
{
	/// <summary>
	/// Description of Logger.
	/// </summary>
	public class Logger : ILoggable
	{
		readonly IEnumerable<ILoggable>  _loggers;		
		public Logger(params ILoggable[] loggers)
		{
			_loggers = loggers;
		}

		#region ILoggable implementation

		public void Error(Exception e)
		{
			foreach(ILoggable logger in _loggers)
			{
				logger.Error(e);
			}
		}

		public void Warning(string message)
		{
			foreach(ILoggable logger in _loggers)
			{
				logger.Warning(message);
			}
		}

		public void Info(string message)
		{
			foreach(ILoggable logger in _loggers)
			{
				logger.Info(message);
			}
		}

		public void Debug(string message)
		{
			foreach(ILoggable logger in _loggers)
			{
				logger.Debug(message);
			}
		}

		public void Trace(string message)
		{
			foreach(ILoggable logger in _loggers)
			{
				logger.Trace(message);
			}
		}

		#endregion
	}
}
