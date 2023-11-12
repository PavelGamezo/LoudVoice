using FluentResults;

namespace LoudVoice.Application.Common.Errors
{
    public class UserDontExistError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => "User with given email doesn't exist";

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
