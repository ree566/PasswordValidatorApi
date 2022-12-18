using System;
namespace PasswordValidatorApi.Models
{
	public interface CustomValidator
	{
		public bool IsImmediatelyFollowedBySameSequence(string item);
	}
}

