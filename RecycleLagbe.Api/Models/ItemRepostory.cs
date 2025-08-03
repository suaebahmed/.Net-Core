using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebAPI.Models
{
    public class ItemRepostory : ITemRepository
    {
        private List<Item> items = new List<Item>();
        private int _nextId = 1;
        public ItemRepostory()
        {
            items.Add(new Item { Name = "Tomato", Category = "Vagitable", Price = 100 });
            items.Add(new Item { Name = "Apple", Category = "Fruit", Price = 150 });
            items.Add(new Item { Name = "Suit", Category = "Cloth", Price = 200 });
            items.Add(new Item { Name = "Shirt", Category = "Cloth", Price = 250 });
        }

        public IEnumerable<Item> GetAll()
        {
            return items;
        }
        public Item Get(int id)
        {
            return items.Find(i => i.Id == id);
        }
        public Item Add(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            items.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            items.RemoveAll(i => i.Id == id);
        }

        public bool Update(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = items.FindIndex(i => i.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            items.RemoveAt(index);
            items.Add(item);
            return true;
        }
    }
}
