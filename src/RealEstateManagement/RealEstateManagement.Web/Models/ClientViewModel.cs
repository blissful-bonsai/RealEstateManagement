using RealEstateManagement.Domain.ClientModule;
using System.ComponentModel.DataAnnotations;
//
// An extension method is a static method of a static class. The first parameter is prefixed with the this keyword, specifying the type it extends.
// When called, it appears as if the method is a member of the extended type
//
namespace RealEstateManagement.Web.Models
{
    public class CreateClientViewModel // This is used in the create and edit views, as we need the DataAnnotations
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Cpf consists of 11 numbers")]
        public string Cpf { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; } // (xx) xxxxx-xxxx

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

        public static Client ToClientVo(this CreateClientViewModel client)
        {
            // Mapping
            return new Client
            {
                Cpf = client.Cpf,
                Email = client.Email,
                Name = client.Name,
                Phone = client.Phone
            };
        }
        
        // Conversion method Client to Vm
        // ANY Client object will now have this method, or thesE methods defined below
        public static ClientViewModel ToClientViewModel(this Client client) // Returns a ClientViewModel, defined above. 
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