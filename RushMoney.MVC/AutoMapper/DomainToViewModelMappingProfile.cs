using AutoMapper;
using RushMoney.Domain.Entities;
using RushMoney.MVC.ViewModels;

namespace RushMoney.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        { 
            get { return "ViewModelToDomainMappings"; } 
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClientViewModel, Client>();
            Mapper.CreateMap<TransactionViewModel, Transaction>();
            Mapper.CreateMap<AccountViewModel, Account>();
            Mapper.CreateMap<CategoryViewModel,Category>();
        }
    }
}
