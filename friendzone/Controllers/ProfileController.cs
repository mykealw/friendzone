using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using friendzone.Services;
using Microsoft.AspNetCore.Mvc;

namespace friendzone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProfileController
    {
        private readonly ProfileService _ps;

        public ProfileController(ProfileService ps)
        {
            _ps = ps;
        }
    }
}