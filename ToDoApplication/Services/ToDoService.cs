using Blazored.LocalStorage;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class ToDoService
    {
        private readonly ILocalStorageService _localStorage;

        public ToDoService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        private List<ToDoItem> _items = new();

        public async Task<IEnumerable<ToDoItem>> GetItemsAsync()
        {
            _items = await _localStorage.GetItemAsync<List<ToDoItem>>("todos") ?? new List<ToDoItem>();
            return _items;
        }

        public async Task AddItemAsync(ToDoItem item)
        {
            _items.Add(item);
            await _localStorage.SetItemAsync("todos", _items);
        }

        public async Task RemoveItemAsync(int id)
        {
            _items.RemoveAll(i => i.Id == id);
            await _localStorage.SetItemAsync("todos", _items);
        }
    }
}
