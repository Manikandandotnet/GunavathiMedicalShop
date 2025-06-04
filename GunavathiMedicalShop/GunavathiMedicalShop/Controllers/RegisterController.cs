using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using GunavathiMedicalShop.Models;
using System.Web.Helpers;

namespace GunavathiMedicalShop.Controllers
{
    public class RegisterController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        // GET: Register
        public ActionResult Index()
        {
            List<RegisterModel> regobj = new List<RegisterModel>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblRegister_VWAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {

                    regobj.Add(new RegisterModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        Usernames = sdr["Usernames"].ToString(),
                        UserType = sdr["UserType"].ToString(),
                        Email = sdr["Email"].ToString(),
                        ContactNo = sdr["ContactNo"].ToString(),
                        Addresses = sdr["Addresses"].ToString(),
                        Passwords = sdr["Passwords"].ToString(),
                        CPasswords = sdr["CPasswords"].ToString()

                    });


                }

                conn.Close();

            }




            return View(regobj);
        }

        // GET: Register/Details/5
        public ActionResult Details(int id)
        {
           RegisterModel regobj = new RegisterModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblRegister_VEone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("@id",id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    regobj = new RegisterModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        Usernames = sdr["Usernames"].ToString(),
                        UserType = sdr["UserType"].ToString(),
                        Email = sdr["Email"].ToString(),
                        ContactNo = sdr["ContactNo"].ToString(),
                        Addresses = sdr["Addresses"].ToString(),
                        Passwords = sdr["Passwords"].ToString(),
                        CPasswords = sdr["CPasswords"].ToString()

                    };


                }

                conn.Close();

            }




            return View(regobj);
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            RegisterModel regobj = new RegisterModel();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "Choose...", Text = "Choose" });
            list.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
            list.Add(new SelectListItem() { Value = "Staff", Text = "Staff" });

            regobj.usertypelist = list;

            return View(regobj  );
        }

        // POST: Register/Create
        [HttpPost]
        public ActionResult Create(RegisterModel regobj)
        {
            try
            {
                // TODO: Add insert logic here

                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Value = "Choose...", Text = "Choose" });
                list.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
                list.Add(new SelectListItem() { Value = "Staff", Text = "Staff" });

                regobj.usertypelist = list;

                using(SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblRegister_Add", conn);
                    cmd.CommandType= System.Data.CommandType.StoredProcedure;
 

                    cmd.Parameters.AddWithValue("@Usernames", regobj.Usernames);
                    cmd.Parameters.AddWithValue("@UserType", regobj.UserType);
                    cmd.Parameters.AddWithValue("@Email", regobj.Email);
                    cmd.Parameters.AddWithValue("@ContactNo", regobj.ContactNo);
                    cmd.Parameters.AddWithValue("@Addresses", regobj.Addresses);
                    cmd.Parameters.AddWithValue("@Passwords", regobj.Passwords);
                    cmd.Parameters.AddWithValue("@CPasswords", regobj.CPasswords);

                    int i =cmd.ExecuteNonQuery();
                    if(i > 0)
                    {
                        TempData["Message"] = "Inserted Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Inserted Failed!";
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

        // GET: Register/Edit/5
        public ActionResult Edit(int id)
        {
            RegisterModel regobj = new RegisterModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblRegister_VEone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    regobj = new RegisterModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        Usernames = sdr["Usernames"].ToString(),
                        UserType = sdr["UserType"].ToString(),
                        Email = sdr["Email"].ToString(),
                        ContactNo = sdr["ContactNo"].ToString(),
                        Addresses = sdr["Addresses"].ToString(),
                        Passwords = sdr["Passwords"].ToString(),
                        CPasswords = sdr["CPasswords"].ToString()

                    };


                }

                conn.Close();

            }
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "Choose...", Text = "Choose" });
            list.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
            list.Add(new SelectListItem() { Value = "Staff", Text = "Staff" });

            regobj.usertypelist = list;





            return View(regobj);

        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RegisterModel regobj)
        {
            try
            {
                // TODO: Add update logic here

                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Value = "Choose...", Text = "Choose" });
                list.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
                list.Add(new SelectListItem() { Value = "Staff", Text = "Staff" });

                regobj.usertypelist = list;

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblRegister_Edit", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id",id);

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
                        TempData["Message"] = "Updated Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Updated Failed!";
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

        // GET: Register/Delete/5
        public ActionResult Delete(int id)
        {
            RegisterModel regobj = new RegisterModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblRegister_VEone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    regobj = new RegisterModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        Usernames = sdr["Usernames"].ToString(),
                        UserType = sdr["UserType"].ToString(),
                        Email = sdr["Email"].ToString(),
                        ContactNo = sdr["ContactNo"].ToString(),
                        Addresses = sdr["Addresses"].ToString(),
                        Passwords = sdr["Passwords"].ToString(),
                        CPasswords = sdr["CPasswords"].ToString()

                    };


                }

                conn.Close();

            }




            return View(regobj);

        }

        // POST: Register/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblRegister_Delete", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Message"] = "Deleted Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Deleted Failed!";
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
            List<RegisterModel> regobj = new List<RegisterModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblRegister_VWAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    regobj.Add(new RegisterModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        Usernames = sdr["Usernames"].ToString(),
                        UserType = sdr["UserType"].ToString(),
                        Email = sdr["Email"].ToString(),
                        ContactNo = sdr["ContactNo"].ToString(),
                        Addresses = sdr["Addresses"].ToString(),
                        Passwords = sdr["Passwords"].ToString(),
                        CPasswords = sdr["CPasswords"].ToString()

                    });


                }

                conn.Close();

            }




            return View(regobj);
        }



        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<RegisterModel> regobj = new List<RegisterModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblregister_Search", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    regobj.Add(new RegisterModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        Usernames = sdr["Usernames"].ToString(),
                        UserType = sdr["UserType"].ToString(),
                        Email = sdr["Email"].ToString(),
                        ContactNo = sdr["ContactNo"].ToString(),
                        Addresses = sdr["Addresses"].ToString(),
                        Passwords = sdr["Passwords"].ToString(),
                        CPasswords = sdr["CPasswords"].ToString()

                    });


                }

                conn.Close();

            }




            return View(regobj);
        }









        public ActionResult LoginUser()
        {
            RegisterModel regobj = new RegisterModel();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "Choose...", Text = "Choose" });
            list.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
            list.Add(new SelectListItem() { Value = "Staff", Text = "Staff" });

            regobj.usertypelist = list;

            return View(regobj);
        }





        // POST: Register/Create
        [HttpPost]
        public ActionResult LoginUser(RegisterModel regobj)
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
                    SqlCommand cmd = new SqlCommand("SP_LoginCheck", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@Usernames", regobj.Usernames);
                    cmd.Parameters.AddWithValue("@UserType", regobj.UserType);
                    cmd.Parameters.AddWithValue("@CPasswords", regobj.CPasswords);



                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {

                        TempData["Message"] = "lOGIN Successfully !";

                        if (regobj.UserType == "Admin")
                        {
                            //Action Name, Controller Name
                      return RedirectToAction("AdminPage", "Register");

                        }
                        else if (regobj.UserType == "Staff")
                        {
                            //Action Name, Controller Name
                            return RedirectToAction("StaffPage", "HomePage");
                        }
                        else if (regobj.UserType == "Student")
                        {
                            Session["user"] = regobj.Usernames.ToString();
                      
                            
                            
                            //Action Name, Controller Name
                            return RedirectToAction("StudentMark");

                        }
                        else
                        {
                            ViewData["Message"] = "you are not a Registered User !";


                        }





                    }
                    else
                    {
                        ViewData["Message"] = "lOGIN Failed !";

                        return View(regobj);
                    }

                    conn.Close();

                }
                return View();
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }






        public ActionResult AdminPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminPage(string a)
        {
            return View();
        }



        public ActionResult StaffPage()
            { return View(); }



        [HttpPost]
        public ActionResult StaffPage(string a)
        { return View(); }















































    }
}
