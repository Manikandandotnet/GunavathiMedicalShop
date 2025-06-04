using GunavathiMedicalShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GunavathiMedicalShop.Controllers
{
    public class SalesReportController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: SalesReport
        public ActionResult Index()
        {
         List<SalesReport> sale = new List<SalesReport>();

            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblSalesReport_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    sale.Add(new SalesReport
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ReportID = sdr["ReportID"].ToString(),
                        StartDate =Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        Totalsales = sdr["Totalsales"].ToString(),
                        Avgordervalue = sdr["Avgordervalue"].ToString(),
                        Topsellproducts = sdr["Topsellproducts"].ToString(),

                    });
                }

                conn.Close();
            }
            
            
            
            return View(sale);
        }

        // GET: SalesReport/Details/5
        public ActionResult Details(int id)
        {
            SalesReport sale = new SalesReport();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblSalesReport_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    sale = new SalesReport
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ReportID = sdr["ReportID"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        Totalsales = sdr["Totalsales"].ToString(),
                        Avgordervalue = sdr["Avgordervalue"].ToString(),
                        Topsellproducts = sdr["Topsellproducts"].ToString(),

                    };
                }

                conn.Close();
            }



            return View(sale);
        }

        // GET: SalesReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesReport/Create
        [HttpPost]
        public ActionResult Create(SalesReport sale)
        {
            try
            {
                // TODO: Add insert logic here


                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SP_tblSalesReport_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@ReportID", sale.ReportID);

                    cmd.Parameters.AddWithValue("@StartDate", sale.StartDate);

                    cmd.Parameters.AddWithValue("@EndDate", sale.EndDate);

                    cmd.Parameters.AddWithValue("@Totalsales", sale.Totalsales);

                    cmd.Parameters.AddWithValue("@Avgordervalue", sale.Avgordervalue);

                    cmd.Parameters.AddWithValue("@Topsellproducts", sale.Topsellproducts);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Message"] = "Data Inserted Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data Inserted Failed!";
                    }

                    conn.Close();
                }



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesReport/Edit/5
        public ActionResult Edit(int id)
        {
            SalesReport sale = new SalesReport();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblSalesReport_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    sale = new SalesReport
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ReportID = sdr["ReportID"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        Totalsales = sdr["Totalsales"].ToString(),
                        Avgordervalue = sdr["Avgordervalue"].ToString(),
                        Topsellproducts = sdr["Topsellproducts"].ToString(),

                    };
                }

                conn.Close();
            }



            return View(sale);
        }

        // POST: SalesReport/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,SalesReport sale)
        {
            try
            {
                // TODO: Add update logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SP_tblSalesReport_Edit", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id",id);

                    cmd.Parameters.AddWithValue("@ReportID", sale.ReportID);

                    cmd.Parameters.AddWithValue("@StartDate", sale.StartDate);

                    cmd.Parameters.AddWithValue("@EndDate", sale.EndDate);

                    cmd.Parameters.AddWithValue("@Totalsales", sale.Totalsales);

                    cmd.Parameters.AddWithValue("@Avgordervalue", sale.Avgordervalue);

                    cmd.Parameters.AddWithValue("@Topsellproducts", sale.Topsellproducts);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Message"] = "Data Updated Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data Updated Failed!";
                    }

                    conn.Close();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesReport/Delete/5
        public ActionResult Delete(int id)
        {
            SalesReport sale = new SalesReport();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblSalesReport_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    sale = new SalesReport
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ReportID = sdr["ReportID"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        Totalsales = sdr["Totalsales"].ToString(),
                        Avgordervalue = sdr["Avgordervalue"].ToString(),
                        Topsellproducts = sdr["Topsellproducts"].ToString(),

                    };
                }

                conn.Close();
            }



            return View(sale);
        }

        // POST: SalesReport/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here


                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SP_tblSalesReport_Delete", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Message"] = "Data Deleted Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data Deleted Failed!";
                    }

                    conn.Close();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        public ActionResult Search()
        {
            List<SalesReport> sale = new List<SalesReport>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblSalesReport_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    sale.Add(new SalesReport
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ReportID = sdr["ReportID"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        Totalsales = sdr["Totalsales"].ToString(),
                        Avgordervalue = sdr["Avgordervalue"].ToString(),
                        Topsellproducts = sdr["Topsellproducts"].ToString(),

                    });
                }

                conn.Close();
            }



            return View(sale);
        }


        [HttpPost]   
        public ActionResult Search(string Search)
        {
            List<SalesReport> sale = new List<SalesReport>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblSalesReport_Search", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    sale.Add(new SalesReport
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ReportID = sdr["ReportID"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        Totalsales = sdr["Totalsales"].ToString(),
                        Avgordervalue = sdr["Avgordervalue"].ToString(),
                        Topsellproducts = sdr["Topsellproducts"].ToString(),

                    });
                }

                conn.Close();
            }



            return View(sale);
        }















    }
}
