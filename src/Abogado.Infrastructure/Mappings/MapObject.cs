using Abogado.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Infrastructure.Mappings
{
    internal class MapObject : IMapObject
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            throw new NotImplementedException();
        }
    }
}
