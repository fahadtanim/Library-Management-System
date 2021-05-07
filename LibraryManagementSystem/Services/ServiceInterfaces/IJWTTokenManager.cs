using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.ServiceInterfaces
{
    public interface IJWTTokenManager
    {
        string GenerateToken(string username);
    }
}
