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
    public class DrugHealthInfoController : Controller
    {
string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: DrugHealthInfo
        public ActionResult Index()
        {
            List<DrugHealthInfoModel> drug = new List<DrugHealthInfoModel>();

            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblDrugInfo_VWall", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    drug.Add(new DrugHealthInfoModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Medication = sdr["Medication"].ToString(),
                        Usageinstructions = sdr["Usageinstructions"].ToString(),
                        Sideeffects = sdr["Sideeffects"].ToString(),
                        Interactions = sdr["Interactions"].ToString(),

                    });


                }


                conn.Close();

            }
            return View(drug);
        }

        // GET: DrugHealthInfo/Details/5
        public ActionResult Details(int id)
        {
            DrugHealthInfoModel drug = new DrugHealthInfoModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblDrugInfo_Getone", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    drug = new DrugHealthInfoModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Medication = sdr["Medication"].ToString(),
                        Usageinstructions = sdr["Usageinstructions"].ToString(),
                        Sideeffects = sdr["Sideeffects"].ToString(),
                        Interactions = sdr["Interactions"].ToString(),

                    };


                }


                conn.Close();

            }
            return View(drug);
        }

        // GET: DrugHealthInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugHealthInfo/Create
        [HttpPost]
        public ActionResult Create(DrugHealthInfoModel drug)
        {
            try
            {
                // TODO: Add insert logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SPtblDrugInfo_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Medication", drug.Medication);

                    cmd.Parameters.AddWithValue("@Usageinstructions", drug.Usageinstructions);

                    cmd.Parameters.AddWithValue("@Sideeffects", drug.Sideeffects);

                    cmd.Parameters.AddWithValue("@Interactions", drug.Interactions);

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

        // GET: DrugHealthInfo/Edit/5
        public ActionResult Edit(int id)
        {
            DrugHealthInfoModel drug = new DrugHealthInfoModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblDrugInfo_Getone", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    drug = new DrugHealthInfoModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Medication = sdr["Medication"].ToString(),
                        Usageinstructions = sdr["Usageinstructions"].ToString(),
                        Sideeffects = sdr["Sideeffects"].ToString(),
                        Interactions = sdr["Interactions"].ToString(),

                    };


                }


                conn.Close();

            }
            return View(drug);
        }

        // POST: DrugHealthInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,DrugHealthInfoModel drug)
        {
            try
            {
                // TODO: Add update logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblDrugInfo_Edit", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id",id);

                    cmd.Parameters.AddWithValue("@Medication", drug.Medication);

                    cmd.Parameters.AddWithValue("@Usageinstructions", drug.Usageinstructions);

                    cmd.Parameters.AddWithValue("@Sideeffects", drug.Sideeffects);

                    cmd.Parameters.AddWithValue("@Interactions", drug.Interactions);

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

        // GET: DrugHealthInfo/Delete/5
        public ActionResult Delete(int id)
        {
            DrugHealthInfoModel drug = new DrugHealthInfoModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblDrugInfo_Getone", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    drug = new DrugHealthInfoModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Medication = sdr["Medication"].ToString(),
                        Usageinstructions = sdr["Usageinstructions"].ToString(),
                        Sideeffects = sdr["Sideeffects"].ToString(),
                        Interactions = sdr["Interactions"].ToString(),

                    };


                }


                conn.Close();

            }
            return View(drug);

        }

        // POST: DrugHealthInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblDrugInfo_Delete", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Message"] = "Data  Deleted Successfully!";

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
            List<DrugHealthInfoModel> drug = new List<DrugHealthInfoModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblDrugInfo_VWall", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    drug.Add(new DrugHealthInfoModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Medication = sdr["Medication"].ToString(),
                        Usageinstructions = sdr["Usageinstructions"].ToString(),
                        Sideeffects = sdr["Sideeffects"].ToString(),
                        Interactions = sdr["Interactions"].ToString(),

                    });


                }


                conn.Close();

            }
            return View(drug);
        }



        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<DrugHealthInfoModel> drug = new List<DrugHealthInfoModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblDrugInfo_Search", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    drug.Add(new DrugHealthInfoModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Medication = sdr["Medication"].ToString(),
                        Usageinstructions = sdr["Usageinstructions"].ToString(),
                        Sideeffects = sdr["Sideeffects"].ToString(),
                        Interactions = sdr["Interactions"].ToString(),

                    });


                }


                conn.Close();

            }
            return View(drug);
        }




































































    }
}
