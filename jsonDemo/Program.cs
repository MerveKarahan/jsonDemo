using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace jsonDemo
{
    class Program
    {
        

        static void Main(string[] args)
        {

            // url
            string adres = "https://api.genelpara.com/embed/para-birimleri.json";
            
            // web request atma
            WebRequest istek = HttpWebRequest.Create(adres);
            WebResponse cevap = istek.GetResponse();
            StreamReader donenBilgiler = new StreamReader(cevap.GetResponseStream());
            
            // gelen veriyi json olarak parse etme
            string bilgilerial = donenBilgiler.ReadToEnd().Trim();
            JObject bilgiler = JObject.Parse(bilgilerial);

            // istenen verileri ayıklama
            float dolaralis = (float)bilgiler["USD"]["alis"];
            float dolarsatis = (float)bilgiler["USD"]["satis"];

            
            Console.WriteLine("güncel dolar alış kuru: " + dolaralis);
            Console.WriteLine("elinizdeki tl miktarını giriniz: ");
            float elindekitl = float.Parse(Console.ReadLine()); // cast etmek, parse etmek, çevirmek, convert etmek ===>> hepsi yakın terimler
            Console.WriteLine(elindekitl/dolaralis);




        }



    }

     
}

























