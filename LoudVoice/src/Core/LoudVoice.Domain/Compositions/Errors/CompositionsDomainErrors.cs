using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Compositions.Errors
{
    public static class CompositionsDomainErrors
    {
        public static readonly Error EmptyName = Error.NotFound(
            code: "DomainErrors.EmptyName",
            description: "Name of composition is required and can't be empty");

        public static readonly Error EmptyUrl = Error.NotFound(
            code: "DomainErrors.EmptyUrl",
            description: "Url is required and can't be empty");
    }
}
