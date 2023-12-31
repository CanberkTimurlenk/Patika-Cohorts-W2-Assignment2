﻿using ECommerceApi.Models.Entities;

namespace ECommerceApi.LoginDb
{
    public static class Db
    {
        // since requirement is just create a fake login system, a static list to store users

        // User login information could be seen in the list below clearly

        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Username = "admin",
                Password = "123"
            },
            new User()
            {
                Username = "user",
                Password = "123"
            }
        };
    }
}
