using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcadosNosSeusPes
{
    public class Modelo
    {
        [Key]
        public int Id { get; set; }

        public string TipoModelo { get; set; }
        
        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        public Boolean Cadarco { get; set; }

        public String Material { get; set; }

        public String Cor { get; set; }

        public virtual ICollection<Sapatos> Estoque { get; set; } = new List<Sapatos>();
    }
}
