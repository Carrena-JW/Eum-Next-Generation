using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eum.Shared.Common.Interfaces
{
    public interface IEvent
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
    }
}
