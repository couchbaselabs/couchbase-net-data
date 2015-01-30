using System;
using System.Web.Mvc;
using Couchbase.Data.Example.Models.DAOs;
using Couchbase.Data.Example.Models.DTOs;

namespace Couchbase.Data.Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly BeerDao _beerDao;

        public HomeController()
            : this(new BeerDao(ClusterHelper.GetBucket("beer-sample")))
        {
        }

        public HomeController(BeerDao beerDao)
        {
            _beerDao = beerDao;
        }

        public ActionResult Index()
        {
            return View(_beerDao.GetAllBeers(10, 0));
        }

        public ActionResult Details(string id)
        {
            return View(_beerDao.Select(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Beer beer)
        {
            try
            {
                beer.Updated = DateTime.Now;
                _beerDao.Insert(beer);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            return View(_beerDao.Select(id));
        }

        [HttpPost]
        public ActionResult Edit(string id, Beer updated)
        {
            try
            {
                var beer = _beerDao.Select(id);
                beer.Abv = updated.Abv;
                beer.Ibu = updated.Ibu;
                beer.Name = updated.Name;
                beer.Srm = updated.Srm;
                beer.Style = updated.Style;
                beer.BreweryId = updated.BreweryId;
                beer.Description = updated.Description;
                beer.Updated = DateTime.Now;
                _beerDao.Update(beer);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            return View(_beerDao.Select(id));
        }

        [HttpPost]
        public ActionResult Delete(string id, Beer deletedBeer)
        {
            try
            {
                var beer = _beerDao.Select(id);
                _beerDao.Remove(beer);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
    }
}
