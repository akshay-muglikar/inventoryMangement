using System;
using Microsoft.EntityFrameworkCore;
using InventoryDomain.Context;
using InventoryDomain.Model;

namespace InventoryDomain.Repository;

public class BillRepository : IBillRepository
{
    public ApplicationDbContext context;

    public BillRepository(ApplicationDbContext context){
        this.context = context;
    }
     public async Task AddAsync(Bill item)
    {
        await AddBillItems(item.BillItems);
        await context.Bills.AddAsync(item);
        await context.SaveChangesAsync();
    }
    public async Task AddBillItems(List<BillItem> items){
        if(items==null || items.Any()) return;
        await context.Billitems.AddRangeAsync(items);
    }
    public async Task Delete(Bill item)
    {
        context.Bills.Remove(item);
        await context.SaveChangesAsync();

    }

    public async Task<List<Bill>> GetAsync()
    {
        return await context.Bills.ToListAsync();
    }

    public List<string> GetSearchResults(string query)
    {
        return this.context.Bills.Where(x=>x.Name==query).Select(x=>x.Name).ToList();
    }

    public async Task UpdateAsync(Bill item)
    {
        context.Bills.Update(item);
        await context.SaveChangesAsync();

    }
}
