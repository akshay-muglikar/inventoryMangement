using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryDomain.Model;

public class BillItem
{
    public int Id {get;set;}
    public int BillId {get;set;}
    public int ItemId  {get;set;}
    public int Quantity {get;set;}
    public string OtherItem {get;set;}
    public int Amount {get;set;}

    public virtual Bill Bill {get;set;}
    public virtual Item Item {get;set;}

}

public class BillItemConfiguration: IEntityTypeConfiguration<BillItem>
{
    public void Configure(EntityTypeBuilder<BillItem> builder)
    {
        builder.HasKey(o => o.Id);
        builder.HasOne(x=> x.Bill).WithMany(yy=>yy.BillItems);
        builder.HasOne(x=> x.Item).WithMany(yy=>yy.BillItems);
    }
}
