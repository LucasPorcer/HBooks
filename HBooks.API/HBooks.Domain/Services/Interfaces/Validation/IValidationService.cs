using HBooks.Domain.Entitites.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBooks.Domain.Services.Interfaces.Validation
{
    public interface IValidationService
    {
        bool Validate(object obj, out ResponseObject errorResult);
    }
}
