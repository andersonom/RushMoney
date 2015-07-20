using AutoMapper;
using RushMoney.Domain.Entities;
using RushMoney.MVC.ViewModels;

namespace RushMoney.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Client, ClientViewModel>();
            Mapper.CreateMap<Transaction, TransactionViewModel >();
        }
    }
}
