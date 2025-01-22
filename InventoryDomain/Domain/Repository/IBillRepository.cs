using System;
using InventoryDomain.Model;

namespace InventoryDomain.Repository;

public interface IBillRepository
{
 public Task<List<Bill>> GetAsync();
    public Task AddAsync(Bill item);
    public Task UpdateAsync(Bill item);
    public Task Delete(Bill item);
}
