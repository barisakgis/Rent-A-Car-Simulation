namespace Rent_A_Car_Simulation.DTOs
{
    public class CarDetailDto
    {
        public int Id { get; set; }
        public string? FuelName { get; set; }
        public string? TransmissionName { get; set; }
        public string? ColorName { get; set; }
        public string CarState { get; set; }
        public int? KiloMeter { get; set; }
        public short? ModelYear { get; set; }
        public string? Plate { get; set; }
        public string? BrandName { get; set; }
        public string? ModelName { get; set; }
        public double? DailyPrice { get; set; }
    }

}
