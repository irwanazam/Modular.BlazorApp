using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Events.Products
{
    public record ProductCreated(string Name,string EntityId,DateTime EventDate);
}
