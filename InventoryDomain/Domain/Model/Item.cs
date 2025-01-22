using System;

namespace InventoryDomain.Model;

public class Item
{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Car{get;set;}
        public int Quantity{get;set;}
        public string Type{get;set;}
        public string Description{get;set;}

        public virtual List<BillItem> BillItems {get; set;}


}
