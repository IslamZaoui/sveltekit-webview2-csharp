namespace csharp_src;

public class StaticServer
{
    private readonly System.Net.HttpListener listener;
    private readonly Thread serverThread;
    private readonly string contentRoot;
    public int Port { get; }

    public StaticServer(string path, int port)
    {
        contentRoot = path;
        Port = port;
        listener = new System.Net.HttpListener();
        listener.Prefixes.Add($"http://localhost:{port}/");
        serverThread = new Thread(Listen)
        {
            IsBackground = true
        };
    }

    public void Start()
    {
        listener.Start();
        serverThread.Start();
    }

    public void Stop()
    {
        listener.Stop();
        serverThread.Join();
    }

    private void Listen()
    {
        while (listener.IsListening)
        {
            try
            {
                System.Net.HttpListenerContext context = listener.GetContext();
                ProcessRequest(context);
            }
            catch (System.Net.HttpListenerException)
            {
                break;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in HTTP server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void ProcessRequest(System.Net.HttpListenerContext context)
    {
        System.Net.HttpListenerRequest request = context.Request;
        System.Net.HttpListenerResponse response = context.Response;

        string requestPath = request.Url?.LocalPath ?? string.Empty;
        string filePath = Path.Combine(contentRoot, requestPath.TrimStart('/'));

        if (string.IsNullOrEmpty(Path.GetExtension(filePath)))
        {
            filePath = Path.Combine(filePath, "index.html");
        }

        if (File.Exists(filePath))
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            response.ContentLength64 = buffer.Length;
            response.ContentType = MimeTypes.GetMimeType(Path.GetExtension(filePath));
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }
        else
        {
            response.StatusCode = 404;
        }

        response.Close();
    }

    public static int GetAvailablePort()
    {
        System.Net.Sockets.TcpListener listener = new(System.Net.IPAddress.Loopback, 0);
        listener.Start();
        int port = ((System.Net.IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
    }
}
