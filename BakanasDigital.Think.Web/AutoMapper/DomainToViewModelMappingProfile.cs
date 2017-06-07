
using AutoMapper;
using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Web.ViewModels;

namespace BakanasDigital.Think.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            Configure();
        }
        //public override string ProfileName
        //{
        //    get { return "ViewModelToDomainMappings"; }
        //}

        protected void Configure()
        {
            //CreateMap<CadastroPFViewModel, Cliente>();
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<CidadeViewModel, Cidade>();
            CreateMap<EstadoViewModel, Estado>();
            CreateMap<CartaoCreditoViewModel, CartaoCredito>();
            //Mapper.CreateMap<ProdutoViewModel, Produto>();

            Mapper.Initialize(x =>
            {
                //x.CreateMap<CadastroPFViewModel, Cliente>();
                x.CreateMap<ClienteViewModel, Cliente>();
                x.CreateMap<CidadeViewModel, Cidade>();
                x.CreateMap<EstadoViewModel, Estado>();
                x.CreateMap<CartaoCreditoViewModel, CartaoCredito>();

            });


            Mapper.AssertConfigurationIsValid();

        }
    }
}