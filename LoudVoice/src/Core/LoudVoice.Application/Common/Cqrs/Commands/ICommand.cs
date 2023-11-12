using MediatR;

namespace LoudVoice.Application.Common.Cqrs.Commands
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
