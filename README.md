#Zeiss.Test#
Able to use websocket connection to get machine status. Store recived data and expose web api which can be used by frontend UI.

##Projects##
Zeiss.Test: console application, perodic run to ingest data through websocket and store data.
Zeiss.Test.Contracts: defines the interfaces and data models.
Zeiss.Test.Core: define utilities
Zeiss.Test.Implementations: implementations of contracts.
Zeiss.Test.WebApi: exposed web api

All projects developed with dotnet core. It supports corss platforms.


##How to deploy##


##How to run##
1. Zeiss.Test console application run
2. Zeiss.Test.WebApi run


##Missing Parts##
1. log
2. configuration
3. exception handler
4. unit test