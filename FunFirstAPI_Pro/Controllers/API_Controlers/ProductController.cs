using FunFirstAPI_Pro.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FunFirstAPI_Pro.Controllers.API_Controlers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        FFGSPL_dbEntities db = new FFGSPL_dbEntities();

        [HttpPost]

        [Route("ProductAll")]
        public HttpResponseMessage ProductAll()
        {

            try
            {
                List<Product> Prod;
                using (FFGSPL_dbEntities edb = new FFGSPL_dbEntities())
                {
                    //API Hit Count
                    edb.RequestHit("ProductAPI", 1);

                    var data = from B in edb.Product_tbl
                               select new Product()
                               {
                                   Productid = B.pr_id,
                                   Product_name = B.pr_name
                               };

                    Prod = data.ToList();
                }

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Status = "Success",
                        Products = Prod  //return exception
                    })
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Status = "Fail",
                        Error = ex.Message  //return exception
                    })
                };
            }
        }

        [HttpPost]
        [Route("Productid")]
        public HttpResponseMessage Productid(GetPid getPid)
        {

            try
            {
                //-------------------   API Hit Count  ----------------------------------

                db.RequestHit("BrandAPI", 1);

                List<Product> Prod;
                using (FFGSPL_dbEntities edb = new FFGSPL_dbEntities())
                {
                    //---------------   Deserialization of JsonResult   -----------------

                    string id = JsonConvert.SerializeObject(getPid.Pid);
                    var u = JsonConvert.DeserializeObject(id);
                    int Pid = Convert.ToInt32(u);

                    var data = from B in edb.Product_tbl.Where(x => x.pr_id == Pid)
                               select new Product()
                               {
                                   Productid = B.pr_id,
                                   Product_name = B.pr_name
                               };

                    Prod = data.ToList();
                }

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Status = "Success",
                        Product = Prod  //return exception
                    })
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Status = "Fail",
                        Error = ex.Message  //return exception
                    })
                };
            }
        }

    }

    public class GetPid
    {
        public int Pid { get; set; }
    }

        public class Product
    {
        public int Productid { get; set; }
        public string Product_name { get; set; }

    }
}
