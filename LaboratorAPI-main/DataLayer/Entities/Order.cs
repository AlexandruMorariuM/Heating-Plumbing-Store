using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Order:BaseEntity
    {
        public int UserId { get; set; }
        public List<Item> OrderedItems { get; set; }
    }
}
