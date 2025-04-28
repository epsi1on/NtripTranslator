# Intro

This class is responsible to listen on a TCP port for incoming NTRIPCaster V1.0 and translate then send to remote NtripV2Caster.

ntrip v1 is not pure HTTP, it have some minor protocol viloation. but V2 is pure HTTP so could be served by HttpListener builtin dotnet. 
the goal is to remove codes for handling HTTP requests and use HttpListener class. it will dramatically reduce the code amount.


This proxy is transparent, i.e. client which is either `NTRipClient V1.0` or `NTRipServer V1.0` will never understand that it is talking with a `Caster V2`


There are two types of translators:

- translates the NTRIP client comunication
- translates the NTRIP server comunication

it will not happen at same time. so can be served on different ports or different hosts.


# NtripClient to NtripCaster communication

This section describes the majority of communications in the Ntrip system. The 
NtripClient is any software receiving data streams from the Internet provided by an 
NtripCaster. This protocol must be implemented in any end user application or device. 
The basic tasks of these communications are: 
• transfer of system information from NtripCaster to NtripClient (sourcetable) 
• request of data by NtripClient (specified with mountpoint, user name, password) 
• transmission of requested data from NtripCaster to NtripClient 
• handling of error states, wrong requests, etc.