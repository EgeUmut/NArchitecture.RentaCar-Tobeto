using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Model : BaseEntity<int>
{
    public Model()
    {
        Cars = new HashSet<Car>();
    }

    public Model(int ıd, int brandId, string name)
    {
        Id = ıd;
        BrandId = brandId;
        Name = name;
    }

    public int? BrandId { get; set; }
    public string Name { get; set; }
    public Brand? Brand { get; set; }
    public virtual ICollection<Car>? Cars { get; set; }
}
