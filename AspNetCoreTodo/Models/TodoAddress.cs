using System;
using System.ComponentModel.DataAnnotations;
namespace AspNetCoreTodo.Models
{
    public class Address
    {
        public info info {get;set;}
    }

     public class info
    {
        public results [] results;
    }

}public class results
    {
       public locations[] locations;      
    }
   