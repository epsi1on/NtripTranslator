using V1Translator;

internal class Program
{
    //convert incoming NTRIP V1 into outgoing NPRIP V2
    private static void Main(string[] args)
    {
        var localIp = "127.0.0.1";
        var localPort = 2555;

        var remoteNtripV2Caster = "127.0.0.1:2556";



        Translator.StartSync(localIp, localPort, remoteNtripV2Caster);

        Console.WriteLine("Hello, World!");
    }
}