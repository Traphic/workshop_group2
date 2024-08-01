using Blog.BlazorServer.Clients.Interfaces;
using Blog.BlazorServer.ViewModels;

namespace Blog.BlazorServer.Clients
{
    public class CommentClient : ICommentClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/comment"; 

        public CommentClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<HttpResponseMessage> AddAsync(CommentViewModel comment) => await _httpClient.PostAsJsonAsync(BaseUrl, comment);

        public async Task<HttpResponseMessage> DeleteAsync(int id) => await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
    }
}
