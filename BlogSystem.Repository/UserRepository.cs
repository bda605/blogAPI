using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Model;
using BlogSystem.Model.Entitie;
using BlogSystem.Repository.Interface;
using Microsoft.Identity.Client;

namespace BlogSystem.Repository
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(BlogContext context) : base(context)
        {

        }
    }
}
