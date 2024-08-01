using Blog.BlazorServer.Clients.Interfaces;
using Blog.BlazorServer.ViewModels;

namespace Blog.BlazorServer.Clients
{
    public class CategoryClient : ICategoryClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/category";

        public CategoryClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<HttpResponseMessage> AddAsync(CategoryViewModel categoryDTO) => await _httpClient.PostAsJsonAsync(BaseUrl, categoryDTO);

        public async Task<HttpResponseMessage> UpdateAsync(CategoryViewModel categoryDTO) => await _httpClient.PutAsJsonAsync($"{BaseUrl}/{categoryDTO?.Id}", categoryDTO);

        public async Task<HttpResponseMessage> DeleteAsync(int id) => await _httpClient.DeleteAsync($"{BaseUrl}/{id}");

        public async Task<List<CategoryViewModel>> GetAllAsync() 
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryViewModel>>(BaseUrl); 
        }

        public async Task<List<CategoryViewModel>> GetAssignedCategoriesAsync()
        {
            return await GetAllAsync();
        }
    }
}
