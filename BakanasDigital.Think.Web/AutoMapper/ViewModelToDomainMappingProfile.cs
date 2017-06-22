
using AutoMapper;
using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Web.ViewModels;

namespace BakanasDigital.Think.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            Configure();
        }
        //public override string ProfileName
        //{
        //    get { return "DomainToViewModelMappings"; }
        //}

        protected void Configure()
        {
            //CreateMap<Cliente, CadastroPFViewModel>();
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<CartaoCredito, CartaoCreditoViewModel>();
            CreateMap<EnderecoInformacao, EnderecoInformacaoViewModel>();
            //Mapper.CreateMap<Produto, ProdutoViewModel>();

            Mapper.Initialize(x =>
            {
                //x.CreateMap<Cliente, CadastroPFViewModel>();
                x.CreateMap<Cliente, ClienteViewModel>();
                x.CreateMap<Cidade, CidadeViewModel>();
                x.CreateMap<Estado, EstadoViewModel>();
                x.CreateMap<CartaoCredito, CartaoCreditoViewModel>();
                x.CreateMap<EnderecoInformacao, EnderecoInformacaoViewModel>();

            });

            Mapper.AssertConfigurationIsValid();

        }
    }
}