﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAAddinFramework.Utilities
{
    public static class Logger
    {
        private static string _logFileName = System.IO.Path.GetTempPath() + @"\EAAddinFramework.log";
        /// <summary>
        /// the logfile full pathname
        /// </summary>
        public static string logFileName
        {
        	get
        	{
        		return _logFileName;	
        	}
        	set 
        	{
        		_logFileName = value;
        	}
        }
        /// <summary>
        /// set the log file name
        /// </summary>
        /// <param name="fileName">the name of the log file</param>
        public static void setLogFileName(string fileName)
        {
            _logFileName = fileName;
        }
        /// <summary>
        /// log a message
        /// </summary>
        /// <param name="logmessage">the message to be logged</param>
        public static void log(string logmessage)
        { 
            System.IO.StreamWriter logfile = new System.IO.StreamWriter(_logFileName,true);
            logfile.WriteLine( System.DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss.fff") + " " + logmessage);
            logfile.Close();
        }
        /// <summary>
        /// log an error
        /// </summary>
        /// <param name="logmessage">the error message</param>
        public static void logError(string logmessage)
        {
            log("Error: " + logmessage);
        }
        /// <summary>
        /// log a warning
        /// </summary>
        /// <param name="logmessage">the warning message</param>
        public static void logWarning(string logmessage)
        {
            log("Warning: " + logmessage);
        }
    }
}

