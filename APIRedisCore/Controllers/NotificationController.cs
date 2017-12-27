using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APIRedisCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRedisCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Notification")]
    public class NotificationController : Controller
    {
        //[HttpPost]
        //[Route("create")]
        //public IActionResult Create([FromBody]NotificationModel model)
        //{


        //    var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

        //    request.KeepAlive = true;
        //    request.Method = "POST";
        //    request.ContentType = "application/json; charset=utf-8";

        //    request.Headers.Add("authorization", "NDgzYTRlYzctN2QwMy00ZjEzLThjMDktYmMwMjE3OGViOWVj");

        //    var serializer = new JavaScriptSerializer();
        //    var obj = new
        //    {
        //        app_id = "94a98d86-1328-4800-aeb2-ec42ee61ccbc",
        //        headings = new { pt = model.Titulo },
        //        contents = new { pt = model.Mensagem },
        //        included_segments = new string[] { "All" }
        //    };
        //    var param = serializer.Serialize(obj);
        //    byte[] byteArray = Encoding.UTF8.GetBytes(param);

        //    string responseContent = null;

        //    try
        //    {
        //        using (var writer = request.GetRequestStream())
        //        {
        //            writer.Write(byteArray, 0, byteArray.Length);
        //        }

        //        using (var response = request.GetResponse() as HttpWebResponse)
        //        {
        //            using (var reader = new StreamReader(response.GetResponseStream()))
        //            {
        //                responseContent = reader.ReadToEnd();
        //            }
        //        }

        //        return Ok(responseContent);
        //    }
        //    catch (WebException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}