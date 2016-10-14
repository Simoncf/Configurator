using Configurator.DataLayer;
using Configurator.DataLayer.IRepository;
using Configurator.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.ServiceModels
{
    public class PartService : IPartService
    {
        IPartRepository _partRepo;
        public PartService(IPartRepository partRepo)
        {
            _partRepo = partRepo;
        }
        public bool DeletePart(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PartModel> GetAllParts(int prodID)
        {
            return _partRepo.GetAllParts(prodID).Select(x => new PartModel(x)).ToList();
        }

        public PartModel GetPartById(int id)
        {
            Part p = _partRepo.GetPartById(id);
            PartModel pm = new PartModel();
            pm.Id = p.Id;
            pm.Name = p.Name;
            pm.ProductId = p.ProductId;
            //pm.ItemTypes = p.ItemTypes.ToList();
            return pm;

        }

        public void SavePart(PartModel part)
        {
            _partRepo.SavePart(part.GetRepoPart());
        }

        public bool UpdatePart(PartModel part)
        {
            throw new NotImplementedException();
        }
    }
}
