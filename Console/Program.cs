using Entity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;

            #region Get
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://bgapitest.azurewebsites.net/api/user");

                var result = JsonConvert.DeserializeObject<List<User>>(response.Result.Content.ReadAsStringAsync().Result);

                foreach (var item in result)
                {
                    System.Console.WriteLine(item.FirstName + " " + item.LastName);
                    System.Console.Beep();
                }
            }
            #endregion

            #region Post
            //using (var client = new HttpClient())
            //{
            //    System.Console.WriteLine("Ad: ");
            //    string ad = System.Console.ReadLine();

            //    System.Console.WriteLine("Soyad: ");
            //    string soyad = System.Console.ReadLine();

            //    var data = new
            //    {
            //        FirstName = ad,
            //        LastName = soyad
            //    };

            //    client.BaseAddress = new Uri("https://bgapitest.azurewebsites.net");
            //    var response = client.PostAsJsonAsync("/api/user", data);
            //    System.Console.WriteLine(response.Result.IsSuccessStatusCode);
            //}
            #endregion

            // Proje ismi Console olduğu için isim çakışmasından dolayı System eklemek zorunda kalıyoruz.
            System.Console.ReadKey();
        }
    }
}
