using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Car : BaseEntity<int>
{
    public Car()
    {
        CarImages = new HashSet<CarImage>();
    }

    public Car(int modelId, int modelYear, string plate, int state, double dailyPrice) : this()
    {
        ModelId = modelId;
        ModelYear = modelYear;
        Plate = plate;
        State = state;
        DailyPrice = dailyPrice;
    }

    public int? ModelId { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }
    public double DailyPrice { get; set; }
    public ICollection<CarImage> CarImages { get; set; }
    public Model? Model { get; set; }
}
