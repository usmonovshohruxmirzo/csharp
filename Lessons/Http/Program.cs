namespace Http
{
    class Program
    {
        public static readonly HttpClient _httpClient = new HttpClient();

        public static async Task GetExampleTodoData()
        {
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            Console.WriteLine($"Sending GET request to: {url}");

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            Console.WriteLine($"Status Code: {response.StatusCode} {response.ReasonPhrase}");
            Console.WriteLine($"Is Success Status Code (2xx): {response.IsSuccessStatusCode}");

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
            Console.ReadKey();
        }

        static async Task Main(string[] args)
        {
            await GetExampleTodoData();
        }
    }
}
