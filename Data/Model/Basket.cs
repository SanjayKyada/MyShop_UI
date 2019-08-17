using System.Collections.Generic;

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
