using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HBooks.CrossCutting
{
    public class ModelValidator
    {
        public static Tuple<bool, List<ValidationResult>> Validate(object obj)
        {
            var resultValidation = new List<ValidationResult>();
            var context = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, context, resultValidation, true);

            var resultObj = new Tuple<bool, List<ValidationResult>>(resultValidation.Count == 0, resultValidation);
            return resultObj;
        }
    }
}
