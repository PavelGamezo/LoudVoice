using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.Performers.Queries.GetPerformer
{
    public sealed class GetPerformerQueryValidator : AbstractValidator<GetPerformerQuery>
    {
        public GetPerformerQueryValidator() 
        {
            RuleFor(query => query.Id)
                .NotEmpty().WithMessage("Performer ID must be entered");

            RuleFor(query => query.Nickname)
                .NotEmpty().WithMessage("Nickname should be not empty");
        }
    }
}
