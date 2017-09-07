// ===============================================================================
//  File:		Program.cs
//  Project:	Predes.Log4Net.Zabbix.Console  
// -------------------------------------------------------------------------------
//  
//  Copyright (c) Predes 2017 All rights reserved.
// ===============================================================================

using System;
using System.Reflection;
using log4net;
using log4net.Config;

namespace Predes.Log4Net.Zabbix.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            var log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            log.Debug($"Application start.");

            log.Info($"This is an informational log message.");
            try
            {
                throw new ApplicationException("Something went wrong");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            log.Debug($"Application end.");
        }
    }
}