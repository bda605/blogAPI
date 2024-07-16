using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Execution;
using Azure;
using BlogSystem.Common;
using BlogSystem.Model.Entitie;
using BlogSystem.Model.ResponseViewModel;
using BlogSystem.Repository.Interface;
using BlogSystem.Service.Interface;
namespace BlogSystem.Service
{
    public class UserService:IUserService
    {
        public readonly IUserRepository _userRepository;
        private string pwSalt = "AlrySqloPe2Mh784QQwG6jRAfkdPpDa90J0i";
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ResponseVM<string> Login(string userName, string password)
        {
            if (userName.ToUpper() == "ADMIN")
            {
                var adminUser = _userRepository.Get(x => x.UserName == userName)
                    .FirstOrDefault();
                if (adminUser == null)
                {
                    _userRepository.Insert(new User()
                    {
                        UserName = "ADMIN",
                        Email = "admin@gmail.com",
                        Password = PasswordEncryption(password),
                        Role = "ADMIN",
                    });
                    _userRepository.SaveChanges();
                }
            }
       
            var passwordEncryption = PasswordEncryption(password);
            //初始化
            var user = _userRepository.Get(x=>x.UserName == userName && x.Password == passwordEncryption)
                .FirstOrDefault();
            if (user != null )
                return new ResponseVM<string>().Success("登入成功");

            return new ResponseVM<string>().Fail(ResponseCode.NotFound);
        }

        
        private string PasswordEncryption(string password)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] originalPwd = Encoding.UTF8.GetBytes(pwSalt + password);
            byte[] encryPwd = sha1.ComputeHash(originalPwd);
            return string.Join("", encryPwd.Select(b => string.Format("{0:x2}", b)).ToArray()).ToUpper();
        }
    }
}
