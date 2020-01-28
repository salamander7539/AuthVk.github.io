using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using xNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


namespace VkNet
{
    public partial class vkAuth : System.Web.UI.Page
    {
        string token, id;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void auth_Button_Click(object sender, EventArgs e)
        {  
            Authoriz();
        }

        void Authoriz()
        {
            try
            {
                var ent_data = new HttpRequest();
                string response = ent_data.Get("https://oauth.vk.com/token?grant_type=password&client_id=2274003&client_secret=hHbZxrka2uZ6jB1inYsH&username=" + log_textBox.Text + "&password=" + pass_textBox.Text).ToString();
                dynamic json = JObject.Parse(response);
                token = json.access_token;
                id = json.user_id;
                if (id.Count() > 1)
                {
                    Status_Label.Text = Status_Label.Text + " OK!";
                    GetName();
                    GetFriends();
                }
            }
            catch
            {
                Status_Label.Text = Status_Label.Text + " Wrong login or password!";
            }
        }

        void OpenMyData()
        {
            if (File.Exists(@"D:\C#Apps\LoadVKData.txt"))
            {
                string[] aut_data = File.ReadAllLines(@"D:\C#Apps\LoadVKData.txt");
                log_textBox.Text = aut_data[0];
                pass_textBox.Text = aut_data[1];
            }
        }

        void SaveMyData()
        {
            if (!File.Exists(@"D:\C#Apps\LoadVKData.txt"))
            {
                string[] VkData = new string[]
                {
                    log_textBox.Text,
                    pass_textBox.Text
                };
                File.Create(@"D:\C#Apps\LoadVKData.txt").Close();
                File.WriteAllLines(@"D:\C#Apps\LoadVKData.txt", VkData);
            }
            else
            {
                File.Delete(@"D:\C#Apps\LoadVKData.txt");
                string[] VkData = new string[]
                {
                    log_textBox.Text,
                    pass_textBox.Text
                };
                File.Create(@"D:\C#Apps\LoadVKData.txt").Close();
                File.WriteAllLines(@"D:\C#Apps\LoadVKData.txt", VkData);
            }
        }

        public void GetName()
        {
            var qwer = new HttpRequest();
            string response = qwer.Get("https://api.vk.com/method/account.getProfileInfo?v=5.52&access_token=" + token).ToString();
            dynamic json = JObject.Parse(response);
            string f_name = json.response.first_name;
            string l_name = json.response.last_name;
            Status_Label.Text = Environment.NewLine + f_name + " " + l_name;
        }

        public void GetFriends()
        {
            ListBox1.Items.Clear();
            var qwer = new HttpRequest();
            string response = qwer.Get("https://api.vk.com/method/friends.search?v=5.52&count=5&access_token=" + token).ToString();
            dynamic json = JObject.Parse(response);

            int count = json.response.count;
            string[] fname = new string[count];
            string[] lname = new string[count];
            for (int i = 0; i < 5; i++)
            {
                fname[i] = json["response"]["items"][i]["first_name"];
                lname[i] = json["response"]["items"][i]["last_name"];
                ListBox1.Items.Add(fname[i] + " " + lname[i] + Environment.NewLine);
            }
        }
    }
}