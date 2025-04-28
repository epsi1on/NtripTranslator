# NtripClient to NtripCaster communication

This section describes the majority of communications in the Ntrip system. The 
NtripClient is any software receiving data streams from the Internet provided by an 
NtripCaster. This protocol must be implemented in any end user application or device. 
The basic tasks of these communications are: 
• transfer of system information from NtripCaster to NtripClient (sourcetable) 
• request of data by NtripClient (specified with mountpoint, user name, password) 
• transmission of requested data from NtripCaster to NtripClient 
• handling of error states, wrong requests, etc.
