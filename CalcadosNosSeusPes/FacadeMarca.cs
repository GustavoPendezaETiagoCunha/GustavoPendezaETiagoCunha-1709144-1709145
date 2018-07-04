using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcadosNosSeusPes
{
    public class FacadeMarca
    {
        public IList<Marca> ObterMarca()
        {
            ModelSapato ctx = new ModelSapato();
            return ctx.Marcas.ToList();
        }
    }
}
