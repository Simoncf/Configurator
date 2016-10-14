using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{
    public class ItemRepository : IItemRepository
    {
        ProductConfiguratorEntities db = new ProductConfiguratorEntities();
        public bool DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        

        public IList<Item> GetAllItems(int itemTypeID)
        {
            return db.Items.Where(x => x.ItemTypeId == itemTypeID).ToList();
        }

        public IList<Item> GetItemsByCode(string code)
        {
            return db.Items.Where(x => x.Code.Contains(code)).ToList();
        }

        

        public Item GetItemById(int id)
        {
            return db.Items.FirstOrDefault(x => x.Id == id);
        }

        public IList<Item> GetItems()
        {
            return db.Items.ToList();
        }

        public void SaveItem(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
        }

        public bool UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
