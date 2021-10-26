using System;

namespace Salary.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name,object key) 
                : base($"Entity \"{name}\" ({key} was not found.")
        {

        }
    }
}
