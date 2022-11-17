using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiGateway.Models.Template;

namespace ApiGateway.Entities
{
    public class LoginResponse
    {
        public Usuario user { get; set; }
        public Token token { get; set; }
    }
}