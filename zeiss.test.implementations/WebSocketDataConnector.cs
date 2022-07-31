using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;
using Zeiss.Test.Contracts;
using Zeiss.Test.Contracts.Models;

namespace zeiss.test.implementations
{
    // data connector web socket implementation
    public class WebSocketDataConnector : IDataConnector
    {
        private readonly ClientWebSocket _ws;
        private readonly Uri _uri;

        public WebSocketDataConnector(ClientWebSocket clientWS, string url)
        {
            _ws = clientWS;
            _uri = new Uri(url);
        }

        public async Task<EventData> ReceiveAsync(CancellationToken ctoken)
        {
            await _ws.ConnectAsync(_uri, ctoken);

            ArraySegment<byte> data = new ArraySegment<byte>();
            var result = await _ws.ReceiveAsync(data, ctoken);

            while (!result.EndOfMessage)
            {
                Thread.Sleep(5);
            }

            if (result.Count <= 0)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<EventData>(Encoding.Default.GetString(data.ToArray()));            ;
        }
    }
}