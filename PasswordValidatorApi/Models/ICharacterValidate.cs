using System;
namespace PasswordValidatorApi.Models
{
    public interface ICharacterValidate
    {
        bool RequireLowerCase(bool symbol);

        bool RequireUppercase(bool symbol);

        bool RequireDigits(bool symbol);

        bool ContinuousSameSequence(bool symbol);
    }
}
