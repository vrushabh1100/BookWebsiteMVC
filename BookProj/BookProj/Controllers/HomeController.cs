using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookProj.Models;
using System.Data;
using System.Data.SqlClient;

namespace BookProj.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            TempData["msg"] = "";
            String mycon = "Data Source=DESKTOP-MBHBPT2\\SQLEXPRESS; Initial Catalog=Bookdb; Integrated Security=True";
            String myquery = "Select * from Booktbl";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            ProductDetails pd1 = new ProductDetails();
            List<ProductDetails> productlist = new List<ProductDetails>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ProductDetails pd = new ProductDetails();
                pd.BookId = Convert.ToInt32(ds.Tables[0].Rows[i]["BookId"].ToString());
                pd.BookName = ds.Tables[0].Rows[i]["BookName"].ToString();
                pd.Price = Convert.ToInt64(ds.Tables[0].Rows[i]["Price"].ToString());
                pd.BookImage = ds.Tables[0].Rows[i]["BookImage"].ToString();
                productlist.Add(pd);
            }
            pd1.productlist = productlist;
            con.Close();

            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["buyitems"];
            if (dt1 != null)
            {

                ViewBag.cartnumber = dt1.Rows.Count.ToString();
            }
            else
            {
                ViewBag.cartnumber = "0";
            }

            return View(pd1);
        }
	}
}