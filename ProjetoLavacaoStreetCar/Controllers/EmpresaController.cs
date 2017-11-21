﻿using ProjetoLavacaoStreetCar.Models;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoLavacaoStreetCar.Controllers
{
    public class EmpresaController : Controller
    {

        private ApplicationDbContext _context;


        public EmpresaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult Index()
        {

            var empresas = _context.Empresas.ToList();
            return View(empresas);
        }

        public ActionResult Details(int id)
        {
            var empresa = _context.Empresas.SingleOrDefault(c => c.Id == id);
            if (empresa == null)
            {
                return HttpNotFound();
            }

            return View(empresa);
        }

        public ActionResult New()
        {
            var empresa = new Empresa();

            return View("EmpresaForm", empresa);
        }

        [HttpPost] // só será acessada com POST
        //[ValidateAntiForgeryToken]
        public ActionResult Save(Empresa empresa) // recebemos um cliente
        {

            if (!ModelState.IsValid)
            {
                return View("EmpresaForm", empresa);
            }

            if (empresa.Id == 0)
            {
                // armazena o cliente em memória
                _context.Empresas.Add(empresa);
            }
            else
            {
                var empresaInDb = _context.Empresas.Single(c => c.Id == empresa.Id);


                empresaInDb.Nome = empresa.Nome;
                empresaInDb.Endereco = empresa.Endereco;
                empresaInDb.Cnpj = empresa.Cnpj;
                

            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var empresa = _context.Empresas.SingleOrDefault(c => c.Id == id);

            if (empresa == null)
                return HttpNotFound();


            return View("EmpresaForm", empresa);
        }

        public ActionResult Delete(int id)
        {
            var empresa = _context.Empresas.SingleOrDefault(c => c.Id == id);

            if (empresa == null)
                return HttpNotFound();

            _context.Empresas.Remove(empresa);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}