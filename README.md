
﻿# Intro

This software is responsible to listen on a TCP port for incoming NTRIPCaster V1.0 and translate then send to remote NtripCaster v2.

ntrip v1 is not pure HTTP, it have some minor protocol viloation. but V2 is pure HTTP so could be served by HttpListener builtin dotnet. 

the goal is to convert V1 requests to pure HTTP requests (V2).


This proxy lay between V1 client/server and a v2 caster. The v1 side, which is either `NTRipClient V1.0` or `NTRipServer V1.0` will never understand that it is talking with a `Caster V2`


There are two types of translators:

- translates the NTRIP client comunication
- translates the NTRIP server comunication

it will not happen at same time. so can be served on different ports or different hosts.

# NTrip Elements

- Client: Http Client, such as rover which only pull data from server
- Server: Http Client, such as base station which only push data (correction) to server
- Caster: machine with public IP, Server will connect to it and push the data to it. client will connect and pull the data from it.
