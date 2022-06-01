using friendzone.Models;
using friendzone.Services;
using Microsoft.AspNetCore.Mvc;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;

namespace friendzone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowsController : ControllerBase
    {
        private readonly FollowsService _fs;

        public FollowsController(FollowsService fs)
        {
            _fs = fs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Follow>> Create([FromBody] Follow follow)
        {
            try
            {
                Profile profile = await HttpContext.GetUserInfoAsync<Profile>();
                follow.FollowerId = profile.Id;
                Follow newFollow = _fs.Create(follow);
                return Ok(newFollow);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Follow>>Delete(int id)
        {
           try
           {
               Profile profile = await HttpContext.GetUserInfoAsync<Profile>();
               _fs.Delete(id, profile.Id);
               return Ok();
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }
    }
}