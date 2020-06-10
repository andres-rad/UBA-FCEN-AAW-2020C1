using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Infrastructura.Identity
{
    public class SeedCurrentUserService : ICurrentUserService
    {
        public SeedCurrentUserService()
        {
            UserId = "seedUser";
        }

        public string UserId { get; }
    }
}
