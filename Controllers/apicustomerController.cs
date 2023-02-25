using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Viewmodel = ShoppingApplication.Models.Viewmodel;
using DBLayer;
using System.Data;
using ShoppingApplication.Models.Viewmodel;

namespace ShoppingAPI.Controllers
{
    public class apicustomerController : ApiController
    {

        DataSet ds;
        

        // GET: api/apicustomer
        public IEnumerable<string> Get()
        {
            return null;
        }

        // GET: api/apicustomer/5
        public string Get(string id)
        {
            Customer cs = new Customer();
            CustomerData obj = new CustomerData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@Type", "search"));
            lst.Add(new KeyValuePair<string, string>("@mobile", id.ToString()));

            ds = db.ExecuteProcedure("SP_Customer", lst);
            if (ds != null)
            {
                cs = obj.ConvertToCustomer(ds.Tables[0]);
            }
            var jsonString = JsonConvert.SerializeObject(cs);
            return jsonString;         
        }

        // GET: api/apicustomer/5        
        public string search(string id)
        {

            

            return "value";
        }


        // POST: api/apicustomer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/apicustomer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/apicustomer/5
        public void Delete(int id)
        {
        }
    }
}
