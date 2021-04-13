using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Rib
    { 
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
    }
}
