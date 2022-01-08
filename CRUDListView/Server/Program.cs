using CRUDListView.Context;
using Server.Model;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {

            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://localhost:31034/");
            JsonSerializerOptions options = new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            server.Start();
            while (true)
            {
                HttpListenerContext context = server.GetContext();
                if (context.Request.HttpMethod == "GET")
                {

                    try
                    {
                        if (context.Request.RawUrl == "/api/users/")
                        {
                            var carList = AppData.db.UserPersonal.ToList();
                            string response = JsonSerializer.Serialize(AppData.db.UserPersonal.ToList().ConvertAll(c => new UserPersonalResponse(c)), options);
                            byte[] data = Encoding.UTF8.GetBytes(response);
                            context.Response.ContentType = "application/json;charset=utf-8";
                            using (Stream stream = context.Response.OutputStream)
                            {
                                context.Response.StatusCode = 200;
                                stream.Write(data, 0, data.Length);
                            }
                        }
                        else throw new Exception();
                    }
                    catch
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
            }
        }
    }
}
