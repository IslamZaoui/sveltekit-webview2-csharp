namespace csharp_src;
public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        InitializeWebView();
    }

    private async void InitializeWebView()
    {
        await webView.EnsureCoreWebView2Async(null);

        webView.CoreWebView2.AddHostObjectToScript("myMethods", new MyMethods());
        //webView.CoreWebView2.Settings.AreDevToolsEnabled = Program.IsDebug;
        //webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = Program.IsDebug;

        string? port = Program.IsDebug ? "3005" : Program.Server?.Port.ToString();
        string url = $"http://localhost:{port}";

        webView.CoreWebView2.Navigate(url);
    }
}