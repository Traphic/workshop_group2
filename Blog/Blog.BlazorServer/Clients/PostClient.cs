using Blog.BlazorServer.Clients.Interfaces;
using Blog.BlazorServer.ViewModels;

namespace Blog.BlazorServer.Clients
{
    public class PostClient : IPostClient
    {
        private readonly HttpClient _httpClient;

        private const string BaseUrl = "api/post";

        public PostClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<HttpResponseMessage> AddAsync(PostViewModel postDTO) =>  await _httpClient.PostAsJsonAsync(BaseUrl, postDTO); 

        public async Task<HttpResponseMessage> UpdateAsync(PostViewModel postDTO) => await _httpClient.PutAsJsonAsync($"{BaseUrl}/{postDTO?.Id}", postDTO);

        public async Task<HttpResponseMessage> DeleteAsync(int id) => await _httpClient.DeleteAsync($"{BaseUrl}/{id}");

        public async Task<HttpResponseMessage> GetByIdAsync(int id) => await _httpClient.GetAsync($"{BaseUrl}/{id}");

        public async Task<List<PostListViewModel>> GetAllAsync() => await _httpClient.GetFromJsonAsync<List<PostListViewModel>>(BaseUrl);

        public async Task<List<PostListViewModel>> GetAllByCategoryAsync(int categoryId) => await _httpClient.GetFromJsonAsync<List<PostListViewModel>>($"{BaseUrl}/category/{categoryId}");
    }
}
