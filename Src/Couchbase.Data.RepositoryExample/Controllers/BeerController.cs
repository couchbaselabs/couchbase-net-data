using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Couchbase.Data.RepositoryExample.Models;
using Couchbase.Data.RepositoryExample.Models.Repositories;

namespace Couchbase.Data.RepositoryExample.Controllers
{
    public class BeerController : Controller
    {
        private BeerRepository _repository;

        public BeerController()
            : this(new BeerRepository(ClusterHelper.GetBucket("beer-sample")))
        {
        }

        public BeerController(BeerRepository repository)
        {
            _repository = repository;
        }

        // GET: Beer
        public ActionResult Index()
        {
            return View(_repository.SelectBeers(0, 10));
        }

        // GET: Beer/Details/5
        public ActionResult Details(string id)
        {
            return View(_repository.Find(id));
        }

        // GET: Beer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beer/Create
        [HttpPost]
        public ActionResult Create(Beer beer)
        {
            try
            {
                _repository.Save(beer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Beer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Beer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
