using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Performers.Errors
{
    public static class CompositionsDomainErrors
    {
        public static readonly Error EmptyName = Error.NotFound(
            code: "CompositionDomainErrors.EmptyName",
            description: "Name of composition is required and can't be empty");

        public static readonly Error EmptyUrl = Error.NotFound(
            code: "CompositionDomainErrors.EmptyUrl",
            description: "Url is required and can't be empty");

        public static readonly Error NotFoundComposition = Error.NotFound(
            code: "CompositionDomainErrors.EmptyUrl",
            description: "Composition with the same url has alredy exist");

        public static readonly Error CompositionExist = Error.Conflict(
            code: "CompositionDomainErrors.EmptyUrl",
            description: "Composition with the same url has alredy exist");
    }
}
