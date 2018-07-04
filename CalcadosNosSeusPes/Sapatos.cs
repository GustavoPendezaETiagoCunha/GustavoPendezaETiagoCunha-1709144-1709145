using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcadosNosSeusPes
{
    public class Sapatos
    {
        [Key]
        public int Id { get; set; }

        public int ModeloId { get; set; }

        [ForeignKey("ModeloId")]
        public Modelo Modelo { get; set; }

        public Decimal Preco { get; set; }

        public int Tamanho { get; set; }

        public int QntDisponivel { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; } = new List<Venda>();
    }
}
