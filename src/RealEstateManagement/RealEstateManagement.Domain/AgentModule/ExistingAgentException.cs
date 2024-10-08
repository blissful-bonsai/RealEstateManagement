using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExistingAgentException : Exception
{
    public ExistingAgentException() : base("An agent with this information already exists") 
    {

    }

