using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Business.Mapper.Implementations
{
    internal class IEnumerableConverter : ITypeConverter<ICollection<object>, IEnumerable<object>>
    {
        public IEnumerable<object> Convert(ICollection<object> source, IEnumerable<object> destination, ResolutionContext context)
        {
            return source.AsEnumerable();
        }
    }
}
