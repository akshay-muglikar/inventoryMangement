using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InventoryDomain.Model;

namespace InventoryDomain.Configuration;

public class ItemConfiguration: IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(t => t.Name).IsRequired(true);
        builder.Property(t => t.Category).IsRequired(false);

        builder.Property(t => t.Car).IsRequired(false);

        builder.Property(t => t.Type).IsRequired(false);

        builder.Property(t => t.Description).IsRequired(false);


    }
}

