using GunavathiMedicalShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace GunavathiMedicalShop.Controllers
{
    public class MedicationListController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        // GET: MedicationList
        public ActionResult Index()
        {

           List<MedicationListModel> medicine = new List<MedicationListModel>();

            using(SqlConnection conn = new SqlConnection(strcon))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_Medicationlist_VWall", conn);

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    medicine.Add(new MedicationListModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        ProductID = sdr["ProductID"].ToString(),
                        Name = sdr["Name"].ToString(),
                        Description = sdr["Description"].ToString(),
                        price = sdr["price"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Expirationdate = Convert.ToDateTime(sdr["Expirationdate"]),
                        ImagePath = sdr["ImagePath"].ToString(),
                        BrandID = sdr["BrandID"].ToString(),
                        BrandName = sdr["BrandName"].ToString(),

                        MedicationBrandID  = sdr["MedicationBrandID"].ToString()


                    });



                }


                conn.Close();
            }




            return View(medicine);
        }

        // GET: MedicationList/Details/5
        public ActionResult Details(int id)
        {
            MedicationListModel medicine = new MedicationListModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_Medicationlist_getone", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    // Read the data from tbl_Medication
                    medicine = new MedicationListModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ProductID = sdr["ProductID"].ToString(),
                        Name = sdr["Name"].ToString(),
                        Description = sdr["Description"].ToString(),
                        price = sdr["price"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Expirationdate = Convert.ToDateTime(sdr["Expirationdate"]),
                        ImagePath = sdr["ImagePath"].ToString(),
                        BrandID = sdr["BrandID"].ToString(),
                        BrandName = sdr["BrandName"].ToString(),

                        MedicationBrandID = sdr["MedicationBrandID"].ToString()
                    };
                }

                conn.Close();
            }

            return View(medicine);
        }


        // GET: MedicationList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicationList/Create
        [HttpPost]
        public ActionResult Create(MedicationListModel medicine)
        {
            try
            {
                // TODO: Add insert logic here

                

                HttpPostedFileBase upload = medicine.TEMP_PROFILE;
                if (upload != null) 
                {
                    string Extension =Path.GetExtension(medicine.TEMP_PROFILE.FileName);
                    string imageName = medicine.Name + Extension;
                    string imagepath = Path.Combine(Server.MapPath("~/Content/profiles/" + imageName));
                    medicine.TEMP_PROFILE.SaveAs(imagepath);

                    // Set the ImagePath property
                  // medicine.ImagePath = "/Content/profiles/" + imageName;

                    medicine.ImagePath = imageName;


                }

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_Medicationlist_Add", conn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@ProductID", medicine.ProductID);
                    cmd.Parameters.AddWithValue("@Name", medicine.Name);
                    cmd.Parameters.AddWithValue("@Description", medicine.Description);
                    cmd.Parameters.AddWithValue("@price", medicine.price);
                    cmd.Parameters.AddWithValue("@Dosage", medicine.Dosage);


                    cmd.Parameters.AddWithValue("@Expirationdate", medicine.Expirationdate);
                    cmd.Parameters.AddWithValue("@ImagePath", medicine.ImagePath);
                    cmd.Parameters.AddWithValue("@BrandID", medicine.BrandID);
                    cmd.Parameters.AddWithValue("@BrandName", medicine.BrandName);
                    cmd.Parameters.AddWithValue("@MedicationBrandID", medicine.MedicationBrandID);


                    int i =cmd.ExecuteNonQuery();
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

        // GET: MedicationList/Edit/5
        public ActionResult Edit(int id)
        {
            MedicationListModel medicine = new MedicationListModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_Medicationlist_getone", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    // Read the data from tbl_Medication
                    medicine = new MedicationListModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ProductID = sdr["ProductID"].ToString(),
                        Name = sdr["Name"].ToString(),
                        Description = sdr["Description"].ToString(),
                        price = sdr["price"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Expirationdate = Convert.ToDateTime(sdr["Expirationdate"]),
                        ImagePath = sdr["ImagePath"].ToString(),
                        BrandID = sdr["BrandID"].ToString(),
                        BrandName = sdr["BrandName"].ToString(),

                        MedicationBrandID = sdr["MedicationBrandID"].ToString()
                    };
                }

                conn.Close();
            }

            return View(medicine);
        }

        // POST: MedicationList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,MedicationListModel medicine)
        {
            try
            {
                // TODO: Add update logic here
                HttpPostedFileBase upload = medicine.TEMP_PROFILE;

                if (upload != null) 
                {
               string Extension =Path.GetExtension(medicine.TEMP_PROFILE.FileName); 
                    string imagename = medicine.Name + Extension;
                    medicine.ImagePath = imagename;

                    string imagepath = Path.Combine(Server.MapPath("~/Content/profiles/" + imagename));
                    medicine.TEMP_PROFILE.SaveAs(imagepath);
                }

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                     SqlCommand cmd = new SqlCommand("SP_Medicationlist_Edit", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id",id);

                    cmd.Parameters.AddWithValue("@ProductID", medicine.ProductID);
                    cmd.Parameters.AddWithValue("@Name", medicine.Name);
                    cmd.Parameters.AddWithValue("@Description", medicine.Description);
                    cmd.Parameters.AddWithValue("@price", medicine.price);
                    cmd.Parameters.AddWithValue("@Dosage", medicine.Dosage);


                    cmd.Parameters.AddWithValue("@Expirationdate", medicine.Expirationdate);
                    cmd.Parameters.AddWithValue("@ImagePath", medicine.ImagePath);
                    cmd.Parameters.AddWithValue("@BrandID", medicine.BrandID);
                    cmd.Parameters.AddWithValue("@BrandName", medicine.BrandName);
                    cmd.Parameters.AddWithValue("@MedicationBrandID", medicine.MedicationBrandID);


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

        // GET: MedicationList/Delete/5
        public ActionResult Delete(int id)
        {
            MedicationListModel medicine = new MedicationListModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_Medicationlist_getone", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    // Read the data from tbl_Medication
                    medicine = new MedicationListModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ProductID = sdr["ProductID"].ToString(),
                        Name = sdr["Name"].ToString(),
                        Description = sdr["Description"].ToString(),
                        price = sdr["price"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Expirationdate = Convert.ToDateTime(sdr["Expirationdate"]),
                        ImagePath = sdr["ImagePath"].ToString(),
                        BrandID = sdr["BrandID"].ToString(),
                        BrandName = sdr["BrandName"].ToString(),

                        MedicationBrandID = sdr["MedicationBrandID"].ToString()
                    };
                }

                conn.Close();
            }

            return View(medicine);
        }

        // POST: MedicationList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string imagepath)
        {
            try
            {
                // TODO: Add delete logic here
                string path = Request.MapPath("~/Content/profiles/" + imagepath);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_medicationlist_Delete", conn);
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

            List<MedicationListModel> medicine = new List<MedicationListModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_Medicationlist_VWall", conn);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    medicine.Add(new MedicationListModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        ProductID = sdr["ProductID"].ToString(),
                        Name = sdr["Name"].ToString(),
                        Description = sdr["Description"].ToString(),
                        price = sdr["price"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Expirationdate = Convert.ToDateTime(sdr["Expirationdate"]),
                        ImagePath = sdr["ImagePath"].ToString(),
                        BrandID = sdr["BrandID"].ToString(),
                        BrandName = sdr["BrandName"].ToString(),

                        MedicationBrandID = sdr["MedicationBrandID"].ToString()


                    });



                }


                conn.Close();
            }




            return View(medicine);
        }



        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<MedicationListModel> medicine = new List<MedicationListModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_Medicationlist_Search", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    medicine.Add(new MedicationListModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ProductID = sdr["ProductID"].ToString(),
                        Name = sdr["Name"].ToString(),
                        Description = sdr["Description"].ToString(),
                        price = sdr["price"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Expirationdate = Convert.ToDateTime(sdr["Expirationdate"]),
                        ImagePath = sdr["ImagePath"].ToString(),
                        BrandID = sdr["BrandID"].ToString(),
                        BrandName = sdr["BrandName"].ToString(),

                        MedicationBrandID = sdr["MedicationBrandID"].ToString()
                    });
                }

                conn.Close();
            }

            return View(medicine); // Assuming you want to display the results in the Index view
        }

























    }
}
