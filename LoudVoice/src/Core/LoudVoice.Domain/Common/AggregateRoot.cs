using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Common
{
    public class AggregateRoot<TId> : BaseEntity<TId>
    {
        public AggregateRoot(TId id) : base(id)
        {
        }
    }
}
