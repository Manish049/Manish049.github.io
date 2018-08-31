using FunFirstAPI_Pro.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FunFirstAPI_Pro.Controllers.API_Controlers
{
    public class FDataController : ApiController
    {

        private FFGSPL_dbEntities db = new FFGSPL_dbEntities();

        [HttpPost]
        public HttpResponseMessage Fran_Data(Frn_id jsonResult)
        {
            try
            {
                //---------------   API Hits    -------------------------------------

                db.RequestHit("FDataAPI", 1);

                //---------------   Deserialization of JsonResult   -----------------

                string id = JsonConvert.SerializeObject(jsonResult.Fid);
                var u = JsonConvert.DeserializeObject(id);
                int fid = Convert.ToInt32(u);

                if (fid >= 0)
                {
                    Franchise_Data[] Data;
                    using (FFGSPL_dbEntities edb = new FFGSPL_dbEntities())
                    {

                        var data = db.Fran_Data(fid).Select(y => new Franchise_Data
                        {
                            Fran_id = y.Franchise_Id,
                            Franchise_name = y.Franchise_Name,
                            Visited_date = Convert.ToDateTime(y.Visited_Date),
                            Brand = y.Brand,
                            Product = y.Product,
                            Owner_Manager = y.Owner___Manager,
                            Mobile = y.Mobile_Number,
                            Email = y.Email_ID,
                            Landline = y.Email_ID,
                            Address = y.Address,
                            Pincode = y.Pincode.Value,
                            Area = y.Area,
                            City = y.City,
                            State = y.State,
                            Location_lat = y.Lattitude,
                            Location_lng = y.Longtuide,
                            No_tech_work = y.Number_of_Techinican_Working.Value,
                            Req_jan = y.Januery.Value,
                            Req_feb = y.Frbruary.Value,
                            Req_mar = y.March.Value,
                            Req_apr = y.April.Value,
                            Req_may = y.May.Value,
                            Req_jun = y.June.Value,
                            Req_jul = y.July.Value,
                            Req_aug = y.August.Value,
                            Req_sept = y.September.Value,
                            Req_oct = y.October.Value,
                            Req_nov = y.November.Value,
                            Req_dec = y.December.Value,
                            Sal_Range_Fresher = y.Salary_Range_for_Freshers.Value,
                            Contact_person = y.Contact_Person_Name,
                            Contact_Number = y.Contact_Number
                        });



                        Data = data.ToArray();


                    }
                    return new HttpResponseMessage()
                    {
                        Content = new JsonContent(new
                        {
                            Status = "Success",
                            Fran_Data = Data  //return data
                        })
                    };
                }

                else
                {
                    return new HttpResponseMessage()
                    {
                        Content = new JsonContent(new
                        {
                            Status = "Fail",
                            Error = "Franchise ID Does not exist!!"  //return exception
                        })
                    };

                }
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
    public class Frn_id
    {
        public int Fid { get; set; }
    }

    public class Franchise_Data
    {
        public int Fran_id { get; set; }
        public string Franchise_name { get; set; }
        public DateTime Visited_date { get; set; }
        public string Brand { get; set; }
        public string Product { get; set; }
        public string Owner_Manager { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Location_lat { get; set; }
        public string Location_lng { get; set; }
        public int No_tech_work { get; set; }
        public int Req_jan { get; set; }
        public int Req_feb { get; set; }
        public int Req_mar { get; set; }
        public int Req_apr { get; set; }
        public int Req_may { get; set; }
        public int Req_jun { get; set; }
        public int Req_jul { get; set; }
        public int Req_aug { get; set; }
        public int Req_sept { get; set; }
        public int Req_oct { get; set; }
        public int Req_nov { get; set; }
        public int Req_dec { get; set; }
        public decimal Sal_Range_Fresher { get; set; }
        public string Contact_person { get; set; }
        public string Contact_Number { get; set; }
        public string Officer_id { get; set; }


    }

}

