namespace RealEstateManagement.Domain.ClientModule;

public class ExistingClientException : Exception
{
    public ExistingClientException() : base("Client with this information already exists")
    {
    }
}