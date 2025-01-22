using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryDomain.Model;

public class Bill
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Mobile {get; set;}
    public int BillAmount {get; set;}
    public DateTimeOffset BillDate{get; set;} = DateTimeOffset.Now;

    public virtual List<BillItem> BillItems {get; set;}
}

public class BillConfiguration: IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(t => t.Name).IsRequired(true);
        builder.Property(t => t.Mobile).IsRequired(false);
    }
}
