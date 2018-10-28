using Cellar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Cellar.WebClient
{
    /// <summary>
    /// Descripción breve de Empresas1
    /// </summary>
    public class Empresas1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string query = context.Request["term"];

            var contextEmpresas = new BillsSystemContext();
            var result = contextEmpresas.Companies.Where(c => c.Name.Contains(query)).Select(c => c.Name);

            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(result));

            //string query = context.Request["term"];

            //IEnumerable<Company> beers = new List<Company>() { new Company() { Id = 2, Name = "Dimitar" }, new Company() { Id = 3, Name = "Josep" }, new Company() { Id = 4, Name = "Teodora" } };
            //string[] respuesta = new string[] { "Dimitar", "Josep", "Teodora", "Yordanka" };

            //var result = beers.Where(b => b.Name.Contains(query)).Select(b => b.Name);
            //var result01 = respuesta.Where(r => r.Contains(query));

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //context.Response.Write(js.Serialize(result01));

        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}