using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoKnowApplication.Models;

namespace NoKnowApplication.Services
{
    public class MockDataStore : IDataStore<ListItem>
    {
        List<ListItem> items;

        public MockDataStore()
        {
            items = new List<ListItem>();
            var mockItems = new List<ListItem>
            {
                new ListItem { Id = Guid.NewGuid().ToString(), Text = "First listItem", Description="This is an listItem description." },
                new ListItem { Id = Guid.NewGuid().ToString(), Text = "Second listItem", Description="This is an listItem description." },
                new ListItem { Id = Guid.NewGuid().ToString(), Text = "Third listItem", Description="This is an listItem description." },
                new ListItem { Id = Guid.NewGuid().ToString(), Text = "Fourth listItem", Description="This is an listItem description." },
                new ListItem { Id = Guid.NewGuid().ToString(), Text = "Fifth listItem", Description="This is an listItem description." },
                new ListItem { Id = Guid.NewGuid().ToString(), Text = "Sixth listItem", Description="This is an listItem description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(ListItem listItem)
        {
            items.Add(listItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ListItem listItem)
        {
            var oldItem = items.Where((ListItem arg) => arg.Id == listItem.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(listItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ListItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ListItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ListItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}