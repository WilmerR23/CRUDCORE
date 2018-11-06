using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticarNetCore.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int PaisId { get; set; }

        public virtual Pais Pais { get; set; }
    }
}
