using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Abstractions
{
    public interface IAuthService
    {
        Task<bool> Login(string email, string password);
    }
}
