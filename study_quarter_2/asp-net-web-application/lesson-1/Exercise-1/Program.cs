using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exercise_1
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string url = "https://jsonplaceholder.typicode.com/posts/";
        static async Task Main(string[] args)
        {
            int[] postIds = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            
            var posts = await GetPostAsync(postIds);

            foreach (var post in posts)
            {
                Console.WriteLine($"{post.UserId}");
                Console.WriteLine($"{post.Id}");
                Console.WriteLine($"{post.Title}");
                Console.WriteLine($"{post.Body}");
                Console.WriteLine();
            }
        }

        public static async Task<Post> GetPostAsync(int id)
        {
            var path = $"{url}{id}";

            var response = await client.GetStringAsync(path);

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var post = JsonSerializer.Deserialize<Post>(response, serializeOptions);

            return post;
        }

        public static async Task<Post[]> GetPostAsync(IEnumerable<int> ids)
        {
            var getPosts = ids.Select(id => GetPostAsync(id));
            return await Task.WhenAll(getPosts);
        }
    }
}
