# Predes.Log4Net.Zabbix
Class library with log4net appender for Zabbix.

## How to use

- Add the nuget package (https://www.nuget.org/packages/Predes.Log4Net.Zabbix/) to your project.
- Add the appender in your log4net configuration as in the sample below.

## Sample configuration
The following sample configuration sends all error log messages to the configured zabbix server.

```xml
<log4net>
  <root>
    <level value="ALL" />      
    <appender-ref ref="Console" />
    <appender-ref ref="ZabbixAppender" />
  </root>
  <appender name="Console" type="log4net.Appender.ConsoleAppender">
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%date %-5level: %message%newline" />
    </layout>
  </appender>
  <appender name="ZabbixAppender" type="Predes.Log4Net.Zabbix.ZabbixAppender, Predes.Log4Net.Zabbix">
    <HostName>HOSTNAME_ZABBIX_SERVER</HostName>
    <ItemHost>ZABBIX_ITEM_HOST</ItemHost>
    <ItemKey>ZABBIX_ITEM_KEY</ItemKey>
    <PortNumber>10051</PortNumber>
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%-5level %d [%t] %m%n" />
    </layout>
    <filter type="log4net.Filter.LevelRangeFilter">
      <param name="LevelMin" value="ERROR"/>
      <param name="LevelMax" value="ERROR"/>
    </filter>
  </appender>
</log4net>
```
