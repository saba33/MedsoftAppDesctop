using AutoMapper;
using MedsofAppMVP.Model.entityModels;
using MedSoftAppRepo.Model;

namespace MedsofAppMVP.Infrastructure.Mapping
{
    public class MappingInitializer : Profile
    {
        public MappingInitializer()
        {


            CreateMap<UpdatePatientModel, PatientModel>().ReverseMap();
            CreateMap<AddPatientModel, PatientModel>().ReverseMap();
            CreateMap<PatientModel, Patient>().ReverseMap();
            CreateMap<PatientModel, UpdatePatientModel>().ReverseMap();
            CreateMap<PatientDisplayModel, PatientModel>().ReverseMap();

            CreateMap<Patient, AddPatientModel>()
                             .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.GenderName))
                             .ReverseMap();

            CreateMap<Patient, PatientModel>()
                             .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.GenderName))
                             .ReverseMap();


            CreateMap<Patient, UpdatePatientModel>()
                            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.GenderName))
                            .ReverseMap();

            CreateMap<PatientDisplayModel, Patient>()
                             .ForMember(dest => dest.GenderID, opt => opt.MapFrom(src => src.Gender.GenderID)) // Map GenderID
                                                                                                               //.ForMember(dest => dest.Gender.GenderName, opt => opt.MapFrom(src => src.GenderModel.GenderName)) // Map GenderID
                                                                                                               //.ForMember(dest => dest.Gender.GenderID, opt => opt.MapFrom(src => src.GenderModel.GenderName)) // Map GenderID
                             .AfterMap((src, dest) => dest.Gender = src.Gender); // Set the Gender object


            CreateMap<Patient, PatientDisplayModel>()
                         .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender.GenderName));


        }
    }
}
