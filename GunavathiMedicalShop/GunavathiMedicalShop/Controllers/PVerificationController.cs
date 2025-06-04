using GunavathiMedicalShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GunavathiMedicalShop.Controllers
{
    public class PVerificationController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: PVerification
        public ActionResult Index()
        {
            List<PVerificationModel> verify = new List<PVerificationModel>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPresVerification_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

               SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    verify.Add(new PVerificationModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        PName = sdr["PName"].ToString(),
                        PresimagePath = sdr["PresimagePath"].ToString(),
                        verifystatus = sdr["verifystatus"].ToString(),
                        pharmacistnotes = sdr["pharmacistnotes"].ToString()

                    });


                }

                conn.Close();
            }

            return View(verify);
        }

        // GET: PVerification/Details/5
        public ActionResult Details(int id)
        {
            PVerificationModel verify = new PVerificationModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPresVerification_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    verify = new PVerificationModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        PName = sdr["PName"].ToString(),
                        PresimagePath = sdr["PresimagePath"].ToString(),
                        verifystatus = sdr["verifystatus"].ToString(),
                        pharmacistnotes = sdr["pharmacistnotes"].ToString()

                    };


                }

                conn.Close();
            }

            return View(verify);
        }

        // GET: PVerification/Create
        public ActionResult Create()
        {

            PVerificationModel verification = new PVerificationModel();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "Choose..", Text = "Choose" });
            list.Add(new SelectListItem() { Value = "Verified", Text = "Verified" });
            list.Add(new SelectListItem() { Value = "Pending", Text = "Pending" });
            list.Add(new SelectListItem() { Value = "Rejected", Text = "Rejected" });
            verification.StatusList = list;
            
            return View(verification);
        }

        // POST: PVerification/Create
        [HttpPost]
        public ActionResult Create(PVerificationModel verification)
        {
            try
            {
                // TODO: Add insert logic here

                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Value = "Choose..", Text = "Choose" });
                list.Add(new SelectListItem() { Value = "Verified", Text = "Verified" });
                list.Add(new SelectListItem() { Value = "Pending", Text = "Pending" });
                list.Add(new SelectListItem() { Value = "Rejected", Text = "Rejected" });
                verification.StatusList = list;

                HttpPostedFileBase upload = verification.TEMP_PROFILE;
                if (upload != null)
                {
                    string Extension = Path.GetExtension(verification.TEMP_PROFILE.FileName);
                    string imagename = verification.PName + Extension;
                    verification.PresimagePath = imagename;
                    string imagepath = Path.Combine(Server.MapPath("~/Content/PrescriptionImage/"+imagename));
                    verification.TEMP_PROFILE.SaveAs(imagepath);


                }
                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblPresVerification_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@PName", verification.PName);
                    cmd.Parameters.AddWithValue("@PresimagePath", verification.PresimagePath);
                    cmd.Parameters.AddWithValue("@verifystatus", verification.verifystatus);
                    cmd.Parameters.AddWithValue("@pharmacistnotes", verification.pharmacistnotes);
                   
                    
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

        // GET: PVerification/Edit/5
        public ActionResult Edit(int id)
        {
            PVerificationModel verification = new PVerificationModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPresVerification_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    verification = new PVerificationModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        PName = sdr["PName"].ToString(),
                        PresimagePath = sdr["PresimagePath"].ToString(),
                        verifystatus = sdr["verifystatus"].ToString(),
                        pharmacistnotes = sdr["pharmacistnotes"].ToString()

                    };


                }

                conn.Close();
            }

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "Choose..", Text = "Choose" });
            list.Add(new SelectListItem() { Value = "Verified", Text = "Verified" });
            list.Add(new SelectListItem() { Value = "Pending", Text = "Pending" });
            list.Add(new SelectListItem() { Value = "Rejected", Text = "Rejected" });
            verification.StatusList = list;


            return View(verification);
        }

        // POST: PVerification/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PVerificationModel verification)
        {
            try
            {
                // TODO: Add update logic here

                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Value = "Choose..", Text = "Choose" });
                list.Add(new SelectListItem() { Value = "Verified", Text = "Verified" });
                list.Add(new SelectListItem() { Value = "Pending", Text = "Pending" });
                list.Add(new SelectListItem() { Value = "Rejected", Text = "Rejected" });
                verification.StatusList = list;

                HttpPostedFileBase upload = verification.TEMP_PROFILE;
                if (upload != null)
                {
                    string Extension = Path.GetExtension(verification.TEMP_PROFILE.FileName);
                    string imagename = verification.PName + Extension;
                    verification.PresimagePath = imagename;
                    string imagepath = Path.Combine(Server.MapPath("~/Content/PrescriptionImage/" + imagename));
                    verification.TEMP_PROFILE.SaveAs(imagepath);


                }
                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblPresVerification_Edit", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);

                    cmd.Parameters.AddWithValue("@PName", verification.PName);
                    cmd.Parameters.AddWithValue("@PresimagePath", verification.PresimagePath);
                    cmd.Parameters.AddWithValue("@verifystatus", verification.verifystatus);
                    cmd.Parameters.AddWithValue("@pharmacistnotes", verification.pharmacistnotes);


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

        // GET: PVerification/Delete/5
        public ActionResult Delete(int id)
        {
            PVerificationModel verify = new PVerificationModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPresVerification_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    verify = new PVerificationModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        PName = sdr["PName"].ToString(),
                        PresimagePath = sdr["PresimagePath"].ToString(),
                        verifystatus = sdr["verifystatus"].ToString(),
                        pharmacistnotes = sdr["pharmacistnotes"].ToString()

                    };


                }

                conn.Close();
            }

            return View(verify);

        }

        // POST: PVerification/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string profile)
        {
            try
            {
                // TODO: Add delete logic here

                string path = Request.MapPath("~/Content/PrescriptionImage/" + profile);
                if (System.IO.File.Exists(path))
                { 
                
                    System.IO.File.Delete(path);
                }

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblPresVerification_Delete", conn);
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
            List<PVerificationModel> verify = new List<PVerificationModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPresVerification_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    verify.Add(new PVerificationModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        PName = sdr["PName"].ToString(),
                        PresimagePath = sdr["PresimagePath"].ToString(),
                        verifystatus = sdr["verifystatus"].ToString(),
                        pharmacistnotes = sdr["pharmacistnotes"].ToString()

                    });


                }

                conn.Close();
            }

            return View(verify);
        }






        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<PVerificationModel> verify = new List<PVerificationModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblPresVerification_Search", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    verify.Add(new PVerificationModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        PName = sdr["PName"].ToString(),
                        PresimagePath = sdr["PresimagePath"].ToString(),
                        verifystatus = sdr["verifystatus"].ToString(),
                        pharmacistnotes = sdr["pharmacistnotes"].ToString()

                    });


                }

                conn.Close();
            }

            return View(verify);
        }



















































    }
}
