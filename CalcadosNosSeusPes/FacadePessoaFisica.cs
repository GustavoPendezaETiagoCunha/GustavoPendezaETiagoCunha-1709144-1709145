using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcadosNosSeusPes
{
    public class FacadePessoaFisica
    {
        public IList<PessoaFisica> ObterPessoaFisicas()
        {
            ModelSapato ctx = new ModelSapato();
            return ctx.PessoasF.ToList();
        }
    }
}
