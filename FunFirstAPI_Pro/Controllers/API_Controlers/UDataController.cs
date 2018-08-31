using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using FunFirstAPI_Pro.Models;
using Newtonsoft.Json;

namespace FunFirstAPI_Pro.Controllers.API_Controlers
{
    public class UDataController : ApiController
    {
     
        private FFGSPL_dbEntities db = new FFGSPL_dbEntities();

        [HttpPost]
        public HttpResponseMessage User_Data(User_id jsonResult)
        {
            try
            {
                //---------------   API Hits    -------------------------------------

                db.RequestHit("UDataAPI", 1);

                //---------------   Deserialization of JsonResult   -----------------

                string id = JsonConvert.SerializeObject(jsonResult.Uid);
                var u = JsonConvert.DeserializeObject(id);
                int uid = Convert.ToInt32(u);

                if (uid >= 0)
                {
                    Franchise_List[] Data;
                    using (FFGSPL_dbEntities edb = new FFGSPL_dbEntities())
                    {

                        var data = db.FranCount_Data(uid).Select(y => new Franchise_List
                        {
                            Fran_id = y.Franchise_ID,
                            Franchise_name = y.Franchise_Name,
                            Visited_date = y.Visited_Date.Value.Date,
                            //Brand = y.Brand,
                            //Product = y.Product,
                            //Owner_Manager = y.Owner_Manager,
                            //Mobile = y.Mobile_Number,
                            //Email = y.EmailID,
                            //Landline = y.Landline,
                            //Address = y.Address,
                            //Pincode = y.Pincode.Value,
                            Area = y.Area,
                            City = y.City,
                            //State = y.State,
                            //Location_lat = y.Lattitute,
                            //Location_lng = y.Longitude,
                            //No_tech_work = y.Number_of_Techinican_Working.Value,
                            //Req_jan = y.Januery.Value,
                            //Req_feb = y.Frbruary.Value,
                            //Req_mar = y.March.Value,
                            //Req_apr = y.April.Value,
                            //Req_may = y.May.Value,
                            //Req_jun = y.June.Value,
                            //Req_jul = y.July.Value,
                            //Req_aug = y.August.Value,
                            //Req_sept = y.September.Value,
                            //Req_oct = y.October.Value,
                            //Req_nov = y.November.Value,
                            //Req_dec = y.December.Value,
                            //Sal_Range_Fresher = y.Salary_Range_for_Freshers.Value,
                            //Contact_person = y.Contact_PersonName,
                            //Contact_Number = y.Contact_Number,
                            CurrentMonthCount = y.CurrentMonthCount.Value,
                            Officer_id = uid.ToString()
                        });



                        Data = data.ToArray();


                    }
                    return new HttpResponseMessage()
                    {
                        Content = new JsonContent(new
                        {
                            Status = "Success",
                            User_Data = Data  //return data
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
                            Error = "Username ID Does not exist!!"  //return exception
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
    public class User_id
    {
        public int Uid { get; set; }
    }

    public class Franchise_List
    {
        public int Fran_id { get; set; }
        public string Franchise_name { get; set; }
        public DateTime Visited_date { get; set; }
        //public string Brand { get; set; }
        //public string Product { get; set; }
        //public string Owner_Manager { get; set; }
        //public string Mobile { get; set; }
        //public string Landline { get; set; }
        //public string Email { get; set; }
        //public string Address { get; set; }
        //public int Pincode { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        //public string State { get; set; }
        //public string Location_lat { get; set; }
        //public string Location_lng { get; set; }
        //public int No_tech_work { get; set; }
        //public int Req_jan { get; set; }
        //public int Req_feb { get; set; }
        //public int Req_mar { get; set; }
        //public int Req_apr { get; set; }
        //public int Req_may { get; set; }
        //public int Req_jun { get; set; }
        //public int Req_jul { get; set; }
        //public int Req_aug { get; set; }
        //public int Req_sept { get; set; }
        //public int Req_oct { get; set; }
        //public int Req_nov { get; set; }
        //public int Req_dec { get; set; }
        //public decimal Sal_Range_Fresher { get; set; }
        //public string Contact_person { get; set; }
        //public string Contact_Number { get; set; }
        public int CurrentMonthCount { get; set; }
        public string Officer_id { get; set; }
       


    }
}
