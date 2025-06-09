using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nnhNetCoreMVCLAB5.Models;

namespace nnhNetCoreMVCLAB5.Controllers
{
    public class nnhAccountController : Controller
    {
        public static List<nnhAccount> accounts = new List<nnhAccount>();
        // GET: nnhAccountController
        public ActionResult nnhIndex()
        {
            List<nnhAccount > accounts = new List<nnhAccount>();
            return View(accounts);  
        }

        // GET: nnhAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: nnhAccountController/Create
        public ActionResult nnhCreate()
        {
            nnhAccount model = new nnhAccount();
            return View(model);
        }

        // POST: nnhAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(nnhAccount model)
        {
            try
            {
                // Tự động sinh mã nếu cần
                if (model.NnhId == 0)
                {
                    model.NnhId = accounts.Max(e => e.NnhId) + 1;
                }
                accounts.Add(model);
                return RedirectToAction(nameof(nnhIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: nnhAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: nnhAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: nnhAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: nnhAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
