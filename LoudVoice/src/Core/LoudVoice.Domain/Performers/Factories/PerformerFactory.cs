using ErrorOr;
using LoudVoice.Domain.Performers.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Performers.Factories
{
    public sealed class PerformerFactory : IPerformerFactory
    {
        public Performer Create(string nickname, string description, Guid userId)
        {
            var performerId = PerformerId.CreateUnique();

            return new Performer(
                id: performerId,
                nickname: nickname,
                description: description,
                userId: userId);
        }
    }
}
