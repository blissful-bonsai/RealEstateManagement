using RealEstateManagement.Domain.ClientModule;
using RealEstateManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateManagement.Web.Views
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        //GetAll
        public async Task<IActionResult> Index()
        {
            var clientsVo = _clientService.GetClients();

            return View(clientsVo.ToClientsViewModel());
        }

        //GetById
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientService.GetById(id.Value);
            if (client == null)
            {
                return NotFound();
            }

            return View(client.ToClientViewModel());
        }

        //GET: Create
        public IActionResult Create()
        {
            return View();
        }
        //Post: Create
        [HttpPost]
        public async Task<IActionResult> Create(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _clientService.CreateClient(client.ToClientVo());
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", $"Error when creating : {ex.Message}");
                }
            }
            return View(client);
        } 
    }
}