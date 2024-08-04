namespace csharp_src;

static class Program
{
    public static bool IsDebug
    {
        get
        {
            #if DEBUG
            return true;
            #else
            return false;
            #endif
        }
    }
    public static StaticServer? Server { get; private set; }

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        if (!IsDebug)
        {
            int port = StaticServer.GetAvailablePort();
            string wwwroot = Path.Combine(Application.StartupPath, "wwwroot");
            Server = new StaticServer(wwwroot, port);
            Server.Start();
        }

        Application.Run(new MainForm());

        if (!IsDebug)
        {
            Server?.Stop();
        }
    }
}