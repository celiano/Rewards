using RewardsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RewardsWebApi.Controllers
{
    public class UserController : ApiController
    {
        private DataAccess.IUserDA _userDA;

        public UserController()
        {
            _userDA = new DataAccess.UserDA();
        }

        public UserController(DataAccess.IUserDA userDA)
        {
            _userDA = userDA;
        }

        [HttpGet]
        public Response<User> Authentication(string userName, string password)
        {
            Response<User> response = new Response<User>();
            try
            {
                response = _userDA.Authentication(userName, password);
                //response.Succeeded = true;                
                return response;
            }
            catch(Exception ex)
            {
                response.Succeeded = false;
                return response;
            }
        }
    }
}
