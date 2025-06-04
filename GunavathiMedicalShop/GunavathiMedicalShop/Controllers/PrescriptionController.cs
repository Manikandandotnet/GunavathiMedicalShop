using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using GunavathiMedicalShop.Models;
namespace GunavathiMedicalShop.Controllers
{
    public class PrescriptionController : Controller
    {

        String strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: Prescription
        public ActionResult Index()
        {
           
            List<Prescription> prescription = new List<Prescription>();


            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPrescription_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    prescription.Add(new Prescription
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        PrescriptionID = sdr["PrescriptionID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        DoctorID = sdr["DoctorID"].ToString(),
                       
                        Medication = sdr["Medication"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Frequency = sdr["Frequency"].ToString(),
                        Duration = sdr["Duration"].ToString(),


                    });

                }
                conn.Close();
            }

            return View(prescription);
        }

        // GET: Prescription/Details/5
        public ActionResult Details(int id)
        {
            Prescription prescription = new Prescription();


            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPrescription_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    prescription = new Prescription
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        PrescriptionID = sdr["PrescriptionID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        DoctorID = sdr["DoctorID"].ToString(),

                        Medication = sdr["Medication"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Frequency = sdr["Frequency"].ToString(),
                        Duration = sdr["Duration"].ToString(),


                    };

                }
                conn.Close();
            }

            return View(prescription);
        }

        // GET: Prescription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prescription/Create
        [HttpPost]
        public ActionResult Create(Prescription prescription)
        {
            try
            {
                // TODO: Add insert logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_Medicationlist_Add1", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@PrescriptionID", prescription.PrescriptionID);
                    cmd.Parameters.AddWithValue("@CustomerID", prescription.CustomerID);
                    cmd.Parameters.AddWithValue("@DoctorID", prescription.DoctorID);

                    cmd.Parameters.AddWithValue("@Medication", prescription.Medication);
                    cmd.Parameters.AddWithValue("@Dosage", prescription.Dosage);
                    cmd.Parameters.AddWithValue("@Frequency", prescription.Frequency);
                    cmd.Parameters.AddWithValue("@Duration", prescription.Duration);

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

        // GET: Prescription/Edit/5
        public ActionResult Edit(int id)
        {
            Prescription prescription = new Prescription();


            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPrescription_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    prescription = new Prescription
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        PrescriptionID = sdr["PrescriptionID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        DoctorID = sdr["DoctorID"].ToString(),

                        Medication = sdr["Medication"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Frequency = sdr["Frequency"].ToString(),
                        Duration = sdr["Duration"].ToString(),


                    };

                }
                conn.Close();
            }

            return View(prescription);

        }


        // POST: Prescription/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Prescription prescription)
        {
            try
            {
                // TODO: Add update logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblPrescription_Edit", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id",id);

                    cmd.Parameters.AddWithValue("@PrescriptionID", prescription.PrescriptionID);
                    cmd.Parameters.AddWithValue("@CustomerID", prescription.CustomerID);
                    cmd.Parameters.AddWithValue("@DoctorID", prescription.DoctorID);

                    cmd.Parameters.AddWithValue("@Medication", prescription.Medication);
                    cmd.Parameters.AddWithValue("@Dosage", prescription.Dosage);
                    cmd.Parameters.AddWithValue("@Frequency", prescription.Frequency);
                    cmd.Parameters.AddWithValue("@Duration", prescription.Duration);

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

        
        
        // GET: Prescription/Delete/5
        public ActionResult Delete(int id)
        {
            Prescription prescription = new Prescription();


            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPrescription_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    prescription = new Prescription
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        PrescriptionID = sdr["PrescriptionID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        DoctorID = sdr["DoctorID"].ToString(),

                        Medication = sdr["Medication"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Frequency = sdr["Frequency"].ToString(),
                        Duration = sdr["Duration"].ToString(),


                    };

                }
                conn.Close();
            }

            return View(prescription);

        }



        // POST: Prescription/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblPrescription_Delete", conn);
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

            List<Prescription> prescription = new List<Prescription>();


            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPrescription_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    prescription.Add(new Prescription
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        PrescriptionID = sdr["PrescriptionID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        DoctorID = sdr["DoctorID"].ToString(),

                        Medication = sdr["Medication"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Frequency = sdr["Frequency"].ToString(),
                        Duration = sdr["Duration"].ToString(),


                    });

                }
                conn.Close();
            }

            return View(prescription);
        }


        [HttpPost]
        public ActionResult Search(string Search)
        {

            List<Prescription> prescription = new List<Prescription>();


            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPrescription_Search", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    prescription.Add(new Prescription
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        PrescriptionID = sdr["PrescriptionID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        DoctorID = sdr["DoctorID"].ToString(),

                        Medication = sdr["Medication"].ToString(),
                        Dosage = sdr["Dosage"].ToString(),
                        Frequency = sdr["Frequency"].ToString(),
                        Duration = sdr["Duration"].ToString(),


                    });

                }
                conn.Close();
            }

            return View(prescription);
        }























    }
}
