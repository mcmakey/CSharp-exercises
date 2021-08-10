using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exercise_1
{
    class Chat
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string url = "https://jsonplaceholder.typicode.com/posts/";
        private static readonly string fileName = "posts.txt";

        Post[] Posts { get; set; }
        public Chat()
        {
            
        }

        public async Task Start()
        {
            int[] postIds = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            Posts = await GetPostAsync(postIds);

            SavePosts(fileName, Posts);
        }

        private async Task<Post> GetPostAsync(int id)
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

        private  async Task<Post[]> GetPostAsync(IEnumerable<int> ids)
        {
            var getPosts = ids.Select(id => GetPostAsync(id));
            return await Task.WhenAll(getPosts);
        }

        private async void SavePosts(string fileName, Post[] posts)
        {
            using StreamWriter writer = File.CreateText(fileName);

            foreach (var post in posts)
            {
                await writer.WriteLineAsync($"{post.UserId}");
                await writer.WriteLineAsync($"{post.Id}");
                await writer.WriteLineAsync($"{post.Title}");
                await writer.WriteLineAsync($"{post.Body}");
                await writer.WriteLineAsync();
            }
        }
    }
}
