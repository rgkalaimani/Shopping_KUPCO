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
using Newtonsoft.Json;

namespace ShoppingAPI.Controllers
{
    public class apiordercontroller : ApiController
    {
        DataSet ds;

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // api/apiorder/1
        // GET api/<controller>/5
        [HttpGet]
        public string Get(long id)
        {
            Viewmodel.OrderInfo orderinfo = new Viewmodel.OrderInfo();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@orderid", id.ToString()));

            ds = db.ExecuteProcedure("SP_OrderDetail", lst);
            if (ds != null)
            {
                orderinfo = DataTableConverter.OrderItemInfo(ds);
            }

            var jsonString = JsonConvert.SerializeObject(orderinfo);


            return jsonString;
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}