namespace Entities.DataTransferObject
{
     
        public class CarDto
        {
            public int Id { get; set; }
            public int ColorId { get; set; }
            public int FuelId { get; set; }
            public int TransmissionId { get; set; }
            public string CarState { get; set; }
            public int? KiloMeter { get; set; }
            public short? ModelYear { get; set; }
            public string? Plate { get; set; }
            public string? BrandName { get; set; }
            public string? ModelName { get; set; }
            public double? DailyPrice { get; set; }
        }


}


 
