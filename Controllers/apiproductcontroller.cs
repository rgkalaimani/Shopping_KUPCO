using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Viewmodel = ShoppingApplication.Models.Viewmodel;
using ShoppingApplication.Models.Viewmodel;
using DBLayer;

namespace ShoppingAPI.Controllers
{
    public class apiproductcontroller : ApiController
    {
        DataSet ds;
        List<Product> productList;
        // GET: api/apiproductcontroller
        public string Get()
        {
            productList = new List<Product>();
            
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
            lst.Add(new KeyValuePair<string, string>("@Type", "all"));
            ds = db.ExecuteProcedure("SP_Product", lst);
            if (ds != null)
            {
                productList = DataTableConverter.ProductList(ds.Tables[0]);
            }
            var jsonString = JsonConvert.SerializeObject(productList);
            return jsonString;
        }

        // GET: api/apiproductcontroller/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/apiproductcontroller
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/apiproductcontroller/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/apiproductcontroller/5
        public void Delete(int id)
        {
        }
    }
}
