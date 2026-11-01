using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
namespace studant_manegment_system
{
    public partial class UsersForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void  Button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            string json = await client.GetStringAsync("https://student-management-syste-bc369-default-rtdb.asia-southeast1.firebasedatabase.app/Users.json");
            var data = JsonConvert.DeserializeObject<Dictionary<string, Models.User>>(json);
            string email = Email.Value;
            string pass = Password2.Value;
            foreach (var item in data.Values)
            {
                if (item.Email == email && item.Password == pass)
                {
                    if (item.Role == "student")
                    {
                        Response.Redirect("StudentForm.aspx");
                    }
                    else
                    {
                        Response.Redirect("TeacherForm.aspx");
                    }
                }
              

            }
            Console.WriteLine("the user not found.");
        }

        protected async void Button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            string url = "https://student-management-syste-bc369-default-rtdb.asia-southeast1.firebasedatabase.app/Users.json";

            string json = await client.GetStringAsync(url);

            var data = JsonConvert.DeserializeObject<Dictionary<string, Models.User>>(json);
            string email = Email.Value;
            foreach (var item in data)
            {
                if (item.Value.Email == email)
                {
                    await client.DeleteAsync("https://student-management-syste-bc369-default-rtdb.asia-southeast1.firebasedatabase.app/Users/" + item.Key + ".json");

                    Label3.Text = "User deleted!";
                    return;
                }
            }
            Label3.Text = "User not found!";
        }

        protected async void Button3_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            string url = "https://student-management-syste-bc369-default-rtdb.asia-southeast1.firebasedatabase.app/Users.json";

            string json = await client.GetStringAsync(url);

            var data = JsonConvert.DeserializeObject<Dictionary<string, Models.User>>(json);

            string email = Text2.Value.Trim();

            foreach (var item in data)
            {
                //if (item.Value.Email == email)
                //{
                    item.Value.Name = EditName.Value;
                    item.Value.Age = Convert.ToInt32(EditAge.Value);

                    string newJson = JsonConvert.SerializeObject(item.Value);

                    string editUrl = "https://student-management-syste-bc369-default-rtdb.asia-southeast1.firebasedatabase.app/Users/" + item.Key + ".json";

                    StringContent content = new StringContent(
                        newJson,
                        System.Text.Encoding.UTF8,
                        "application/json"
                    );

                    await client.PutAsync(editUrl, content);

            
                //}
            }

        }
    }
}