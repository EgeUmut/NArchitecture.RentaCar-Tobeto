using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Brand : BaseEntity<int>
{
    public Brand()
    {
        Models = new HashSet<Model>();
    }

    public Brand(int ıd, string name)
    {
        Id = ıd;
        Name = name;
    }


    public string Name { get; set; }
    public ICollection<Model>? Models { get; set; }
}
