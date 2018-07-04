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
    /// Lógica interna para WindowVenda.xaml
    /// </summary>
    public partial class WindowVenda : Window, INotifyPropertyChanged
    {
        private Venda _Vendas = new Venda();
        public Venda VendaSelecionada
        {
            get
            {
                return _Vendas;
            }
            set
            {
                _Vendas = value;
                this.NotifyPropertyChanged("VendaSelecionada");
            }
        }

        public Boolean ModoCriacaoTime { get; set; } = false;

        public ICollection<Sapatos> Sapato //sapatos
        {
            get
            {
                return _Sapato;
            }
            set
            {
                _Sapato = value;
                this.NotifyPropertyChanged("Sapato");
            }
        }
        public ICollection<Pessoa> Pessoas //cliente
        {
            get
            {
                return _Pessoas;
            }
            set
            {
                _Pessoas = value;
                this.NotifyPropertyChanged("Pessoas");
            }
        }

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
        private ICollection<Sapatos> _Sapato; //sapatos
        private ICollection<Pessoa> _Pessoas; //cliente 

        public IList<Venda> Vendas { get; set; }

        public WindowVenda()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Vendas = ctx.Vendas.ToList();
            this.Sapato = ctx.Estoque.ToList(); //sapatos
            this.Pessoas = ctx.Pessoas.ToList(); //cliente 
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

        Venda Venda = new Venda();

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoTime)
            {
                ctx.Vendas.Add(VendaSelecionada);
                ctx.SaveChanges();
                if (this.VendaSelecionada.Id <= 0)
                {

                    ctx.Vendas.Add(this.VendaSelecionada);
                }
            }
            ctx.SaveChanges();
            MessageBox.Show("Cadastrado/Salvo com sucesso");
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void VendaDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Venda item in e.RemovedItems)
            {
                ctx.Vendas.Remove(item);
            }
        }
    }
}
