using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.Common.Errors
{
    public sealed class InvalidLoginOrPasswordError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => "Invalid login or password";

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
