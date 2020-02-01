using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBooks.Domain.Entitites.Objects
{
    public class ResponseObject
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public static ResponseObject CreateInvalidField(string returnMessage)
        {
            return new ResponseObject()
            {
                Code = 999,
                Message = returnMessage
            };
        }

        public static ResponseObject CreateSpecificError(System.Exception ex)
        {

            return new ResponseObject()
            {
                Code = 998,
                Message = ex.Message,

            };
        }
    }
}
