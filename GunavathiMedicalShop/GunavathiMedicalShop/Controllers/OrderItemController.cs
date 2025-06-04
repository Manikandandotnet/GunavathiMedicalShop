using GunavathiMedicalShop.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace GunavathiMedicalShop.Controllers
{
    public class OrderItemController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: OrderItem
        public ActionResult Index()
        {
            List<OrderItemModel> order = new List<OrderItemModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblOrderItems", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order.Add(new OrderItemModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        ProductID = sdr["ProductID"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        Price = Convert.ToSingle(sdr["Price"]),

                    });
                }


                conn.Close();

            }


            return View(order);
        }

        // GET: OrderItem/Details/5
        public ActionResult Details(int id)
        {
            OrderItemModel order = new OrderItemModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblOrderItems_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order = new OrderItemModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        ProductID = sdr["ProductID"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        Price = Convert.ToSingle(sdr["Price"]),

                    };
                }


                conn.Close();

            }


            return View(order);
        }

        // GET: OrderItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderItem/Create
        [HttpPost]
        public ActionResult Create(OrderItemModel order)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblOrderItems_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OrderID", order.OrderID);
                    cmd.Parameters.AddWithValue("@ProductID", order.ProductID);
                    cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
                    cmd.Parameters.AddWithValue("@Price", order.Price);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Message"] = "Data inserted successfully!";

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

        // GET: OrderItem/Edit/5
        public ActionResult Edit(int id)
        {
            OrderItemModel order = new OrderItemModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblOrderItems_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order = new OrderItemModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        ProductID = sdr["ProductID"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        Price = Convert.ToSingle(sdr["Price"]),

                    };
                }


                conn.Close();

            }


            return View(order);
        }

        // POST: OrderItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrderItemModel order)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblOrderItems_Edit", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.Parameters.AddWithValue("@OrderID", order.OrderID);
                    cmd.Parameters.AddWithValue("@ProductID", order.ProductID);
                    cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
                    cmd.Parameters.AddWithValue("@Price", order.Price);

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

        // GET: OrderItem/Delete/5
        public ActionResult Delete(int id)
        {
            OrderItemModel order = new OrderItemModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblOrderItems_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order = new OrderItemModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        ProductID = sdr["ProductID"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        Price = Convert.ToSingle(sdr["Price"]),

                    };
                }


                conn.Close();

            }


            return View(order);

        }

        // POST: OrderItem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_tblOrderItems_Delete", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);


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
            List<OrderItemModel> order = new List<OrderItemModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblOrderItems", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order.Add(new OrderItemModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        ProductID = sdr["ProductID"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        Price = Convert.ToSingle(sdr["Price"]),

                    });
                }


                conn.Close();

            }


            return View(order);
        }


        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<OrderItemModel> order = new List<OrderItemModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_tblOrderItems_Search", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order.Add(new OrderItemModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        ProductID = sdr["ProductID"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        Price = Convert.ToSingle(sdr["Price"]),

                    });
                }


                conn.Close();

            }


            return View(order);
        }




        public ActionResult IndexOrder()
        {
            List<OrderModel> order = new List<OrderModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblOrders_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order.Add(new OrderModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        Orderdate = Convert.ToDateTime(sdr["Orderdate"]),
                        Status = sdr["Status"].ToString(),
                        Paymentmethod = sdr["Paymentmethod"].ToString(),
                        Totalamount = Convert.ToSingle(sdr["Totalamount"])

                    });
                }

                conn.Close();
            }
            return View(order);
        }


        public ActionResult DetailsOrder(int id)
        {

            OrderModel order = new OrderModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblOrders_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order = new OrderModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        Orderdate = Convert.ToDateTime(sdr["Orderdate"]),
                        Status = sdr["Status"].ToString(),
                        Paymentmethod = sdr["Paymentmethod"].ToString(),
                        Totalamount = Convert.ToSingle(sdr["Totalamount"])

                    };
                }

                conn.Close();
            }
            return View(order);
        }




        public ActionResult CreateOrder()
        {
            OrderModel order = new OrderModel();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "Choose..", Text = "Choose" });
            list.Add(new SelectListItem() { Value = "Verified", Text = "Verified" });
            list.Add(new SelectListItem() { Value = "Pending", Text = "Pending" });
            list.Add(new SelectListItem() { Value = "Rejected", Text = "Rejected" });
            order.statusList = list;

            return View(order);



        }




        [HttpPost]
        public ActionResult CreateOrder(OrderModel order)
        {

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "Choose..", Text = "Choose" });
            list.Add(new SelectListItem() { Value = "Verified", Text = "Verified" });
            list.Add(new SelectListItem() { Value = "Pending", Text = "Pending" });
            list.Add(new SelectListItem() { Value = "Rejected", Text = "Rejected" });
            order.statusList = list;

            string totalamount;
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblOrders_Add", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OrderID", order.OrderID);
                Session["price"] = order.OrderID;
                 SumPrice();

                totalamount = Session["TotalPrice"].ToString();


                cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);

                cmd.Parameters.AddWithValue("@Orderdate", order.Orderdate);



                cmd.Parameters.AddWithValue("@Status", order.Status);
                cmd.Parameters.AddWithValue("@Paymentmethod", order.Paymentmethod);
                cmd.Parameters.AddWithValue("@Totalamount", totalamount);

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


            return RedirectToAction("IndexOrder");

        }







        public ActionResult SumPrice()
        {
            string OrderID;
            // OrderID is passed as a parameter, no need to reassign it from the session
            OrderID = Session["price"].ToString();
            OrderModel order = new OrderModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPtblOrders_Total", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    // Read the total amount from the stored procedure result
                    decimal totalAmount = Convert.ToDecimal(sdr["Totalamount"]);

                    // Store the total amount in a session variable
                    Session["TotalPrice"] = totalAmount;
                }

                conn.Close();
            }

            return View("Session[\"TotalPrice\"]");
            // Redirect to a different action or return a view as needed
            //return RedirectToAction("OrderDetails", new { id = OrderID });
        }














        //public ActionResult SumPrice (string OrderID)
        //{
        //    OrderID  = Session["price"].ToString();
        //    OrderModel order = new OrderModel();

        //    using (SqlConnection conn = new SqlConnection(strcon))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("SPtblOrders_Total", conn);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@OrderID",OrderID);
        //        SqlDataReader sdr = cmd.ExecuteReader();



        //        if (sdr.Read())
        //        {
        //            order = new OrderModel
        //            {
        //                id = Convert.ToInt32(sdr["id"]),
        //                OrderID = sdr["OrderID"].ToString(),
        //                CustomerID = sdr["CustomerID"].ToString(),
        //                Orderdate = Convert.ToDateTime(sdr["Orderdate"]),
        //                Status = sdr["Status"].ToString(),
        //                Paymentmethod = sdr["Paymentmethod"].ToString(),
        //                Totalamount = Convert.ToSingle(sdr["Totalamount"])

        //            };
        //        }

        //        conn.Close();
        //    }
        //    return View(order);
        //}
































        public ActionResult EditOrder(int id)
        {

            OrderModel order = new OrderModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblOrders_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order = new OrderModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        Orderdate = Convert.ToDateTime(sdr["Orderdate"]),
                        Status = sdr["Status"].ToString(),
                        Paymentmethod = sdr["Paymentmethod"].ToString(),
                        Totalamount = Convert.ToSingle(sdr["Totalamount"])

                    };
                }

                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Value = "Choose..", Text = "Choose" });
                list.Add(new SelectListItem() { Value = "Verified", Text = "Verified" });
                list.Add(new SelectListItem() { Value = "Pending", Text = "Pending" });
                list.Add(new SelectListItem() { Value = "Rejected", Text = "Rejected" });
                order.statusList = list;

                conn.Close();
            }



            return View(order);
        }



        [HttpPost]
        public ActionResult EditOrder(int id, OrderModel order)
        {

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "Choose..", Text = "Choose" });
            list.Add(new SelectListItem() { Value = "Verified", Text = "Verified" });
            list.Add(new SelectListItem() { Value = "Pending", Text = "Pending" });
            list.Add(new SelectListItem() { Value = "Rejected", Text = "Rejected" });
            order.statusList = list;


            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblOrders_Edit", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@OrderID", order.OrderID);

                cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);

                cmd.Parameters.AddWithValue("@Orderdate", order.Orderdate);
                cmd.Parameters.AddWithValue("@Status", order.Status);

                cmd.Parameters.AddWithValue("@Paymentmethod", order.Paymentmethod);
                cmd.Parameters.AddWithValue("@Totalamount", order.Totalamount);

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


      
            return RedirectToAction("IndexOrder");

        }




        public ActionResult DeleteOrder(int id)
        {

            OrderModel order = new OrderModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblOrders_Getone", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order = new OrderModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        Orderdate = Convert.ToDateTime(sdr["Orderdate"]),
                        Status = sdr["Status"].ToString(),
                        Paymentmethod = sdr["Paymentmethod"].ToString(),
                        Totalamount = Convert.ToSingle(sdr["Totalamount"])

                    };
                }

                conn.Close();
            }



            return View(order);
        }

        [HttpPost]

        public ActionResult DeleteOrder(int id,OrderModel order)
        {
            //List<SelectListItem> list = new List<SelectListItem>();
            //list.Add(new SelectListItem() { Value = "Choose..", Text = "Choose" });
            //list.Add(new SelectListItem() { Value = "Verified", Text = "Verified" });
            //list.Add(new SelectListItem() { Value = "Pending", Text = "Pending" });
            //list.Add(new SelectListItem() { Value = "Rejected", Text = "Rejected" });
            //order.statusList = list;


            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblOrders_Delete", conn);
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



            return RedirectToAction("IndexOrder");
        }


        public ActionResult SearchOrder()
        {
            List<OrderModel> order = new List<OrderModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblOrders_VWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order.Add(new OrderModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        Orderdate = Convert.ToDateTime(sdr["Orderdate"]),
                        Status = sdr["Status"].ToString(),
                        Paymentmethod = sdr["Paymentmethod"].ToString(),
                        Totalamount = Convert.ToSingle(sdr["Totalamount"])

                    });
                }

                conn.Close();
            }



            return View(order);
        }





        [HttpPost]
        public ActionResult SearchOrder(string Search)
        {
            List<OrderModel> order = new List<OrderModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_tblOrders_Search", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);


                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    order.Add(new OrderModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        OrderID = sdr["OrderID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        Orderdate = Convert.ToDateTime(sdr["Orderdate"]),
                        Status = sdr["Status"].ToString(),
                        Paymentmethod = sdr["Paymentmethod"].ToString(),
                        Totalamount = Convert.ToSingle(sdr["Totalamount"])

                    });
                }

                conn.Close();
            }



            return View(order);
        }











    }
}
