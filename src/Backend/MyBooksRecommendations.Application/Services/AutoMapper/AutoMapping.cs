using AutoMapper;
using MyBooksRecommendations.Communication.Response;

namespace MyBooksRecommendations.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            DomainToResponse();
        }

        private void DomainToResponse()
        {
            CreateMap<Domain.Entity.Book, ResponseBookJson>()
                .ForMember(c => c.Status, opt => opt.MapFrom(w => (uint)w.Status))
                .ForMember(c => c.Type, opt => opt.MapFrom(w => (uint)w.Type));
        }
    }
}
