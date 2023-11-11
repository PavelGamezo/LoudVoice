using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Users.Errors
{
    public class EmptyPasswordError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => "Password is required and can't be empty";

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
