using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.Common.DTOs
{
    public sealed class PerformerDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
    }
}
