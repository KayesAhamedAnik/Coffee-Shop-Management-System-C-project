using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CoffeeShop.Entity
{
   public class Item
    {
        public String itemId
        {
            get;set;
        }
        public String name
        {
            get;set;
        }
        public int price
        {
            get;set;
        }/*
        public Item(String itemId,String name,int price)
        {
            this.itemId = itemId;
            this.name = name;
            this.price = price;
        }
        */
    }
}
