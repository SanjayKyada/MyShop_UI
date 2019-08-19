using Core.Contract;
using Core.Model;
using System.Linq;
using System.Web.Mvc;

namespace MyShop_UI.Controllers
{
    public class CategoryController : Controller
    {
        IRepositoryBase<Category> categories;

        public CategoryController(IRepositoryBase<Category> categoryObj)
        {
            categories = categoryObj;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(categories.GetAllData().ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category categoryObj)
        {
            if (ModelState.IsValid)
            {
                categories.Add(categoryObj);
                categories.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(string ID)
        {
            if (ModelState.IsValid)
                return View(categories.GetDetail(ID));
            else
                return View();
        }

        [HttpPost]
        public ActionResult Edit(Category newCatObj, string Id)
        {
            if (ModelState.IsValid)
            {
                Category oldCategory = categories.GetDetail(Id);
                oldCategory.Name = newCatObj.Name;
                categories.Commit();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public ActionResult Delete(string ID)
        {
            if (ModelState.IsValid)
            {
                return View(categories.GetDetail(ID));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            if (ModelState.IsValid)
            {
                categories.DeleteObject(ID);
                categories.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}