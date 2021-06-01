using CaWorkshop.Domain.Entities;
using System;

namespace CaWorkshop.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{ name}\" ({key} was not found.")
        {

        }
    }
}
