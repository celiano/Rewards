using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RewardsWebApi.Models
{
    public class Response<T>
    {
        //public Response(bool succeeded)
        //{
        //    Succeeded = succeeded;
        //}
        public int ID { get; set; }
        public bool Succeeded {get; set;}
        public T Data { get; set; }
    }
}