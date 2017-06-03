using DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class UserController : ApiController
    {
        public List<User> Get()
        {
            return UserRepo.GetAll();
        }

        public void Post(User user)
        {
            UserRepo.Add(user);
        }

        public void Delete(int id)
        {
            UserRepo.Delete(id);
        }

        public void Put(int id, User user)
        {
            UserRepo.Update(user, id);
        }
    }
}
