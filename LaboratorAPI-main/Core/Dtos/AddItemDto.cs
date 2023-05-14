using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class AddItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockCount { get; set; }
    }
}
