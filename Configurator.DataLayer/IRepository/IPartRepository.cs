using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.IRepository
{
    public interface IPartRepository
    {
        Part GetPartById(int id);
        IList<Part> GetAllParts(int prodID);
        void SavePart(Part part);
        bool UpdatePart(Part part);
        bool DeletePart(int id);
    }
}
