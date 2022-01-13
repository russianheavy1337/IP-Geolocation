using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace IPinfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string logo = @"  _____ _____     _____            _                 _   _             
 |_   _|  __ \   / ____|          | |               | | (_)            
   | | | |__) | | |  __  ___  ___ | | ___   ___ __ _| |_ _  ___  _ __  
   | | |  ___/  | | |_ |/ _ \/ _ \| |/ _ \ / __/ _` | __| |/ _ \| '_ \ 
  _| |_| |      | |__| |  __/ (_) | | (_) | (_| (_| | |_| | (_) | | | |
 |_____|_|       \_____|\___|\___/|_|\___/ \___\__,_|\__|_|\___/|_| |_|
                                                                       
                                                                       ";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(logo);
            Console.Title = "IP Geolocation | By github.com/russianheavy1337";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("IP: ");
            var ip = Console.ReadLine();

             var url = $"http://ip-api.com/json/{ip}?fields=status,message,continent,continentCode,country,countryCode,region,regionName,city,district,zip,lat,lon,timezone,offset,currency,isp,org,as,asname,mobile,proxy,hosting,query";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(data);
            Console.ForegroundColor = ConsoleColor.Blue;

            // I have to do this manually because it has to format correctly lol.

            #region print
            Console.WriteLine();
            Console.WriteLine("Status: " + json.status);
            Console.WriteLine("Country: " + json.country);
            Console.WriteLine("Country Code: " + json.countryCode);
            Console.WriteLine("Continent: " + json.continent);
            Console.WriteLine("ContinentCode: " + json.continentCode);
            Console.WriteLine("District: " + json.district);
            Console.WriteLine("Offset: " + json.offset);
            Console.WriteLine("Region: " + json.region);
            Console.WriteLine("RegionName: " + json.regionName);
            Console.WriteLine("City: " + json.city);
            Console.WriteLine("ZipCode: " + json.zip);
            Console.WriteLine("Latitude: " + json.lat);
            Console.WriteLine("Longitude: " + json.lon);
            Console.WriteLine("Timezone: " + json.timezone);
            Console.WriteLine("ISP: " + json.isp);
            Console.WriteLine("Organisation: " + json.org);
            Console.WriteLine("Asname: " + json.asname);
            Console.WriteLine("Currency: " + json.currency);
            Console.WriteLine("Cellular Connection: " + json.mobile);
            Console.WriteLine("Proxy: " + json.proxy);
            Console.WriteLine("Hosting: " + json.hosting);
            #endregion
            Console.ReadKey();
        }
    }
}
