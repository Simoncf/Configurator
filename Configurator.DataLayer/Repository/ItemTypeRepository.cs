using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{
    public class ItemTypeRepository : IItemTypeRepository
    {
        ProductConfiguratorEntities db = new ProductConfiguratorEntities();
        public bool DeleteItemType(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ItemType> GetAllItemTypes(int partID)
        {
            return db.ItemTypes.Where(x => x.PartId == partID).ToList();
        }

        public ItemType GetItemTypeById(int id)
        {
            return db.ItemTypes.FirstOrDefault(x => x.Id == id);
        }

        public void SaveItemType(ItemType type)
        {
            db.ItemTypes.Add(type);
            db.SaveChanges();
        }

        public bool UpdateItemType(ItemType type)
        {
            throw new NotImplementedException();
        }
    }
}
