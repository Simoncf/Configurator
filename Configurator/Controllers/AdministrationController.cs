using Configurator.Services.IServices;
using Configurator.Services.ServiceModels;
using Configurator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Configurator.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        IUserService _userService;
        IProductService _productService;
        IPartService _partService;
        IItemTypeService _typeService;
        IItemService _itemService;
        IOrderService _orderService;
        IFinalDesignService _finalDesignService;


        public AdministrationController(IProductService productService, IPartService partService, IItemTypeService typeService,
            IItemService itemService, IUserService userService, IOrderService orderService, IFinalDesignService finalDesignService)
        {
            _productService = productService;
            _partService = partService;
            _typeService = typeService;
            _itemService = itemService;
            _userService = userService;
            _orderService = orderService;
            _finalDesignService = finalDesignService;
        }
        // GET: Administration
        public ActionResult Index()
        {
            var user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            if (user.IsAdmin == true)
            {
                return View();
            }
            else
                return View("RedirectToRegiIfNotAdmin");

        }
        public ActionResult AddNewProduct()
        {
            var model = new AdminAddNewViewModel { Products = _productService.GetAllProducts() };
            return View(model);
        }
        [HttpPost]
        public void SaveProduct(ProductModel model)
        {
            _productService.SaveProduct(model);
        }

        public ActionResult AddNewPart(int id)
        {
            var model = new AdminPartsViewModel { Parts = _partService.GetAllParts(id), ProductId = id };
            return View(model);
        }
        [HttpPost]
        public void SavePart(PartModel model)
        {
            _partService.SavePart(model);
        }
        public ActionResult AddNewItemType(int id)
        {
            var model = new AdminItemTypesViewModel { ItemTypes = _typeService.GetAllItemTypes(id), PartId = id };
            return View(model);

        }
        [HttpPost]
        public void SaveItemType(ItemTypeModel model)
        {
            _typeService.SaveItemType(model);
        }
        public ActionResult AddNewItem(int id)
        {
            var model = new AdminItemsViewModel { Items = _itemService.GetAllItems(id), ItemTypeId = id };
            return View(model);
        }
        public void SaveItem(ItemModel model)
        {
            _itemService.SaveItem(model);
        }
        public ActionResult Orders()
        {
            var model = new OrdersViewModel { AllOrders = _orderService.GetOrders() };
            return View(model);
        }
        public ActionResult AddPictures()
        {
            var model = new AdminAddPicViewModel { UpbodyItems = _itemService.GetItemsByCode("_UPB_"), LowerBodyItems = _itemService.GetItemsByCode("_LOB_"), FootItems = _itemService.GetItemsByCode("_FOW_") };
            return View(model);
        }
        [HttpPost]
        public ActionResult FileUpload(AdminAddPicViewModel model, HttpPostedFileBase file)
        {
            var code = model.Design.DesignCode;
            if (!_finalDesignService.HasImg(code))
            {
                if (file != null && file.ContentLength > 0)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/App_Data/uploads"), pic);
                    file.SaveAs(path);
                    FinalDesignModel design = new FinalDesignModel();
                    design.DesignCode = model.Design.DesignCode;
                    design.Image = path;
                    _finalDesignService.SaveFinalDesign(design);
                }
                return View("Index");
            }
            else return View("PictureExists");


        }
        [HttpPost]
        public string SaveDesign(FinalDesignModel model)
        {
            _finalDesignService.SaveFinalDesign(model);
            return "Design Saved with an Image";
        }


    }
}