using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.Common.DTOs
{
    public sealed class CompositionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint ListensCount { get; set; }
        public string Url { get; set; }
    }
}
