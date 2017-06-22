using AutoMapper;
using BakanasDigital.Think.Application.Interface;
using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Web.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;

namespace BakanasDigital.Think.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _ClienteAppService;
        private readonly ICidadeAppService _CidadeAppService;
        private readonly IEstadoAppService _EstadoAppService;
        private readonly ICartaoCreditoAppService _CartaoCreditoAppService;
        private readonly IEnderecoInformacaoAppService _EnderecoAppService;

        //Por causa desse construtor, instalamos o Ninject.MVC5
        public ClientesController(IClienteAppService clienteAppService, ICidadeAppService cidadeAppService, IEstadoAppService estadoAppService, ICartaoCreditoAppService cartaoCreditoAppService, IEnderecoInformacaoAppService enderecoAppService)
        {
            _ClienteAppService = clienteAppService;
            _CidadeAppService = cidadeAppService;
            _EstadoAppService = estadoAppService;
            _CartaoCreditoAppService = cartaoCreditoAppService;
            _EnderecoAppService = enderecoAppService;
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

            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CadastroPFViewModel p_ClienteViewModel, FormCollection p_FormCollection)
        {
            try
            {//ClienteID é obrigatório
                if (ModelState.IsValid)
                {
                    p_ClienteViewModel.Cliente.GeneroID = Convert.ToInt32(p_FormCollection["GeneroID"]);
                    p_ClienteViewModel.Cliente.ComoSerTratadoID = Convert.ToInt32(p_FormCollection["ComoSerTratadoID"]);
                    p_ClienteViewModel.Cliente.ComplementoID = Convert.ToInt32(p_FormCollection["ComplementoID"]);
                    p_ClienteViewModel.Cliente.CidadeID = Convert.ToInt32(p_FormCollection["CidadeID"]);
                    p_ClienteViewModel.Cliente.EstadoID = Convert.ToInt32(p_FormCollection["EstadoID"]);

                    ClienteViewModel v_ClienteViewModel = p_ClienteViewModel.Cliente;
                    CartaoCreditoViewModel v_CartaoViewModel = p_ClienteViewModel.CartaoCredito;
                    EnderecoInformacaoViewModel v_EndeerecoViewModel = p_ClienteViewModel.EnderecoInformacao;

                    v_ClienteViewModel.DataCadastro = DateTime.Now;
                    

                    Cliente v_Cliente = Mapper.Map<ClienteViewModel, Cliente>(v_ClienteViewModel);
                    CartaoCredito v_CartaoCredito = Mapper.Map<CartaoCreditoViewModel, CartaoCredito>(v_CartaoViewModel);
                    EnderecoInformacao v_Endereco = Mapper.Map<EnderecoInformacaoViewModel, EnderecoInformacao>(v_EndeerecoViewModel);

                    _ClienteAppService.Add(v_Cliente);

                    v_CartaoCredito.ClienteID = v_Cliente.ClienteID;
                    _CartaoCreditoAppService.Add(v_CartaoCredito);

                    v_Endereco.ClienteID = v_Cliente.ClienteID;
                    _EnderecoAppService.Add(v_Endereco);

                    return RedirectToAction("Index");
                }

                ViewBag.GeneroID = new SelectList(Util.Util.ListGenero(), "Value", "Text", p_ClienteViewModel.Cliente.GeneroID);
                ViewBag.ComoSerTratadoID = new SelectList(Util.Util.ListComoTratar(), "Value", "Text", p_ClienteViewModel.Cliente.ComoSerTratadoID);
                ViewBag.ComplementoID = new SelectList(Util.Util.ListComplemento(), "Value", "Text", p_ClienteViewModel.Cliente.ComplementoID);
                ViewBag.CidadeID = new SelectList(_CidadeAppService.GetAll(), "CidadeID", "Descricao", p_ClienteViewModel.Cliente.CidadeID);
                ViewBag.EstadoID = new SelectList(_EstadoAppService.GetAll(), "EstadoID", "Descricao", p_ClienteViewModel.Cliente.EstadoID);

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

            var v_CartaoCredito = _CartaoCreditoAppService.GetByClienteID(cliente.ClienteID).FirstOrDefault();
            var v_CartaoViewModel = Mapper.Map<CartaoCredito, CartaoCreditoViewModel>(v_CartaoCredito);

            var v_EnderecoInformacao = _EnderecoAppService.GetByClienteID(cliente.ClienteID);
            var v_EnderecoViewModel = Mapper.Map<EnderecoInformacao, EnderecoInformacaoViewModel>(v_EnderecoInformacao);

            ViewBag.imagemPerfil = GetImagemPerfil(id);
            ViewBag.GeneroID = new SelectList(Util.Util.ListGenero(), "Value", "Text", clienteViewModel.GeneroID);
            ViewBag.ComoSerTratadoID = new SelectList(Util.Util.ListComoTratar(), "Value", "Text", clienteViewModel.ComoSerTratadoID);
            ViewBag.CidadeID = new SelectList(_CidadeAppService.GetAll(), "CidadeID", "Descricao", cliente.CidadeID);
            ViewBag.EstadoID = new SelectList(_EstadoAppService.GetAll(), "EstadoID", "Descricao", cliente.EstadoID);
            ViewBag.ComplementoID = new SelectList(Util.Util.ListComplemento(), "Value", "Text", cliente.ComplementoID);

            v_Cadastro.Cliente = clienteViewModel;
            v_Cadastro.CartaoCredito = v_CartaoViewModel;
            v_Cadastro.EnderecoInformacao = v_EnderecoViewModel;

            return View(v_Cadastro);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CadastroPFViewModel p_Cadastro, FormCollection p_FormCollection)
        {
            if(ModelState.IsValid)
            {
                p_Cadastro.Cliente.GeneroID = Convert.ToInt32(p_FormCollection["GeneroID"]);
                p_Cadastro.Cliente.ComoSerTratadoID = Convert.ToInt32(p_FormCollection["ComoSerTratadoID"]);
                p_Cadastro.Cliente.ComplementoID = Convert.ToInt32(p_FormCollection["ComplementoID"]);
                p_Cadastro.Cliente.CidadeID = Convert.ToInt32(p_FormCollection["CidadeID"]);
                p_Cadastro.Cliente.EstadoID = Convert.ToInt32(p_FormCollection["EstadoID"]);

                
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(p_Cadastro.Cliente);
                _ClienteAppService.Update(clienteDomain);

                var cartaoDomain = Mapper.Map<CartaoCreditoViewModel, CartaoCredito>(p_Cadastro.CartaoCredito);
                _CartaoCreditoAppService.Update(cartaoDomain);

                var EnderecoDomain = Mapper.Map<EnderecoInformacaoViewModel, EnderecoInformacao>(p_Cadastro.EnderecoInformacao);
                _EnderecoAppService.Update(EnderecoDomain);

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

        [HttpPost]
        public ActionResult UploadFile2(HttpPostedFileBase p_File, CadastroPFViewModel p_Cadastro)
        {
            if(p_File != null && p_File.ContentLength > 0)
            {
                try
                {
                    string v_Path = Server.MapPath("~/File/Cliente" + p_Cadastro.Cliente.ClienteId + "/Perfil");

                    if (!Directory.Exists(v_Path))
                    {
                        Directory.CreateDirectory(v_Path);
                    }

                    v_Path = Path.Combine(v_Path, Path.GetFileName(p_File.FileName));
                    p_File.SaveAs(v_Path);
                    ViewBag.Message = "File uploaded successfully";  
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();  
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return View(p_Cadastro);
        }

        [HttpPost]
        public string UploadFile(string p_ClienteId)
        {

            var p_File = Request.Files[0];
            var fileName = Path.GetFileName(p_File.FileName);

            if (p_File != null && p_File.ContentLength > 0)
            {
                try
                {
                    string v_Path = Server.MapPath("~/File/Cliente" + p_ClienteId + "/Perfil");

                    if (!Directory.Exists(v_Path))
                    {
                        Directory.CreateDirectory(v_Path);
                    }
                    else
                    {
                        string[] v_File = Directory.GetFiles(v_Path);

                        foreach (string v_item in v_File)
                        {
                           System.IO.File.Delete(v_item);
                        }
                    }

                    v_Path = Path.Combine(v_Path, Path.GetFileName(p_File.FileName));
                    p_File.SaveAs(v_Path);
                    ViewBag.Message = "File uploaded successfully";
                    ViewBag.imagemPerfil = GetImagemPerfil(Convert.ToInt32(p_ClienteId));

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return ViewBag.imagemPerfil;
        }

        [HttpPost]
        public string GetImagemPerfil(int p_ClienteID)
        {
            string v_Path = Server.MapPath("~/File/Cliente" + p_ClienteID + "/Perfil");
            string v_Imagem = string.Empty;
            string[] v_File;

            if(Directory.Exists(v_Path))
            {
                v_File = Directory.GetFiles(v_Path);

                v_Imagem = v_File[0].Replace(@"D:\Sistema\Think\BakanasDigital.Think.Web", "").Replace("\\", "/");
            }

            return v_Imagem;
        }

    }
}
