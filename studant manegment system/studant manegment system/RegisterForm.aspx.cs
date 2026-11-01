using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;

namespace studant_manegment_system
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            var data = new
            {
                Name = Text1.Value,
                Age = Convert.ToInt32(Text2.Value),
                Email = Text3.Value,
                Password = Password1.Value,
                Role = DropDownList1.SelectedValue

            };
            HttpClient client = new HttpClient();

            string json = JsonConvert.SerializeObject(data) ;
            StringContent contant=new StringContent(json,Encoding.UTF8,"application/json");
            await client.PostAsync("https://student-management-syste-bc369-default-rtdb.asia-southeast1.firebasedatabase.app/Users.json", contant)  ; 
        }
    }
}