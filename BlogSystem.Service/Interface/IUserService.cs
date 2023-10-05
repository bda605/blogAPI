using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using BlogSystem.Model.ResponseViewModel;

namespace BlogSystem.Service.Interface
{
    public interface IUserService
    {
        ResponseVM<string> Login(string userName, string password);
    }
}
