using System;
using System.Collections.Generic;
using aspnetcorewebpacktest.Models;

namespace aspnetcorewebpacktest.services
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }
        public List<User> GetAll()
        {
            return new List<User>()
            {
                new User()
                {
                    FirstName = "Ash",
                    LastName = "Ketchum",
                    DateOfBirth = new DateTime(1997, 12, 30),
                    UserName = "ichooseyou"
                },

                new User()
                {
                    FirstName = "Brock",
                    LastName = "Harrison",
                    DateOfBirth = new DateTime(1992, 3,31),
                    UserName = "rockrulez"
                },

                new User()
                {
                    FirstName = "Misty",
                    LastName = "",
                    DateOfBirth = new DateTime(1999, 5,4),
                    UserName = "ihearttogepi"
                }
            };
        }
    }
}
