using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exercise_1
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            int[] postIds = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            
            var posts = GetPostAsync(postIds);
        }

        public static async Task<Post> GetPostAsync(int postId)
        {
            HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");

            return null;
        }

        public static async Task<Post[]> GetPostAsync(IEnumerable<int> postIds)
        {
            var getPosts = postIds.Select(id => GetPostAsync(id));
            return await Task.WhenAll(getPosts);
        }
    }
}
