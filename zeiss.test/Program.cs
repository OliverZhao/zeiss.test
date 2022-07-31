// See https://aka.ms/new-console-template for more information
using System.Net.WebSockets;
using zeiss.test.implementations;
using Zeiss.Test;
using Zeiss.Test.Implementations;

Console.WriteLine("Running Zeiss Test");

CancellationToken token = new CancellationToken();
ClientWebSocket client = new ClientWebSocket();
new RunZeissTest(
    new WebSocketDataConnector(client, "ws://machinestream.herokuapp.com/ws"),
    new FileDataStorage("FILEPATH")).Run(token).GetAwaiter();
