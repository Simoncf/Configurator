using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.IRepository
{
    public interface IItemTypeRepository
    {
        ItemType GetItemTypeById(int id);
        IList<ItemType> GetAllItemTypes(int partID);
        void SaveItemType(ItemType type);
        bool UpdateItemType(ItemType type);
        bool DeleteItemType(int id);
    }
}
