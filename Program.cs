﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConexionSIRE
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string idclient = "", client_secret = "", username = "", password = "";
            idclient = "ID_CLIENTE_SUNAT";
            client_secret = "SECRET_CLIENT";
            username = "RUCUSUARIO";
            password = "CLAVE_USUARIO";
            System.Net.WebRequest req = System.Net.WebRequest.Create("https://api-seguridad.sunat.gob.pe/v1/clientessol/" + idclient + "/oauth2/token/");
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            string postData = "grant_type=password&scope=https://api-cpe.sunat.gob.pe&client_id=" + idclient + "&client_secret=" + client_secret + "&username=" + username + "&password=" + password;
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(postData);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null)
            {
                Console.WriteLine("Problemas al iniciar sesion SUNAT");
                Console.ReadLine();
            }
            else
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string Result = sr.ReadToEnd().Trim();
                if (Result.Trim() == "")
                {

                    Console.WriteLine("Problemas al iniciar sesion SUNAT");
                    Console.ReadLine();
                }
                Newtonsoft.Json.Linq.JObject ResponseData = Newtonsoft.Json.Linq.JObject.Parse(Result);
                Console.WriteLine(ResponseData);
                Console.ReadLine();


            }
        }
    }
}
