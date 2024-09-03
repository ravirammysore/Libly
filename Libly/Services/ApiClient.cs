using System.Net.Http.Json;
using Libly.Core.Dtos;

namespace Libly.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BookDto>> GetBooksAsync()
        {
            var response = await _httpClient.GetAsync("api/books");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<BookDto>>() ?? [];
        }

        public async Task<BookDto?> GetBookAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/books/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BookDto>();
        }

        public async Task<BookDto> CreateBookAsync(BookCreateDto book)
        {
            var response = await _httpClient.PostAsJsonAsync("api/books", book);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BookDto>() ?? 
                throw new InvalidOperationException("Failed to create book");
        }

        public async Task UpdateBookAsync(int id, BookUpdateDto book)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/books/{id}", book);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBookAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/books/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("api/books/categories");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CategoryDto>>() ?? [];
        }
    }
}