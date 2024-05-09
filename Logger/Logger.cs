using System.Text;

namespace Kuzya.Logs;

public sealed class Logger : IDisposable
{
    static readonly UTF8Encoding Encoder = new();

    //Specify plz
    static string? Path;
    public static void SetPath(string path) => Path = path;
    public static string GetName() => DateTime.Now.ToString("MM-dd-yy HH-mm-ss");

    private FileStream _wr;

    public Logger() : this(Path, GetName() + ".log") { }
    public Logger(string? path, string name)
    {
        if (path is null || !Directory.Exists(path))
            throw new ArgumentNullException($"Logger#Constructor : {nameof(path)} is null or does not exist");
        _wr = File.Open(@$"{path}\{name}", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
    }
    // for lightweight messages
    public void Log(string content) => _wr.Write(Encoder.GetBytes(content));

    // for heavy messages
    public ValueTask LogAsync(string content) => _wr.WriteAsync(Encoder.GetBytes(content));

    public void Dispose() => _wr.Dispose();
}
