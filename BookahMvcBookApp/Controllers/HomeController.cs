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
            var query = db.viewallbooks.ToList();
            return View(query);
        }

        
        public ActionResult Single(int id)
        {
            var query = db.viewallbooks.FirstOrDefault(m => m.BookId == id);
            return View(query);
        }



        #region add to cart

        public ActionResult AddtoCart(int id)
        {
            var query = db.tblBooks.Where(x => x.BookId == id).SingleOrDefault();
            return View(query);
        }

        [HttpPost]
        public ActionResult AddtoCart(int id, int qty)
        {
            tblBook b = db.tblBooks.Where(x => x.BookId == id).SingleOrDefault();
            Cart c = new Cart();
            c.bookid = id;
            c.bookname = b.Title;
            c.price = Convert.ToInt32(b.Unit);
            c.quantity = Convert.ToInt32(qty);
            c.bill = c.price * c.quantity;
            if (TempData["cart"] == null)
            {
                li.Add(c);
                TempData["cart"] = li;
            }
            else
            {
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.bookid == c.bookid)
                    {
                        item.quantity += c.quantity;
                        item.bill += c.bill;
                        flag = 1;
                    }

                }
                if (flag == 0)
                {
                    li2.Add(c);
                    //new item
                }
                TempData["cart"] = li2;

            }

            TempData.Keep();

            return RedirectToAction("Index");
        }

        #endregion

        #region checkout code

        public ActionResult Checkout()
        {
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(string contact, string address)
        {
            if (ModelState.IsValid)
            {
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                tblInvoice iv = new tblInvoice();
                iv.UserId = Convert.ToInt32(Session["uid"].ToString());
                iv.InvoiceDate = System.DateTime.Now;
                iv.Bill = (int)TempData["total"];
                iv.Payment = "cash";
                db.tblInvoices.Add(iv);
                db.SaveChanges();
                //order book
                foreach (var item in li2)
                {
                    tblOrder od = new tblOrder();
                    od.BookId = item.bookid;
                    od.Contact = contact;
                    od.Address = address;
                    od.OrderDate = System.DateTime.Now;
                    od.InvoiceId = iv.InvoiceId;
                    od.Quantity = item.quantity;
                    od.Unit = item.price;
                    od.Total = item.bill;

                    db.tblOrders.Add(od);
                    db.SaveChanges();

                }
                TempData.Remove("total");
                TempData.Remove("cart");
                // TempData["msg"] = "Order Book Successfully!!";
                return RedirectToAction("Index");
            }

            TempData.Keep();
            return View();
        }

        #endregion
    }
}