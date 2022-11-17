using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiGateway.Models.Template;

namespace ApiGateway.Entities
{
    public class UserPermissionsBody
    {
        public string Username { get; set; }
        public List<Guid> Permissions { get; set; }
    }
}