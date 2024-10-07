using RealEstateManagement.Domain.ClientModule;
using System.ComponentModel.DataAnnotations;

namespace RealEstateManagement.Web.Models
{
    public class CreateClientViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Cpf consists of 11 numbers")]
        public string Cpf { get; set; }

        public string? Phone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
    }

    public class ClientViewModel
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = null!;
        public string Cpf { get; set; } = null!;

        public string? Phone { get; set; }
        public string? Email { get; set; }
    }

    // Extensions, as mentioned in the class_52.txt file

    public static class ClientViewModelExtensions
    {
       
        // Conversion Vo to Vm
        public static ClientViewModel ToClientViewModel(this Client client) // Returns a ClientViewModel, defined above
        {
            return new ClientViewModel
            {
                ClientId = client.ClientId,
                Name = client.Name,
                Cpf = client.Cpf,
                Phone = client.Phone,
                Email = client.Email,
            };
        }

        // Conversion Vm to Vo
        public static Client ToClientVo(this ClientViewModel client)
        {
            // Mapping
            return new Client
            {
                ClientId = client.ClientId,
                Name = client.Name,
                Cpf = client.Cpf,
                Phone = client.Phone,
                Email = client.Email,
            };
        }


        public static List<ClientViewModel> ToClientsViewModel(this List<Client> clients)
        {
            var clientViewModels = new List<ClientViewModel>();
            clients.ForEach(client => clientViewModels.Add(client.ToClientViewModel()));
            return clientViewModels;
        }

       
    }


}