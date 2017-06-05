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
        public ActionResult Create(ClienteViewModel p_ClienteViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    p_ClienteViewModel.DataCadastro = DateTime.Now;

                    var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(p_ClienteViewModel);


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
            var cliente = _ClienteAppService.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            ViewBag.GeneroID = new SelectList(Util.Util.ListGenero(), "Value", "Text", clienteViewModel.GeneroID);
            ViewBag.ComoSerTratadoID = new SelectList(Util.Util.ListComoTratar(), "Value", "Text", clienteViewModel.ComoSerTratadoID);
            ViewBag.CidadeID = new SelectList(_CidadeAppService.GetAll(), "CidadeID", "Descricao", cliente.CidadeID);
            ViewBag.EstadoID = new SelectList(_EstadoAppService.GetAll(), "EstadoID", "Descricao", cliente.EstadoID);
            ViewBag.ComplementoID = new SelectList(Util.Util.ListComplemento(), "Value", "Text", cliente.ComplementoID);

            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if(ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _ClienteAppService.Update(clienteDomain);
            }

            ViewBag.GeneroID = new SelectList(Util.Util.ListGenero(), "Value", "Text", cliente.GeneroID);
            ViewBag.ComoSerTratadoID = new SelectList(Util.Util.ListComoTratar(), "Value", "Text", cliente.ComoSerTratadoID);
            ViewBag.ComplementoID = new SelectList(Util.Util.ListComplemento(), "Value", "Text", cliente.ComplementoID);

            return View(cliente);
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
