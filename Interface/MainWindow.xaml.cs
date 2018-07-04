using CalcadosNosSeusPes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender == MenuGerenciarPessoaFisica)
            {
                WindowGerenciamentoPessoaFisica window =
                new WindowGerenciamentoPessoaFisica();
                window.ShowDialog();
            }else if(sender == MenuNovaPessoaFisica)
            {
                WindowGerenciamentoPessoaFisica window =
                new WindowGerenciamentoPessoaFisica();
                window.ModoCriacaoTime = true;
                window.ShowDialog();
            }
            else if (sender == MenuNovaPessoaJuridica)
            {
                WindowGerenciamentoPessoaJuridica window =
                new WindowGerenciamentoPessoaJuridica();
                window.ModoCriacaoTime = true;
                window.ShowDialog();
            }
            else if (sender == MenuGerenciarPessoaJuridica)
            {
                WindowGerenciamentoPessoaJuridica window =
                new WindowGerenciamentoPessoaJuridica();
                window.ShowDialog();
            }
            else if (sender == MenuGerenciarMarca)
            {
                WindowMarca window =
                new WindowMarca();
                window.ShowDialog();
            }
            else if (sender == MenuNovaMarca)
            {
                WindowMarca window =
                new WindowMarca();
                window.ModoCriacaoTime = true;
                window.ShowDialog();
            }
            else if (sender == MenuGerenciarModelo)
            {
                WindowModelo window =
                new WindowModelo();
                window.ShowDialog();
            }
            else if (sender == MenuNovoModelo)
            {
                WindowModelo window =
                new WindowModelo();
                window.ModoCriacaoTime = true;
                window.ShowDialog();
            }
            else if (sender == MenuGerenciarSapato)
            {
                WindowSapatos window =
                new WindowSapatos();
                window.ShowDialog();
            }
            else if (sender == MenuNovoSapato)
            {
                WindowSapatos window =
                new WindowSapatos();
                window.ModoCriacaoTime = true;
                window.ShowDialog();
            }
            else if (sender == MenuGerenciarVenda)
            {
                WindowVenda window =
                new WindowVenda();
                window.ShowDialog();
            }
            else if (sender == MenuNovaVenda)
            {
                WindowVenda window =
                new WindowVenda();
                window.ModoCriacaoTime = true;
                window.ShowDialog();
            }
            else if (sender == MenuNovoRelatorio)
            {
                ModelSapato ctx = new ModelSapato();
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Relatorio"; // Nome padrão
                dlg.DefaultExt = ".xlsx"; // Extensão do arquivo
                dlg.Filter = "Excel (.xlsx)|*.xlsx"; // Filtros
                Nullable<bool> result = dlg.ShowDialog();

                // Somente irá salvar se o usuário selecionar um arquivo.
                if (result == true)
                {
                    // Salvar Documento
                    ServiceClosedXML.CriarPlanilhaEstoque(ctx.Estoque.ToList(), dlg.FileName);
                }
            }
        }
    }
}
