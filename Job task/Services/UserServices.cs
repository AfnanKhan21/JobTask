using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using Job_task.Models;

namespace Job_task.Services
{
    public class UserServices
    {
        private Job_task_DatabaseEntities db = new Job_task_DatabaseEntities();


        public User FindUserById(int id)
        {

            User User = db.Users.Find(id);

            return (User);

        }

        public void CreateUser(User User)
        {

            db.Users.Add(User);
            db.SaveChanges();
        }

        public void UpdateUser(User User)
        {
            db.Entry(User).State = EntityState.Modified;
            db.SaveChanges();
        }


        public List<User> GetUsers()
        {
            var users = db.Users.Include(u => u.Department);
            return users.ToList();
        }

        public void DeleteUser(int id)
        {
            User User = FindUserById(id);
            db.Users.Remove(User);
            db.SaveChanges();
        }
    }
}