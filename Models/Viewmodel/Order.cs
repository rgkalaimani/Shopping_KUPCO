using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShoppingApplication.Models.Viewmodel
{
    public class Order
    {
        public long OrderId { get; set; }

        public string UserName { get; set; }

        public long UserId { get; set; }

        public string LName { get; set; }

        public DateTime EntryDate { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }

        public long Quantity { get; set; }

        public long Price { get; set; }

        public long TPrice { get; set; }

        public string Status { get; set; }
    }

    public class Customer
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Mobile { get; set; }

        public string City { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }        

        public bool IsActive { get; set; }

    }

    public class Product
    {

        public long Id { get; set; }
        public string ProductType { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string img { get; set; }
        public double Price { get; set; }
        public string priceLbl { get; set; }
        public string priceLblAr { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }


    public class OrderInfo
    {
        public List<OrderItem> orderItems { get; set; }

        public Delivery delivery { get; set; }


    }

    public class OrderItem
    {
        public string OrderId { get; set; }

        public string Item { get; set; }

        public string Amount { get; set; }

        public string TotalAmount { get; set; }

    }

    public class Delivery
    {
        public string OrderId { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

    }

    public static class DataTableConverter
    {
        public static List<Order> DashboardList(DataTable dtInput)
        {
            if (dtInput.Rows.Count > 0)
            {
                List<Order> orderList = new List<Order>();
                try
                {
                    foreach (DataRow item in dtInput.Rows)
                    {

                        orderList.Add(new Order
                        {
                            OrderId = Convert.ToInt64(item["OID"]),
                            UserName = item["OID"].ToString(),
                            UserId = Convert.ToInt64(item["UID"]),
                            LName = Convert.ToString(item["Iname"]),
                            EntryDate = Convert.ToDateTime(item["EntryDate"]),

                            Image = Convert.ToString(item["Image"]),
                            IsActive = Convert.ToBoolean(item["IsActive"]),
                            Quantity = Convert.ToInt64(item["Qnt"]),
                            Price = Convert.ToInt64(item["Price"]),
                            TPrice = Convert.ToInt64(item["TPrice"]),
                            Status = Convert.ToString(item["Status"])

                        });


                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return orderList;

            }

            return new List<Order>();

        }

        public static OrderInfo OrderItemInfo(DataSet dsInput)
        {
            List<OrderItem> OrderItemList = new List<OrderItem>();
            Delivery dvInfo = new Delivery();

            if (dsInput.Tables.Count > 0)
            {

                try
                {
                    foreach (DataRow item in dsInput.Tables[0].Rows)
                    {

                        OrderItemList.Add(new OrderItem
                        {
                            OrderId = Convert.ToString(item["OID"]),
                            Item = item["Item"].ToString(),
                            Amount = Convert.ToString(item["Amount"]),
                            TotalAmount = Convert.ToString(item["TotalAmount"])

                        });


                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                try
                {
                    dvInfo.OrderId = Convert.ToString(dsInput.Tables[1].Rows[0]["OID"]);
                    dvInfo.Address = Convert.ToString(dsInput.Tables[1].Rows[0]["Address"]);
                    dvInfo.ContactNumber = Convert.ToString(dsInput.Tables[1].Rows[0]["ContactNumber"]);
                    dvInfo.Email = Convert.ToString(dsInput.Tables[1].Rows[0]["Email"]);

                }
                catch (Exception ex)
                {
                    throw ex;
                }



            }

            OrderInfo info = new OrderInfo();
            info.delivery = dvInfo;
            info.orderItems = OrderItemList;
            return info;

        }

        public static List<Product> ProductList(DataTable dtInput)
        {
            List<Product> productList = new List<Product>();

            if (dtInput.Rows.Count > 0)
            {

                try
                {
                    foreach (DataRow item in dtInput.Rows)
                    {

                        productList.Add(new Product
                        {
                            Id = Convert.ToInt64(item["Id"]),
                            ProductType = item["ProductType"].ToString(),
                            Name = Convert.ToString(item["Name"]),
                            NameAr = Convert.ToString(item["NameAr"]),
                            img = Convert.ToString(item["img"]),
                            Price = Convert.ToDouble(item["Price"]),
                            priceLbl = Convert.ToString(item["priceLbl"]),
                            priceLblAr = Convert.ToString(item["priceLblAr"])

                        });


                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return productList;

            }

            return productList;
        }
    }
}