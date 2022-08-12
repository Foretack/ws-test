using Fleck;

namespace ws_test;

internal static class Program
{
    private static uint Id { get; set; } = 0;
    static void Main(string[] args)
    {
        var server = new WebSocketServer("ws://0.0.0.0:7557");
        server.RestartAfterListenError = true;
        server.Start(socket =>
        {
            socket.OnOpen = () => Console.WriteLine("Open!");
            socket.OnClose = () => Console.WriteLine("Closed!");
            socket.OnMessage = message => socket.HandleMessage(message);
        });

        Console.ReadLine();
    }

    private static bool HandleMessage(this IWebSocketConnection con, string message)
    {
        Console.WriteLine($"Received: {message}");
        con.Send($"Id: {Id}");
        Id++;
        return true;
    }
}
