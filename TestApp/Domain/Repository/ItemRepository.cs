using System;
using Microsoft.EntityFrameworkCore;
using TestApp.Context;
using TestApp.Domain.Model;

namespace TestApp.Domain.Repository;

public class ItemRepository : IItemRepository
{
    private ApplicationDbContext context;

    public ItemRepository(ApplicationDbContext context)
    {
        this.context = context;
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "T5.db");
        Console.WriteLine($"Database Path: {dbPath}");
        FileStream f = File.Open(dbPath, FileMode.OpenOrCreate);
        f.Close();
        context.Database.Migrate();
    }

    public async Task AddAsync(Item item)
    {
        await context.Items.AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Item item)
    {
        context.Items.Remove(item);
        await context.SaveChangesAsync();

    }

    public async Task<List<Item>> GetAsync()
    {
        return await context.Items.ToListAsync();
    }

    public async Task<Item> GetSearchResultAsync(string query)
    {
        return await context.Items.FirstOrDefaultAsync(x => x.Name == query);
    }

    public async Task UpdateAsync(Item item)
    {
        context.Items.Update(item);
        await context.SaveChangesAsync();

    }
}
