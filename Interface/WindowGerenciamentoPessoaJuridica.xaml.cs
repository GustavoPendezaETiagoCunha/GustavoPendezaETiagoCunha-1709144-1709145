using CalcadosNosSeusPes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Interface
{
    /// <summary>
    /// Lógica interna para WindowGerenciamentoPessoaJuridica.xaml
    /// </summary>
    public partial class WindowGerenciamentoPessoaJuridica : Window, INotifyPropertyChanged
    {
        private PessoaJuridica _Juridica = new PessoaJuridica();
        public PessoaJuridica PessoaJuridicaSelecionada
        {
            get
            {
                return _Juridica;
            }
            set
            {
                _Juridica = value;
                this.NotifyPropertyChanged("PessoaJuridicaSelecionada");
            }
        }

        public Boolean ModoCriacaoTime { get; set; } = false;

        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoTime)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }


        private ModelSapato ctx = new ModelSapato();
        public IList<PessoaJuridica> PessoasJ { get; set; }

        public WindowGerenciamentoPessoaJuridica()
        {
            InitializeComponent();

            this.DataContext = this;
            this.PessoasJ = ctx.PessoasJ.ToList();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(
                    Property));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        PessoaJuridica PessoaJuridica = new PessoaJuridica();

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoTime)
            {
                ctx.PessoasJ.Add(PessoaJuridicaSelecionada);
                ctx.SaveChanges();
                if (this.PessoaJuridicaSelecionada.Id <= 0)
                {

                    ctx.PessoasJ.Add(this.PessoaJuridicaSelecionada);
                }
            }
            ctx.SaveChanges();
            MessageBox.Show("Cadastrado/Salvo com sucesso");
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PessoaJDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (PessoaJuridica item in e.RemovedItems)
            {
                ctx.PessoasJ.Remove(item);
            }
        }
    }
}
