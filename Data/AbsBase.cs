using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class AbsBase
    {
        public string Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public AbsBase()
        {
            Id = Guid.NewGuid().ToString();
            TimeStamp = DateTime.Now;
        }
    }
}
