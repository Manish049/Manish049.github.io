using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FunFirstAPI_Pro.Models;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FunFirstAPI_Pro.Controllers.API_Controlers
{
    public class LoginController : ApiController
    {
        private FFGSPL_dbEntities db = new FFGSPL_dbEntities();

        [HttpPost]
        public HttpResponseMessage UserDetails(User_t jsonResult)
        {
            try
            {
                //---------------   API Hits    -------------------------------------

                db.RequestHit("LoginAPI", 1);

                //---------------   Deserialization of JsonResult   -----------------

                string email = JsonConvert.SerializeObject(jsonResult.User);
                string pass = JsonConvert.SerializeObject(jsonResult.Pass);
                var u = JsonConvert.DeserializeObject(email);
                var p = JsonConvert.DeserializeObject(pass);
                string username = u.ToString();
                string password = p.ToString();


                if (IsValidUser(username, password))
                {
                    using (FFGSPL_dbEntities edb = new FFGSPL_dbEntities())
                    {
                        User_d[] udata;

                        string user = u.ToString();

                        var data = db.User_Data(user).Select(x => new User_d
                        {
                            Userid = x.User_id,
                            Firstname = x.User_Firstname,
                            Lastname = x.User_Lastname,
                            Mobile = x.User_Mobile,
                            Email = x.User_Email,
                            Entity = x.Entity,
                            Designation = x.User_Designation
                        });
                        udata = data.ToArray();

                        //------------- Convert Data to Json ------------------

                        return new HttpResponseMessage()
                        {
                            Content = new JsonContent(new
                            {
                                Status = "Success",
                                User_Data = udata  //return data
                            })
                        };
                    }
                }
                else
                {
                    return new HttpResponseMessage()
                    {
                        Content = new JsonContent(new
                        {
                            Status = "Fail",
                            Error = "Username or Password is Incorret!!"  //return exception
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

        private bool IsValidUser(string user, string pass)
        {
            bool good = false;

            var check = db.User_tbl.Any(c => c.ur_email == user && c.ur_password == pass);
            good = check;

            return good;
        }
    }

    public class User_t
    {
        public string User { get; set; }
        public string Pass { get; set; }
    }

    public class User_d
    {
        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Entity { get; set; }
        public string Designation { get; set; }

        public static implicit operator string(User_d v)
        {
            throw new NotImplementedException();
        }
    }

    public class JsonContent : HttpContent
    {

        private readonly MemoryStream _Stream = new MemoryStream();
        public JsonContent(object value)
        {

            Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var jw = new JsonTextWriter(new StreamWriter(_Stream));
            jw.Formatting = Formatting.Indented;
            var serializer = new JsonSerializer();
            serializer.Serialize(jw, value);
            jw.Flush();
            _Stream.Position = 0;

        }
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            return _Stream.CopyToAsync(stream);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = _Stream.Length;
            return true;
        }
    }
}
