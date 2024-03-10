using Adopet.Data.Dtos;
using Adopet.Models;
using AutoMapper;

namespace Adopet.Profiles;

public class TutorProfile : Profile
{
    public TutorProfile()
    {
        CreateMap<CreateTutorDto, Tutor>();
        CreateMap<UpdateTutorDto, Tutor>();
        CreateMap<Tutor, UpdateTutorDto>();
    }
}
