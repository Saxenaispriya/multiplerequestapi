using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppmultipleRequest
{
    public class Program
    {
     
        public async Task RequestAsync(string username, int password)
        {

            var endpoint = "http://localhost:5183";
            var url = string.Format("{0}?username={1}&password={2}", endpoint, username, password);
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode(); // Throw an exception if error

            var body = await response.Content.ReadAsStringAsync();
           // dynamic json = JsonConvert.DeserializeObject(body);

        }


          public static  async Task Main(string[] args)
          {
            string name;int password;
            Console.WriteLine("enter username ");
            name = Console.ReadLine();
            Console.WriteLine("enter password");
            password = Convert.ToInt32(Console.ReadLine());
            Program test = new Program();
            Task t = Task.Run(() => test.RequestAsync(name,password));
            Task t1 = Task.Run(() => test.RequestAsync(name, password));
            Task t2 = Task.Run(()=>test.RequestAsync(name,password));
            Task t3 = Task.Run(() => test.RequestAsync(name, password));
            Task t4 = Task.Run(()=>test.RequestAsync(name, password));
            await Task.WhenAll(t,t1,t2,t3,t4);
        }
    }
}
