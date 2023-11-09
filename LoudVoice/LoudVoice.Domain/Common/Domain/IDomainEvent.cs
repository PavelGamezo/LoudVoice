using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Common.Domain
{
    public interface IDomainEvent : INotification
    {
    }
}
