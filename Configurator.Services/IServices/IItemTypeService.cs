using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.IServices
{
    public interface IItemTypeService
    {
        ItemTypeModel GetItemTypesById(int id);
        IList<ItemTypeModel> GetAllItemTypes(int partID);
        void SaveItemType(ItemTypeModel type);
        bool UpdateItemType(ItemTypeModel type);
        bool DeleteItemType(int id);
    }
}
