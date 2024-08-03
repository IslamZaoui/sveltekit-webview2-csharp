namespace csharp_src;

[System.Runtime.InteropServices.ComVisible(true)]
public class MyMethods
{
    public void Greet(string name){
        MessageBox.Show($"Greeting {name} from CSharp");
    }
}