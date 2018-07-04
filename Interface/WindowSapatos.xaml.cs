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
    /// Lógica interna para WindowSapatos.xaml
    /// </summary>
    public partial class WindowSapatos : Window, INotifyPropertyChanged
    {
        private Sapatos _Sapatos = new Sapatos();
        public Sapatos SapatoSelecionado
        {
            get
            {
                return _Sapatos;
            }
            set
            {
                _Sapatos = value;
                this.NotifyPropertyChanged("SapatoSelecionado");
            }
        }

        public Boolean ModoCriacaoTime { get; set; } = false;

        public ICollection<Modelo> Modelos
        {
            get
            {
                return _modelo;
            }
            set
            {
                _modelo = value;
                this.NotifyPropertyChanged("Modelo");
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
        private ICollection<Modelo> _modelo;

        public IList<Sapatos> Estoque { get; set; }

        public WindowSapatos()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Estoque = ctx.Estoque.ToList();
            this.Modelos = ctx.Modelos.ToList();
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

        Sapatos Sapato = new Sapatos();

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoTime)
            {
                ctx.Estoque.Add(SapatoSelecionado);
                ctx.SaveChanges();
                if (this.SapatoSelecionado.Id <= 0)
                {

                    ctx.Estoque.Add(this.SapatoSelecionado);
                }
            }
            ctx.SaveChanges();
            MessageBox.Show("Cadastrado/Salvo com sucesso");
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SapatoDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Sapatos item in e.RemovedItems)
            {
                ctx.Estoque.Remove(item);
            }
        }
    }
}
