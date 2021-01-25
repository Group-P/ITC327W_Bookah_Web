using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookahMvcBookApp.Models;

namespace BookahMvcBookApp.Controllers
{
    public class HomeController : Controller
    {
        dbBookahMvcBookAppEntities1 db = new dbBookahMvcBookAppEntities1();
        List<Cart> li = new List<Cart>();

        // GET: Home
        public ActionResult Index()
        {
            var query = db.tblBooks.ToList();
            return View(query);
        }

        public ActionResult AddtoCart(int id)
        {
            var query = db.tblBooks.Where(x => x.BookId == id).SingleOrDefault(); 
            return View(query);
        }
    }
}