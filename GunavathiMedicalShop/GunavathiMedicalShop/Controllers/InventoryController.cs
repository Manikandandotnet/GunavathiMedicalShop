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
    public class InventoryController : Controller
    {

string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: Inventory
        public ActionResult Index()
        {
            List<InventoryModel> invent = new List<InventoryModel>();

            using(SqlConnection conn = new SqlConnection(strcon))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tbl_InventoryInfo_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    invent.Add(new InventoryModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Reorderpoints = sdr["Reorderpoints"].ToString(),
                        SupplierInfo = sdr["SupplierInfo"].ToString(),
                        BatchNo = sdr["BatchNo"].ToString()


                    });

                }
                conn.Close();

            }




            return View(invent);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            InventoryModel invent = new InventoryModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblInventoryInfo_Getont", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    invent = new InventoryModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Reorderpoints = sdr["Reorderpoints"].ToString(),
                        SupplierInfo = sdr["SupplierInfo"].ToString(),
                        BatchNo = sdr["BatchNo"].ToString()


                    };

                }
                conn.Close();

            }

            return View(invent);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
          



            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(InventoryModel invent)
        {
            try
            {
                // TODO: Add insert logic here

                using(SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SP_tblInventoryInfo_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Stocklevels", invent.Stocklevels);

                    cmd.Parameters.AddWithValue("@Reorderpoints", invent.Reorderpoints);
                    cmd.Parameters.AddWithValue("@SupplierInfo", invent.SupplierInfo);
               
                    cmd.Parameters.AddWithValue("@BatchNo", invent.BatchNo);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Message"] = "Data Inserted successfully!";
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

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            InventoryModel invent = new InventoryModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblInventoryInfo_Getont", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    invent = new InventoryModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Reorderpoints = sdr["Reorderpoints"].ToString(),
                        SupplierInfo = sdr["SupplierInfo"].ToString(),
                        BatchNo = sdr["BatchNo"].ToString()


                    };

                }
                conn.Close();

            }

            return View(invent);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,InventoryModel invent)
        {
            try
            {
                // TODO: Add update logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblInventoryInfo_Edit", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id",id);

                    cmd.Parameters.AddWithValue("@Stocklevels", invent.Stocklevels);

                    cmd.Parameters.AddWithValue("@Reorderpoints", invent.Reorderpoints);
                    cmd.Parameters.AddWithValue("@SupplierInfo", invent.SupplierInfo);
                    cmd.Parameters.AddWithValue("@BatchNo", invent.BatchNo);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Message"] = "Data Updated successfully!";
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

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            InventoryModel invent = new InventoryModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblInventoryInfo_Getont", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    invent = new InventoryModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Reorderpoints = sdr["Reorderpoints"].ToString(),
                        SupplierInfo = sdr["SupplierInfo"].ToString(),
                        BatchNo = sdr["BatchNo"].ToString()


                    };

                }
                conn.Close();

            }

            return View(invent);
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SP_tbl_InventoryInfo_Delete", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id",id);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Message"] = "Data Deleted successfully!";
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
            List<InventoryModel> invent = new List<InventoryModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tbl_InventoryInfo_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    invent.Add(new InventoryModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Reorderpoints = sdr["Reorderpoints"].ToString(),
                        SupplierInfo = sdr["SupplierInfo"].ToString(),
                        BatchNo = sdr["BatchNo"].ToString()


                    });

                }
                conn.Close();

            }




            return View(invent);
        }


        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<InventoryModel> invent = new List<InventoryModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblInventoryInfo_Search", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    invent.Add(new InventoryModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Stocklevels = sdr["Stocklevels"].ToString(),
                        Reorderpoints = sdr["Reorderpoints"].ToString(),
                        SupplierInfo = sdr["SupplierInfo"].ToString(),
                        BatchNo = sdr["BatchNo"].ToString()


                    });

                }
                conn.Close();

            }




            return View(invent);
        }



































































    }
}
