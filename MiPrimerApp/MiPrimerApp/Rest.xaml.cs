using MiPrimerApp.Entidades;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiPrimerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rest : ContentPage
    {
        public IList<Employe> Employees { get; private set; }

        public Rest()
        {
            InitializeComponent();
            Employees = new List<Employe>();
        }

        //Send GET Request and find value into response JSON
        private void btnEnviarGet_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread( async ()=> {

                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://jsonplaceholder.typicode.com/todos/1");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");

                var cliente = new HttpClient();
                HttpResponseMessage responseMessage = await cliente.SendAsync(request);

                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContent content = responseMessage.Content;
                    var str = await content.ReadAsStringAsync();
                    JObject json = JObject.Parse(str);

                    lblResponse.Text = (String)json["title"];
                }
                else
                {
                    lblResponse.Text = "Error";
                }
            });
        }

        //Send POST request and show JSON response
        private void btnEnviarPost_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                               
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://dummy.restapiexample.com/api/v1/create");
                request.Method = HttpMethod.Post;
                request.Headers.Add("Accept", "application/json");

                request.Content = new StringContent(
                    JsonConvert.SerializeObject(new { name = "test", salary = "1000000", age = "23" }), Encoding.UTF8, "application/json");
             
                var cliente = new HttpClient();
                
                HttpResponseMessage responseMessage = await cliente.SendAsync(request);

                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContent content = responseMessage.Content;
                    var str = await content.ReadAsStringAsync();
                    JObject json = JObject.Parse(str);

                    lblResponse.Text = json.ToString();
                }else
                {
                    lblResponse.Text = "Error";
                }
            });
        }

        //Send GET request and get object list from JSON response to generate the listview
        private void btnEnviarPostList_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => {

                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://dummy.restapiexample.com/api/v1/employees");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");

                var cliente = new HttpClient();
                HttpResponseMessage responseMessage = await cliente.SendAsync(request);

                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContent content = responseMessage.Content;
                    var str = await content.ReadAsStringAsync();
                    
                    var json = JsonConvert.DeserializeObject<JObject>(str);
                    Employees = json.Value<JArray>("data")
                        .ToObject<List<Employe>>();

                    lblResponse.Text = (String)json["status"];

                    listView.ItemsSource = Employees;
                }
                else
                {
                    lblResponse.Text = "Error";
                }
            });


        }
    }
}