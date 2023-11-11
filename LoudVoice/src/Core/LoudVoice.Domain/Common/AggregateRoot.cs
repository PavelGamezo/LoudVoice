using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Common
{
    public class AggregateRoot : BaseEntity
    {
        public AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
