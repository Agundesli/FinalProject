using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public int OrderId { get; set; }
        public string CutomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDATE { get; set; }
        public string ShipCity { get; set; }
    }
}
