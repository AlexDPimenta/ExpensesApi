using System;
using System.ComponentModel.DataAnnotations.Schema;
using com.expenses.domain.Validators.Login;

namespace com.expenses.domain.DomainModel.Login
{
    [Table("logins")]
    public class LoginModel: BaseModel
    {                       
        public string Login { get; private set; }

        public string Password { get; private set; }                

    }
}
