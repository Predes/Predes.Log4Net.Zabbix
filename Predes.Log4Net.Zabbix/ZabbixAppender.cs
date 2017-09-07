// ===============================================================================
//  File:		ZabbixAppender.cs
//  Project:	Predes.Log4Net.Zabbix  
// -------------------------------------------------------------------------------
//  
//  Copyright (c) Predes 2017 All rights reserved.
// ===============================================================================

using System.Diagnostics;
using log4net.Appender;
using log4net.Core;
using Predes.ZabbixSender;

namespace Predes.Log4Net.Zabbix
{
    /// <summary>
    /// This class implements a log4net appender for Zabbix.
    /// </summary>
    public class ZabbixAppender : AppenderSkeleton
    {
        private SenderService _service;

        /// <summary>
        /// Gets or sets the host name of the Zabbix server.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the host name of the item to send a value for.
        /// </summary>
        public string ItemHost { get; set; }

        /// <summary>
        /// Gets or sets key of the item to send a value for.
        /// </summary>
        public string ItemKey { get; set; }

        /// <summary>
        /// Gets or sets the port number of the Zabbix server. Default value 10051.
        /// </summary>
        public int PortNumber { get; set; } = 10051;

        /// <summary>
        /// Appends a logging event. 
        /// </summary>
        /// <param name="loggingEvent">The logging event to append.</param>
        protected override void Append(LoggingEvent loggingEvent)
        {
            if (_service == null)
                _service = new SenderService(HostName, PortNumber);

            _service.Send(ItemHost, ItemKey, RenderLoggingEvent(loggingEvent));
        }
    }
}