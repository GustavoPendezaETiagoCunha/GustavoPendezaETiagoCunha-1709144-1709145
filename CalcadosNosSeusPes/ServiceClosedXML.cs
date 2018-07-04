using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcadosNosSeusPes
{
    public class ServiceClosedXML
    {
        public static void CriarPlanilhaEstoque(IEnumerable<Sapatos> sapatos, String caminho)
        {
            ModelSapato ctx = new ModelSapato();
            
            //Criar um Workbook. Um arquvio excel.
            var workbook = new XLWorkbook();
            int ListaSapatosLinhaInicio = 1;
            int ListaSapatosLinhaInicio1 = 2;
            var worksheet = workbook.Worksheets.Add("Sapatos Em Estoque");
            foreach (Sapatos t in sapatos)
            {
                var modelo = ctx.Modelos.Find(t.ModeloId);

                //Um arquivo excel pode conter várias planilhas. 
            
               
               
                var columnModelo = worksheet.Column("A");
                var columnPreco = worksheet.Column("B");
                var columnTamanho = worksheet.Column("C");
                var columnQntDisponivel = worksheet.Column("D");
                
                columnModelo.Cell(ListaSapatosLinhaInicio).
                    Value = "Modelo";
                columnPreco.Cell(ListaSapatosLinhaInicio).
                    Value = "Preco";
                columnTamanho.Cell(ListaSapatosLinhaInicio).
                    Value = "Tamanho";
                columnQntDisponivel.Cell(ListaSapatosLinhaInicio).
                    Value = "QntDisponivel";

                columnModelo.Cell(ListaSapatosLinhaInicio1).
                   Value = modelo.TipoModelo;
                columnPreco.Cell(ListaSapatosLinhaInicio1).
                    Value = t.Preco;
                columnTamanho.Cell(ListaSapatosLinhaInicio1).
                    Value = t.Tamanho;
                columnQntDisponivel.Cell(ListaSapatosLinhaInicio1).
                    Value =t.QntDisponivel;
                worksheet.Row(ListaSapatosLinhaInicio).Style.Fill.BackgroundColor = XLColor.Gray;
                worksheet.Row(ListaSapatosLinhaInicio).Style.Font.Bold = true;
                ListaSapatosLinhaInicio1++;

            }
            //Excel pode utilizar a referência A1 [A1,B2...] ou R1C1
            //Se quiser ler mais sobre acesse o link: https://www.reddit.com/r/excel/comments/6tpgk3/reference_style_r1c1_vs_a1/
            workbook.ReferenceStyle = XLReferenceStyle.A1;
            //Calcular automaticamente os valores das fórmulas.
            workbook.CalculateMode = ClosedXML.Excel.XLCalculateMode.Auto;
            //Persistir o arquivo.
            workbook.SaveAs(caminho, true, evaluateFormulae: true);
        }
    }
}
