using AutoMapper;
using BakanasDigital.Think.Application.Interface;
using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BakanasDigital.Think.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _ClienteAppService;
        private readonly ICidadeAppService _CidadeAppService;
        private readonly IEstadoAppService _EstadoAppService;
        private readonly ICartaoCreditoAppService _CartaoCreditoAppService;

        //Por causa desse construtor, instalamos o Ninject.MVC5
        public ClientesController(IClienteAppService clienteAppService, ICidadeAppService cidadeAppService, IEstadoAppService estadoAppService, ICartaoCreditoAppService cartaoCreditoAppService)
        {
            _ClienteAppService = clienteAppService;
            _CidadeAppService = cidadeAppService;
            _EstadoAppService = estadoAppService;
            _CartaoCreditoAppService = cartaoCreditoAppService;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = _ClienteAppService.GetAll();
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientes);
            return View(clienteViewModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _ClienteAppService.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.GeneroID = new SelectList(Util.Util.ListGenero(), "Value", "Text");
            ViewBag.ComoSerTratadoID = new SelectList(Util.Util.ListComoTratar(), "Value", "Text");
            ViewBag.CidadeID = new SelectList(_CidadeAppService.GetAll(), "CidadeID", "Descricao");
            ViewBag.EstadoID = new SelectList(_EstadoAppService.GetAll(), "EstadoID", "Descricao");
            ViewBag.ComplementoID = new SelectList(Util.Util.ListComplemento(), "Value", "Text");
            ViewBag.CartaoCredito = _CartaoCreditoAppService;

            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CadastroPFViewModel p_ClienteViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var v_ClienteViewModel = p_ClienteViewModel.Cliente;

                    v_ClienteViewModel.DataCadastro = DateTime.Now;

                    var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(v_ClienteViewModel);


                    _ClienteAppService.Add(clienteDomain);

                    return RedirectToAction("Index");
                }

                return View(p_ClienteViewModel);
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            CadastroPFViewModel v_Cadastro = new CadastroPFViewModel();

            var cliente = _ClienteAppService.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            var v_CartaoCredito = _CartaoCreditoAppService.GetById(2);
            var v_CartaoViewModel = Mapper.Map<CartaoCredito, CartaoCreditoViewModel>(v_CartaoCredito);
                        

            ViewBag.GeneroID = new SelectList(Util.Util.ListGenero(), "Value", "Text", clienteViewModel.GeneroID);
            ViewBag.ComoSerTratadoID = new SelectList(Util.Util.ListComoTratar(), "Value", "Text", clienteViewModel.ComoSerTratadoID);
            ViewBag.CidadeID = new SelectList(_CidadeAppService.GetAll(), "CidadeID", "Descricao", cliente.CidadeID);
            ViewBag.EstadoID = new SelectList(_EstadoAppService.GetAll(), "EstadoID", "Descricao", cliente.EstadoID);
            ViewBag.ComplementoID = new SelectList(Util.Util.ListComplemento(), "Value", "Text", cliente.ComplementoID);

            v_Cadastro.Cliente = clienteViewModel;
            v_Cadastro.CartaoCredito = v_CartaoViewModel;

            return View(v_Cadastro);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CadastroPFViewModel p_Cadastro)
        {
            if(ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(p_Cadastro.Cliente);
                _ClienteAppService.Update(clienteDomain);

                var cartaoDomain = Mapper.Map<CartaoCreditoViewModel, CartaoCredito>(p_Cadastro.CartaoCredito);
                _CartaoCreditoAppService.Update(cartaoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.GeneroID = new SelectList(Util.Util.ListGenero(), "Value", "Text", p_Cadastro.Cliente.GeneroID);
            ViewBag.ComoSerTratadoID = new SelectList(Util.Util.ListComoTratar(), "Value", "Text", p_Cadastro.Cliente.ComoSerTratadoID);
            ViewBag.ComplementoID = new SelectList(Util.Util.ListComplemento(), "Value", "Text", p_Cadastro.Cliente.ComplementoID);
            ViewBag.CidadeID = new SelectList(_CidadeAppService.GetAll(), "CidadeID", "Descricao", p_Cadastro.Cliente.CidadeID);
            ViewBag.EstadoID = new SelectList(_EstadoAppService.GetAll(), "EstadoID", "Descricao", p_Cadastro.Cliente.EstadoID);

            return View(p_Cadastro);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _ClienteAppService.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _ClienteAppService.GetById(id);
            _ClienteAppService.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}
