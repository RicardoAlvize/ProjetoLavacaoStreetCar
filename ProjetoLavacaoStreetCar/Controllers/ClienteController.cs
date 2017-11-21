using ProjetoLavacaoStreetCar.Models;
using ProjetoLavacaoStreetCar.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace ProjetoLavacaoStreetCar.Controllers
{
    public class ClienteController : Controller
    {

        private ApplicationDbContext _context;

        public ClienteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var cliente = _context.Clientes.Include(c => c.Carro).ToList();
            return View(cliente);
        }

        public ActionResult Details(int id)
        {
            var cliente = _context.Clientes.Include(c => c.Carro).SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        public ActionResult New()
        {
            var carros = _context.Carros.ToList();
            var viewModel = new ClienteIndexViewModel
            {
                Cliente = new Cliente(),
                Carros = carros
            };

            return View("ClienteForm", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Save(Cliente cliente) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ClienteIndexViewModel
                {
                    Cliente = cliente,
                    Carros = _context.Carros.ToList()
                };

                return View("ClienteForm", viewModel);
            }

            if (cliente.Id == 0)
            {
                // armazena o cliente em memória
                _context.Clientes.Add(cliente);
            }
            else
            {
                var clienteInDb = _context.Clientes.Single(c => c.Id == cliente.Id);

              
                clienteInDb.Nome = cliente.Nome;
                clienteInDb.Sobrenome = cliente.Sobrenome;

            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            var viewModel = new ClienteIndexViewModel
            {
                Cliente = cliente,
                Carros = _context.Carros.ToList()
            };

            return View("ClienteForm", viewModel);
        }
    }
 }
