using System.Text;
namespace Http
{
    class Program
    {
        public static readonly HttpClient _httpClient = new HttpClient();
        public static readonly string baseUrl = "https://jsonplaceholder.typicode.com";

        public static async Task GetExampleTodoData()
        {
            string url = $"{baseUrl}/todos/1";
            Console.WriteLine($"Sending GET request to: {url}");

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            Console.WriteLine($"Status Code: {(int)response.StatusCode} {response.ReasonPhrase}");
            Console.WriteLine($"Is Success Status Code (2xx): {response.IsSuccessStatusCode}");

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
            Console.ReadKey();
        }

        public static async Task CreateNewTodoItem()
        {
            string url = $"{baseUrl}/posts";
            string jsonBody = "{\"title\": \"learn HttpClient\", \"body\": \"coding is fun\", \"userId\": 1}";

            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            Console.WriteLine($"Sending POST request to: {url}");
            Console.WriteLine($"Request Body: {jsonBody}");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            Console.WriteLine($"Status Code: {(int)response.StatusCode} {response.ReasonPhrase}");
            Console.WriteLine($"Is Success Status Code (2xx): {response.IsSuccessStatusCode}");

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response Body (from server):");
            Console.WriteLine(responseBody);
        }

        static async Task Main(string[] args)
        {
            // await GetExampleTodoData();
            await CreateNewTodoItem();
        }
    }
}
