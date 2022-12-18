using System;
namespace PasswordValidatorApi.Models
{
    public interface ILengthValidate
    {
        bool RequireLength(int min, int max);
        bool Min(int num);
    }
}
