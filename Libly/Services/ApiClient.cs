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
            _httpClient.BaseAddress = new Uri("https://localhost:7012/"); // Adjust this URL to match your API's address
        }

        public List<BookDto> GetBooks()
        {
            var response = _httpClient.GetAsync("api/books").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<List<BookDto>>().Result;
        }

        public BookDto GetBook(int id)
        {
            var response = _httpClient.GetAsync($"api/books/{id}").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<BookDto>().Result;
        }

        public BookDto CreateBook(BookCreateDto book)
        {
            var response = _httpClient.PostAsJsonAsync("api/books", book).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<BookDto>().Result;
        }

        public void UpdateBook(int id, BookUpdateDto book)
        {
            var response = _httpClient.PutAsJsonAsync($"api/books/{id}", book).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteBook(int id)
        {
            var response = _httpClient.DeleteAsync($"api/books/{id}").Result;
            response.EnsureSuccessStatusCode();
        }
    }
}