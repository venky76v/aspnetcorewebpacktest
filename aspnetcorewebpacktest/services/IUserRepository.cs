using aspnetcorewebpacktest.Models;
using System.Collections.Generic;

namespace aspnetcorewebpacktest.services
{
    public interface IUserRepository
    {
        List<User> GetAll();
    }
}
