using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcadosNosSeusPes
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        public String MarcaMod { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
    }
}
