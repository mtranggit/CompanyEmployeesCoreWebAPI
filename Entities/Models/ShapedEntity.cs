using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ShapedEntity
    {
        public Entity Entity { get; set; }

        public Guid Id { get; set; }
        public ShapedEntity()
        {
            Entity = new Entity();
        }
    }
}
