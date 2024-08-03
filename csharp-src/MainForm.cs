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
        await webView.EnsureCoreWebView2Async();

        string svelteKitPath = Program.IsDebug ? "http://localhost:3005" : Path.Combine(Application.StartupPath, "wwwroot", "index.html");
        webView.Source = new Uri(svelteKitPath);

        webView.CoreWebView2.AddHostObjectToScript("myMethods", new MyMethods());
        webView.CoreWebView2.Settings.AreDevToolsEnabled = Program.IsDebug;
        webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = Program.IsDebug;
    }
}