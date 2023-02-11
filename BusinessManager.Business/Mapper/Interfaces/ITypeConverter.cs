using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Business.Mapper.Interfaces
{
    public interface ITypeConverter<in TSource, TDestination>
    {
        TDestination Convert(TSource source);
    }
}
