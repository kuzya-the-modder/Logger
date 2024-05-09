using Kuzya.Logs;
public static class Program
{
    static void Main(string[] args)
    {
        Logger.SetPath("D:\\Desktop");
        var logger = new Logger();
        logger.Log("Hello, World!");
        logger.Dispose();
    }
}