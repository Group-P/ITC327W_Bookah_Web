using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookahMvcBookApp.Models
{
    public class Cart
    {
        public int bookid { get; set; }

        public string bookname{ get; set; }

        public int quantity { get; set; }

        public int price { get; set; }

        public int bill { get; set; }
    }
}