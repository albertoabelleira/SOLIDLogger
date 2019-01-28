/*
 * Created by SharpDevelop.
 * User: alberto.abelleira
 * Date: 30/11/2018
 * Time: 9:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SOLIDLogger
{
	/// <summary>
	/// Description of ILoggable.
	/// </summary>
	public interface ILoggable
	{
		void Error(Exception e);
		void Warning(string message);
		void Info(string message);
		void Debug(string message);
		void Trace(string message);
	}
}
