using AutoMapper;
using LibraryModel;
using LibraryModel.Dtos;

namespace LibraryApi.helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
          
            CreateMap<Receipt,ReceiptDto>();
        }
    }
}
