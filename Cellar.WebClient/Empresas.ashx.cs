using Cellar.Data;
using Microsoft.AspNet.Identity;
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
            var idUser = context.User.Identity.GetUserId();

            var contextEmpresas = new BillsSystemContext();
            var result = contextEmpresas.Companies.Where(c => c.Name.Contains(query) && c.IdUser == idUser).Select(c => c.Name);

            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(result));

        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}