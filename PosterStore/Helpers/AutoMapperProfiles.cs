using System.Linq;
using AutoMapper;
using PosterStore.Dtos;
using PosterStore.Models;

namespace PosterStore.Helpers
{
    public class AutoMapperProfiles : Profile
    {
      public AutoMapperProfiles()
      {
          CreateMap<Poster,PosterForListDto>()
            .ForMember(destination => destination.PhotoUrl, opt => {
              opt.MapFrom(src => src.PosterImages.FirstOrDefault(p => p.isMain).Url);
            });
          CreateMap<Poster,PosterForDetailedDto>()
            .ForMember(destination => destination.PhotoUrl, opt => {
              opt.MapFrom(src => src.PosterImages.FirstOrDefault(p => p.isMain).Url);
            });
          CreateMap<PosterImage, PosterImagesForDetail>();

      }  
    }
}