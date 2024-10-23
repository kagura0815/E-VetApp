using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Firebase.Database.Query;
using static EVet.Includes.GlobalVariables;
namespace EVet.Models
{
    class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }


        public async Task<bool> _Users(string fname,
           string lname, string user, string pass)
        {
            var users = new Users()
            {

                FirstName = fname,
                LastName = lname,
                User = user,
                Pass = pass,

            };
            await client.Child("Users").PostAsync(users);
            return true;
        }
        public async Task<bool> Getuser(string user, string pass)
        {
            try
            {
                var evaluateEmail =
                    (await client.Child("Users").OnceAsync<Users>()).FirstOrDefault(a =>
                    a.Object.User == user && a.Object.Pass == pass);
                if (evaluateEmail != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> GetUsername(string user)
        {
            try
            {
                var evaluateCourseCode =
                    (await client.Child("Users").OnceAsync<Users>()).FirstOrDefault(b =>
                    b.Object.User == user);
                if (evaluateCourseCode != null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> GetUsers(string Users)
        {
            try
            {
                var evaluateUser =
                    (await client.Child("Users").OnceAsync<Users>()).FirstOrDefault(a =>
                    a.Object.User == Users);
                if (evaluateUser != null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
