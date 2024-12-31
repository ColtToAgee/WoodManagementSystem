using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Application.Bases;

namespace WoodManagementSystem.Application.Features.Patterns.Exceptions
{
    public class PatternNameMustNotBeSameException:BaseException
    {
        public PatternNameMustNotBeSameException():base("Kalıp Başlığı Bulunmaktadır!")
        {
            
        }
    }
}
