using AVTOTTEST_LAST.Models;
using AVTOTTEST_LAST.Repository;
using System.ComponentModel.DataAnnotations;

namespace AVTOTTEST_LAST.Validations
{
    public class PhoneAttribute : ValidationAttribute
    {
        public UserRepositorySQL userSQL;

        public PhoneAttribute()
        {
            userSQL = new UserRepositorySQL();
        }
        public override bool IsValid(object? value)
        {
            ErrorMessage = "dhbfhididfh";
            User user = value as User;

            return userSQL.CheckUser(user);
        }

    }
}
