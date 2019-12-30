using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace BookProj.Controllers
{
    public class AddCartController : Controller
    {
        public ActionResult AddCart(string BookId)
        {
            ViewBag.BookId = BookId;

            if (this.Request.RequestType != "POST")
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("BookId");
                dt.Columns.Add("BookName");
                dt.Columns.Add("Price");
                dt.Columns.Add("BookImage");


                if (Request.QueryString["BookId"] != null)
                {
                    if (Session["Buyitems"] == null)
                    {

                        dr = dt.NewRow();
                        String mycon = "Data Source=DESKTOP-MBHBPT2\\SQLEXPRESS;Initial Catalog=Bookdb;Integrated Security=True";
                        SqlConnection scon = new SqlConnection(mycon);
                        String myquery = "select * from Booktbl where BookId=" + Request.QueryString["BookId"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = myquery;
                        cmd.Connection = scon;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = 1;
                        dr["BookId"] = ds.Tables[0].Rows[0]["BookId"].ToString();
                        dr["BookName"] = ds.Tables[0].Rows[0]["BookName"].ToString();
                        dr["BookImage"] = ds.Tables[0].Rows[0]["BookImage"].ToString();
                        dr["Price"] = ds.Tables[0].Rows[0]["Price"].ToString();
                        dt.Rows.Add(dr);
                        //GridView1.DataSource = dt;
                        // GridView1.DataBind();
                        Session["buyitems"] = dt;
                    }
                    else
                    {

                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        String mycon = "Data Source=DESKTOP-MBHBPT2\\SQLEXPRESS;Initial Catalog=Bookdb;Integrated Security=True";
                        SqlConnection scon = new SqlConnection(mycon);
                        String myquery = "select * from Booktbl where BookId=" + Request.QueryString["BookId"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = myquery;
                        cmd.Connection = scon;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = sr + 1;
                        dr["BookId"] = ds.Tables[0].Rows[0]["BookId"].ToString();
                        dr["BookName"] = ds.Tables[0].Rows[0]["BookName"].ToString();
                        dr["BookImage"] = ds.Tables[0].Rows[0]["BookImage"].ToString();
                        dr["Price"] = ds.Tables[0].Rows[0]["Price"].ToString();
                        dt.Rows.Add(dr);
                        // GridView1.DataSource = dt;
                        // GridView1.DataBind();
                        Session["buyitems"] = dt;

                    }
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    // GridView1.DataSource = dt;
                    // GridView1.DataBind();

                }
            }

            return RedirectToAction("Index", "ShowCart");
        }
	}
}