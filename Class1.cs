using System.Net.WebSockets;

namespace ws_test;
internal class Class1
{
    public Class1()
    {
        var ws = new ClientWebSocket();
        var uri = new Uri("ws://0.0.0.0:8181");
        ws.ConnectAsync(uri, new CancellationToken());
    }
}
