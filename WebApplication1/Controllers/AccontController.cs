using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AccontController : Controller
    {
        // GET: AccontController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccontController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccontController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccontController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AccontController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccontController/Edit/5
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

        // GET: AccontController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccontController/Delete/5
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
