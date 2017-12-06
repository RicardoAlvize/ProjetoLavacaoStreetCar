using ProjetoLavacaoStreetCar.Models;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoLavacaoStreetCar.Controllers
{
    public class CarroController : Controller
    {

        private ApplicationDbContext _context;


        public CarroController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        
        public ActionResult Index()
        {

            var carro = _context.Carros.ToList();
            if (User.IsInRole(RoleName.CanManageCustomers))
                return View(carro);

            return View("ReadOnlyIndex", carro);

            
        }
        [Authorize(Roles = RoleName.CanManageCarros)]
        public ActionResult New()
        {
            var carro = new Carro();

            return View("CarroForm", carro);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageCarros)]
        public ActionResult Save(Carro carro) // recebemos um cliente
        {

            if (!ModelState.IsValid)
            {
                return View("CarroForm", carro);
            }

            if (carro.Id == 0)
            {
                // armazena o cliente em memória
                _context.Carros.Add(carro);
            }
            else
            {
                var carroInDb = _context.Carros.Single(c => c.Id == carro.Id);


                carroInDb.Marca = carro.Marca;
                carroInDb.Modelo = carro.Modelo;
                carroInDb.Cor = carro.Cor;
                carroInDb.Placa = carro.Placa;

    }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }
        [Authorize(Roles = RoleName.CanManageCarros)]
        public ActionResult Edit(int id)
        {
            var carro = _context.Carros.SingleOrDefault(c => c.Id == id);

            if (carro == null)
                return HttpNotFound();


            return View("CarroForm", carro);
        }
        [Authorize(Roles = RoleName.CanManageCarros)]
        public ActionResult Delete(int id)
        {
            var carro = _context.Carros.SingleOrDefault(c => c.Id == id);

            if (carro == null)
                return HttpNotFound();

            _context.Carros.Remove(carro);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}