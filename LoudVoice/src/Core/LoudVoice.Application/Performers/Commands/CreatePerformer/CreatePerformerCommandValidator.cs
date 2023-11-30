using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.Performers.Commands.CreatePerformer
{
    public class CreatePerformerCommandValidator : AbstractValidator<CreatePerformerCommand>
    {
        public CreatePerformerCommandValidator() 
        {
            RuleFor(performerCommand => performerCommand.Nickname)
                .NotEmpty().WithMessage("Nickname should be not empty");
        }
    }
}
