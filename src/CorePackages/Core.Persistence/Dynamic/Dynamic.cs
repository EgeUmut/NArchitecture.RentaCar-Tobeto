using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic;

public class Dynamic
{
    public Dynamic()
    {
        
    }

    public Dynamic(IEnumerable<Sort>? sort, Filter? filter)
    {
        Sort = sort;
        Filter = filter;
    }

    public IEnumerable<Sort>? Sort { get; set; }
    public Filter? Filter { get; set; }
}
