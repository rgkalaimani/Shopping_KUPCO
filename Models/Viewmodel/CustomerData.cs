using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShoppingApplication.Models.Viewmodel
{
    public class CustomerData
    {
        public Customer ConvertToCustomer(DataTable dtInput)
        {
            Customer cus = new Customer();
            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    cus.Id = Convert.ToInt64(dtInput.Rows[0]["Id"].ToString());
                    cus.FullName = Convert.ToString(dtInput.Rows[0]["FullName"]);
                    cus.Mobile = Convert.ToString(dtInput.Rows[0]["Mobile"]);
                    cus.City = Convert.ToString(dtInput.Rows[0]["City"]);
                    cus.Address1 = Convert.ToString(dtInput.Rows[0]["Address1"]);
                    cus.Address2 = Convert.ToString(dtInput.Rows[0]["Address2"]);
                    cus.Address3 = Convert.ToString(dtInput.Rows[0]["Address3"]);
                }
            }
            catch (Exception ex) { }
            return cus;
        }

    }
}