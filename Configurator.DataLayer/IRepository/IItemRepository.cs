using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.IRepository
{
    public interface IItemRepository
    {
        Item GetItemById(int id);
        IList<Item> GetAllItems(int itemTypeID);
        IList<Item> GetItems();
        void SaveItem(Item item);
        bool UpdateItem(Item item);
        bool DeleteItem(int id);
        IList<Item> GetItemsByCode(string code);
        //IList<Item> GetItemsByProductAndBodyPart(string code);
    }
}
