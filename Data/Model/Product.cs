using Core;
using Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Product : AbsBase
    {
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(10, 10000, ErrorMessage = "Please enter price between 10 to 10000.")]
        public int Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public Product()
        {

        }
        public Product ShallowCopy()
        {
            return (Product)this.MemberwiseClone();
        }
    }
}
