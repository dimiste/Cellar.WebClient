using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills.Auth
{
    public class MyUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
