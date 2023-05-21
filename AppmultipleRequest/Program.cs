using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//using System.Text.Json;

namespace AppmultipleRequest
{
    public class Program
    {
     
        
        public async Task RequestAsync(User program)
        {
            var endpoint = "http://localhost:5183/api/User";
            var client = new HttpClient();

           // string jsonPayload =JsonSerializer.Create.Serialize(program);
            string jsonPayload = JsonConvert.SerializeObject(program);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode(); // Throw an exception if an error occurs

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);


        }

        public async Task RequestGetAsync(string Username)
        {
            var endpoint = "http://localhost:5183/api/User";
            var url = string.Format("{0}?username={1}", endpoint, Username);

            var client = new HttpClient();
            var response = await client.GetAsync(url);  // Use the 'url' variable here
            response.EnsureSuccessStatusCode();
            var responsebody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responsebody);
           

        }


        public static  async Task Main(string[] args)
          {

            string name;int Cpassword;
           
            Console.WriteLine("enter username ");
            name = Console.ReadLine();
           // Console.WriteLine("enter password");
           // Cpassword = Convert.ToInt32(Console.ReadLine());

            User user = new User();
            user.username = name;
           // user.password = Cpassword;

            Program test = new Program();
            //  Task t = Task.Run(() => test.RequestAsync(user));
            Task t = Task.Run(()=>test.RequestGetAsync(name));

            //Task t1 = Task.Run(() => test.RequestAsync(name, password));
            //Task t2 = Task.Run(()=>test.RequestAsync(name,password));
            //Task t3 = Task.Run(() => test.RequestAsync(name, password));
            //Task t4 = Task.Run(()=>test.RequestAsync(name, password));
            await Task.WhenAll(t);
            Console.ReadLine();
        }
    }

    public class User
    {
        public string username { get;set; }
        public int password { get;set; }
    }
}
