using GunavathiMedicalShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Xml.Linq;

namespace GunavathiMedicalShop.Controllers
{
    public class CallBackRequestController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: CallBackRequest
        public ActionResult Index()
        {
            List<CallBackRequestModel> call = new List<CallBackRequestModel>();

            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tbl_RequestVWall", conn);
                cmd.CommandType =System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    call.Add(new CallBackRequestModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = sdr["Name"].ToString(),
                        PhoneNumber = sdr["PhoneNumber"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Selectmedicine = sdr["Selectmedicine"].ToString(),
                        Message = sdr["Message"].ToString()

                    });
                }
                conn.Close();   
            }


            return View(call);
        }

        // GET: CallBackRequest/Details/5
        public ActionResult Details(int id)
        {
            CallBackRequestModel call = new CallBackRequestModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tbl_Request_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    call = new CallBackRequestModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = sdr["Name"].ToString(),
                        PhoneNumber = sdr["PhoneNumber"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Selectmedicine = sdr["Selectmedicine"].ToString(),
                        Message = sdr["Message"].ToString()

                    };
                }
                conn.Close();
            }


            return View(call);
        }

        // GET: CallBackRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CallBackRequest/Create
        [HttpPost]
        public ActionResult Create(CallBackRequestModel call)
        {
            try
            {
                // TODO: Add insert logic here


                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tbl_Request_Add", conn);
                    cmd.CommandType= System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", call.Name);
                    cmd.Parameters.AddWithValue("@PhoneNumber", call.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", call.Email);
                    cmd.Parameters.AddWithValue("@Selectmedicine", call.Selectmedicine);
                    cmd.Parameters.AddWithValue("@Message", call.Message);

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

        // GET: CallBackRequest/Edit/5
        public ActionResult Edit(int id)
        {
            CallBackRequestModel call = new CallBackRequestModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tbl_Request_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    call = new CallBackRequestModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = sdr["Name"].ToString(),
                        PhoneNumber = sdr["PhoneNumber"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Selectmedicine = sdr["Selectmedicine"].ToString(),
                        Message = sdr["Message"].ToString()

                    };
                }
                conn.Close();
            }


            return View(call);
        }

        // POST: CallBackRequest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,CallBackRequestModel call)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tbl_Request_Edit", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);

                    cmd.Parameters.AddWithValue("@Name", call.Name);
                    cmd.Parameters.AddWithValue("@PhoneNumber", call.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", call.Email);
                    cmd.Parameters.AddWithValue("@Selectmedicine", call.Selectmedicine);
                    cmd.Parameters.AddWithValue("@Message", call.Message);

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

        // GET: CallBackRequest/Delete/5
        public ActionResult Delete(int id)
        {
            CallBackRequestModel call = new CallBackRequestModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tbl_Request_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    call = new CallBackRequestModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = sdr["Name"].ToString(),
                        PhoneNumber = sdr["PhoneNumber"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Selectmedicine = sdr["Selectmedicine"].ToString(),
                        Message = sdr["Message"].ToString()

                    };
                }
                conn.Close();
            }


            return View(call);
        }

        // POST: CallBackRequest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblRequest_Delete", conn);
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
            List<CallBackRequestModel> call = new List<CallBackRequestModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tbl_RequestVWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    call.Add(new CallBackRequestModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = sdr["Name"].ToString(),
                        PhoneNumber = sdr["PhoneNumber"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Selectmedicine = sdr["Selectmedicine"].ToString(),
                        Message = sdr["Message"].ToString()

                    });
                }
                conn.Close();
            }


            return View(call);
        }


        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<CallBackRequestModel> call = new List<CallBackRequestModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblRequest_Search", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    call.Add(new CallBackRequestModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = sdr["Name"].ToString(),
                        PhoneNumber = sdr["PhoneNumber"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Selectmedicine = sdr["Selectmedicine"].ToString(),
                        Message = sdr["Message"].ToString()

                    });
                }
                conn.Close();
            }


            return View(call);
        }
















































    }
}
