using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Basket : AbsBase
    {
        public virtual ICollection<BasketItem> BasketList { get; set; }
        public Basket()
        {
            BasketList = new List<BasketItem>();
        }
    }
}
