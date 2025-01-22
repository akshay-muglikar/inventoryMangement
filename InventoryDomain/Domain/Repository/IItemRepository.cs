using System;
using InventoryDomain.Model;

namespace InventoryDomain.Repository;

public interface IItemRepository
{
    public Task<List<Item>> GetAsync();
    public Task AddAsync(Item item);
    public Task UpdateAsync(Item item);
    public Task Delete(Item item);
    Task<Item> GetSearchResultAsync(string query);
}
