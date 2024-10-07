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


        //GET: Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientsVo = _clientService.GetClients();
            var client = clientsVo.FirstOrDefault(c => c.ClientId == id);
            if(client == null)
            {
                return NotFound();
            }
            return View(client.ToClientViewModel());
        }

        //POST: Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ClientViewModel client)
        {
            if(id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _clientService.SaveClient(client.ToClientVo());
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", $"Error when editing : {ex.Message}");
                }
            }
            return View(client);
        }

        //GET: Remove
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientService.GetById(id);
            if(client == null)
            {
                return NotFound();
            }

            return View(client.ToClientViewModel());
        }
        //Post: Remove
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _clientService.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error when editing: { ex.Message}");
            }
            return View(_clientService.GetById(id).ToClientViewModel());
        }
    }
}





































