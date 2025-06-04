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
    public class IndexPagesController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: IndexPages
        public ActionResult Index()
        {
            return View();
        }

        // GET: IndexPages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndexPages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndexPages/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: IndexPages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndexPages/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: IndexPages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndexPages/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        public ActionResult HomePage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HomePage(CallBackRequestModel call)
        {


            try
            {
                // TODO: Add insert logic here


                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tbl_Request_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", call.Name);
                    cmd.Parameters.AddWithValue("@PhoneNumber", call.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", call.Email);
                    cmd.Parameters.AddWithValue("@Selectmedicine", call.Selectmedicine);
                    cmd.Parameters.AddWithValue("@Message", call.Message);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ViewData["Message"] = "Data Inserted Successfully!";

                        call.Name = "";
                        call.PhoneNumber = "";
                        call.Email = "";
                        call.Selectmedicine = "";
                        call.Message = "";


                    }
                    else
                    {
                        ViewData["Error"] = "Data Inserted Failed!";
                    }

                    conn.Close();
                }
                ModelState.Clear();

                return View(call);
            }
            catch
            {
                return View();
            }




        
        }



        public ActionResult AboutPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AboutPage(string a)
        {
            return View();
        }





        public ActionResult ContactPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactPage(CallBackRequestModel call)
        {

            try
            {
                // TODO: Add insert logic here


                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tbl_Request_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", call.Name);
                    cmd.Parameters.AddWithValue("@PhoneNumber", call.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", call.Email);
                    cmd.Parameters.AddWithValue("@Selectmedicine", call.Selectmedicine);
                    cmd.Parameters.AddWithValue("@Message", call.Message);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ViewData["Message"] = "Data Inserted Successfully!";


                        call.Name = "";
                        call.PhoneNumber = "";
                        call.Email = "";
                        call.Selectmedicine = "";
                        call.Message = "";

                    }
                    else
                    {
                        ViewData["Error"] = "Data Inserted Failed!";
                    }

                    conn.Close();
                }
                ModelState.Clear();

                return View(call);
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Medicine()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Medicine(string a)
        {
            return View();
        }


        public ActionResult Buying()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buying(string a)
        {
            return View();
        }





        public ActionResult Register()
        {
            RegisterModel regobj = new RegisterModel();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "Choose...", Text = "Choose" });
            list.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
            list.Add(new SelectListItem() { Value = "Staff", Text = "Staff" });

            regobj.usertypelist = list;

            return View(regobj);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel regobj)
        {
            try
            {
                // TODO: Add insert logic here

                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Value = "Choose...", Text = "Choose" });
                list.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
                list.Add(new SelectListItem() { Value = "Staff", Text = "Staff" });

                regobj.usertypelist = list;

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblRegister_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@Usernames", regobj.Usernames);
                    cmd.Parameters.AddWithValue("@UserType", regobj.UserType);
                    cmd.Parameters.AddWithValue("@Email", regobj.Email);
                    cmd.Parameters.AddWithValue("@ContactNo", regobj.ContactNo);
                    cmd.Parameters.AddWithValue("@Addresses", regobj.Addresses);
                    cmd.Parameters.AddWithValue("@Passwords", regobj.Passwords);
                    cmd.Parameters.AddWithValue("@CPasswords", regobj.CPasswords);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ViewData["Message"] = "Inserted Successfully!";

                        regobj.Usernames = "";
                        regobj.UserType = "";
                        regobj.Email = "";
                        regobj.ContactNo = "";
                        regobj.Addresses = "";
                        regobj.Passwords = "";
                        regobj.CPasswords = "";
                    }
                    else
                    {
                        ViewData["Error"] = "Inserted Failed!";
                    }
                    conn.Close();
                }


                ModelState.Clear();



                return View(regobj);
            }
            catch
            {
                return View();
            }

        }






        public ActionResult Login()
        {
            RegisterModel regobj = new RegisterModel();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "Choose...", Text = "Choose" });
            list.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
            list.Add(new SelectListItem() { Value = "Staff", Text = "Staff" });

            regobj.usertypelist = list;

            return View(regobj);
        }

        [HttpPost]
        public ActionResult Login(string a)
        {
            return View();
        }












































    }
}
