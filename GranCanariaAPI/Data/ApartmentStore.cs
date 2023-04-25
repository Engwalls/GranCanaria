using GranCanariaAPI.Models.DTO;

namespace GranCanariaAPI.Data
{
    public static class ApartmentStore
    {
        public static List<ApartmentDto> apartmentList = new List<ApartmentDto>
        {
        new ApartmentDto{ApartmentId=1, Name="Beach Bungalow"},
        new ApartmentDto{ApartmentId=2, Name="Mountain Bungalow"},
        new ApartmentDto{ApartmentId=3, Name="Pool Bungalow"}
        };
    }
}
