using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories;

public class BaseEntity<TId>: IEntityTimestamps
{
    public TId Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    //public bool? DeleteStatus { get; set; }

    public BaseEntity()
    {
        
    }

    public BaseEntity(TId ıd)
    {
        Id = ıd;
    }
}
