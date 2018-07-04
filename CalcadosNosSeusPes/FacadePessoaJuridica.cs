using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcadosNosSeusPes
{
    public class FacadePessoaJuridica
    {
        public IList<PessoaJuridica> ObterPessoaJuridicas()
        {
            ModelSapato ctx = new ModelSapato();
            return ctx.PessoasJ.ToList();
        }
    }
}
