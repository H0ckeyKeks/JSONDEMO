using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace JSONDEMO
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://my-json-server.typicode.com/typicode/demo/posts";
            
            // ttp client to send the get request
            HttpClient httpClient = new HttpClient();

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);

                // Converting the ResponseMessage into something usable
                // Getting the data from the ResponseMessage
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                Console.WriteLine(jsonResponse);

                // Deserializing json response into a C# array of type Post[]
                var myPosts = JsonConvert.DeserializeObject<Post[]>(jsonResponse);

                // Printing the array objects using a foreach loop
                foreach (var post in myPosts)
                {
                    // Printing the id and the title of each post
                    Console.WriteLine($"{post.Id} { post.Title}");
                }

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            // Disposing httpClient
            httpClient.Dispose();
        }
    }
}
