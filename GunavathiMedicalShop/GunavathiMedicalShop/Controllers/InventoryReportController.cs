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
    public class InventoryReportController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: InventoryReport
        public ActionResult Index()
        {
            List<InventoryReportModel> report = new List<InventoryReportModel>();

            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblInventoryReports_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader  sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    report.Add(new InventoryReportModel
                    { 
                    id = Convert.ToInt32(sdr["id"]),
                    Stocklevels = sdr["Stocklevels"].ToString(),
                    Expirationdates = Convert.ToDateTime(sdr["Expirationdates"]),
                    Reorderpoints = sdr["Reorderpoints"].ToString()

                    });
                }
                conn.Close();
            }

            return View(report);
        }

        // GET: InventoryReport/Details/5
        public ActionResult Details(int id)
        {
           InventoryReportModel report = new InventoryReportModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblInventoryReports_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    report = new InventoryReportModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Expirationdates = Convert.ToDateTime(sdr["Expirationdates"]),
                        Reorderpoints = sdr["Reorderpoints"].ToString()

                    };
                }
                conn.Close();
            }

            return View(report);

        }

        // GET: InventoryReport/Create
        public ActionResult Create()
        {
            // Check if TempData contains the values

            

            if (TempData["Stocklevels"] != null && TempData["Reorderpoints"] != null)
            {
                ViewBag.Stocklevels = TempData["Stocklevels"].ToString();
                ViewBag.Reorderpoints = TempData["Reorderpoints"].ToString();
            }



            return View();
        }

        // POST: InventoryReport/Create
        [HttpPost]
        public ActionResult Create(InventoryReportModel report)
        {
            try
            {
                // TODO: Add insert logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblInventoryReports_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Stocklevels", report.Stocklevels);

                    cmd.Parameters.AddWithValue("@Expirationdates", report.Expirationdates);

                    cmd.Parameters.AddWithValue("@Reorderpoints", report.Reorderpoints);


                    int i = cmd.ExecuteNonQuery();

                    if(i>0)
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





        public ActionResult  GetInventoryInfo()
        {
            InventoryModel invent = new InventoryModel();

            int id ,i;        
            i = 1;
            
            if (i > 0)
            {
                id = i;
                

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tbl_InventoryInfo_AutoValue", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader sdr = cmd.ExecuteReader();



                    if (sdr.Read())
                    {
                        TempData["Stocklevels"] = sdr["Stocklevels"].ToString();

                        TempData["Reorderpoints"] = sdr["Reorderpoints"].ToString();
                    }

                    conn.Close();
                }

            }
            i++;

            return RedirectToAction("Index");
        }












        // GET: InventoryReport/Edit/5
        public ActionResult Edit(int id)
        {
            InventoryReportModel report = new InventoryReportModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblInventoryReports_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    report = new InventoryReportModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Expirationdates = Convert.ToDateTime(sdr["Expirationdates"]),
                        Reorderpoints = sdr["Reorderpoints"].ToString()

                    };
                }
                conn.Close();
            }

            return View(report);

        }

        // POST: InventoryReport/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, InventoryReportModel report)
        {
            try
            {
                // TODO: Add update logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblInventoryReports_Edit", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.Parameters.AddWithValue("@Stocklevels", report.Stocklevels);

                    cmd.Parameters.AddWithValue("@Expirationdates", report.Expirationdates);

                    cmd.Parameters.AddWithValue("@Reorderpoints", report.Reorderpoints);


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

        // GET: InventoryReport/Delete/5
        public ActionResult Delete(int id)
        {
            InventoryReportModel report = new InventoryReportModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblInventoryReports_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    report = new InventoryReportModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Expirationdates = Convert.ToDateTime(sdr["Expirationdates"]),
                        Reorderpoints = sdr["Reorderpoints"].ToString()

                    };
                }
                conn.Close();
            }

            return View(report);
        }

        // POST: InventoryReport/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SPtblInventoryReportsDelete", conn);
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
            List<InventoryReportModel> report = new List<InventoryReportModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblInventoryReports_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    report.Add(new InventoryReportModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Expirationdates = Convert.ToDateTime(sdr["Expirationdates"]),
                        Reorderpoints = sdr["Reorderpoints"].ToString()

                    });
                }
                conn.Close();
            }

            return View(report);
        }


        [HttpPost]
        public ActionResult Search( string Search)
        {
            List<InventoryReportModel> report = new List<InventoryReportModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblInventoryReports_Search", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    report.Add(new InventoryReportModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Expirationdates = Convert.ToDateTime(sdr["Expirationdates"]),
                        Reorderpoints = sdr["Reorderpoints"].ToString()

                    });
                }
                conn.Close();
            }

            return View(report);
        }






















    }
}
