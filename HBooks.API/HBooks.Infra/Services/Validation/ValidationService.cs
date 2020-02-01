using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HBooks.CrossCutting;
using HBooks.Domain.Entitites.Objects;
using HBooks.Domain.Services.Interfaces.Validation;

namespace HBooks.Infra.Services.Validation
{
    public class ValidationService : IValidationService
    {
        public bool Validate(object obj, out ResponseObject errorResult)
        {
            try
            {
                var objErr = ModelValidator.Validate(obj);

                if (objErr.Item1 == false)
                {
                    var errorsLine = new List<string>();
                    foreach (var err in objErr.Item2)
                    {
                        errorsLine.Add(err.ErrorMessage.ToUpper());
                    }
                    errorResult = ResponseObject.CreateInvalidField(string.Join(" / ", errorsLine));
                    return true;
                }
                errorResult = null;
                return false;
            }
            catch (System.Exception ex)
            {
                errorResult = ResponseObject.CreateSpecificError(ex);
                throw;
            }

        }
    }
}
