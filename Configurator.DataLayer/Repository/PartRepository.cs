using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{
    public class PartRepository : IPartRepository
    {
        ProductConfiguratorEntities db = new ProductConfiguratorEntities();
        public bool DeletePart(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Part> GetAllParts(int prodID)
        {
            return db.Parts.Where(x => x.ProductId == prodID).ToList();
        }

        public Part GetPartById(int id)
        {
            return db.Parts.FirstOrDefault(x => x.Id == id);
        }

        public void SavePart(Part part)
        {
            db.Parts.Add(part);
            db.SaveChanges();
        }

        public bool UpdatePart(Part part)
        {
            throw new NotImplementedException();
        }
    }
}
