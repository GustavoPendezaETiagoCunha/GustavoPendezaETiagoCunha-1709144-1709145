using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcadosNosSeusPes
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        public String Nome { get; set; }

        public String Fone { get; set; }

        public String Cep { get; set; }

        public String Endereco { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; } = new List<Venda>();
    }
}
