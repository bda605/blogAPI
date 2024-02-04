using AutoMapper;
using BlogSystem.Model.Entitie;
using BlogSystem.Model.RequestViewModel;

namespace BlogSystem.Service.ConvertToClass
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<ArticleRequestVM,Article>();
        }
    }
}
