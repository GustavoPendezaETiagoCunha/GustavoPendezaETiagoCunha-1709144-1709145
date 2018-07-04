using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcadosNosSeusPes
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }

        public int SapatoId { get; set; }

        [ForeignKey("SapatoId")]
        public Sapatos Sapato { get; set; }

        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Pessoa Cliente { get; set; }

        public int Quantidade { get; set; }

        public DateTime? DataVenda { get; set; }

        public Decimal PrecoTotal { get; set; }
    }
}
