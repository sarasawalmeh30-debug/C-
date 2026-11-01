using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json.Linq;
namespace first
{
    public partial class page2 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "https://project1-92b56-default-rtdb.firebaseio.com/.json";
            string json =await client.GetStringAsync(url);
            //await
            JObject data = JObject.Parse(json);

            JObject students = (JObject)data["stu"];

            int number = 1;

            foreach (var item in students)
            {
                string name = item.Value["name"].ToString();
                string age = item.Value["age"].ToString();

                studentsBody.InnerHtml +=
                    "<tr><td>" + number + "</td><td>" +
                    Server.HtmlEncode(name) + "</td><td>" +
                    Server.HtmlEncode(age) + "</td></tr>";

                number++;
            }
        }

    }
}


















