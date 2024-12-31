using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Application.Bases;

namespace WoodManagementSystem.Application.Features.Users.Exceptions
{
    public class UserIsNotFoundException:BaseException
    {
        public UserIsNotFoundException():base("Kullanıcı Bulunamadı")
        {
            
        }
    }
}
