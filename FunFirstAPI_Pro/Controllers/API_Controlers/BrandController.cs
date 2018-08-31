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
    [RoutePrefix("api/Brand")]
    public class BrandController : ApiController
    {
        FFGSPL_dbEntities db = new FFGSPL_dbEntities();

        [HttpPost]
        [Route("BrandAll")]
        public HttpResponseMessage BrandAll()
        {

            try
            {
                //-------------------   API Hit Count  ----------------------------------

                db.RequestHit("BrandAPI", 1);

                List<Brand> Bran;
                using (FFGSPL_dbEntities edb = new FFGSPL_dbEntities())
                {

                    var data = from B in edb.Brand_tbl
                               select new Brand()
                               {
                                   Brandid = B.br_id,
                                   Brand_name = B.br_name
                               };

                    Bran = data.ToList();
                }

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Status = "Success",
                        Brands = Bran  //return exception
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
        [Route("Brandid")]
        public HttpResponseMessage Brandid(GetBid getBid)
        {

            try
            {
                //-------------------   API Hit Count  ----------------------------------

                db.RequestHit("BrandAPI", 1);

                List<Brand> Bran;
                using (FFGSPL_dbEntities edb = new FFGSPL_dbEntities())
                {

                    //---------------   Deserialization of JsonResult   -----------------

                    string id = JsonConvert.SerializeObject(getBid.Bid);
                    var u = JsonConvert.DeserializeObject(id);
                    int Bid = Convert.ToInt32(u);

                    var data = from B in edb.Brand_tbl.Where(x => x.br_id == Bid)
                               select new Brand()
                               {
                                   Brandid = B.br_id,
                                   Brand_name = B.br_name
                               };

                    Bran = data.ToList();
                }

                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Status = "Success",
                        Brands = Bran  //return exception
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

        public class GetBid
        {
            public int Bid { get; set; }
        }

        public class Brand
        {
            public int Brandid { get; set; }
            public string Brand_name { get; set; }

        }
    }
