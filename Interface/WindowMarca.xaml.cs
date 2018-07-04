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
    /// Lógica interna para WindowMarca.xaml
    /// </summary>
    public partial class WindowMarca : Window, INotifyPropertyChanged
    {
        private Marca _Marca = new Marca();
        public Marca MarcaSelecionada
        {
            get
            {
                return _Marca;
            }
            set
            {
                _Marca = value;
                this.NotifyPropertyChanged("MarcaSelecionada");
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
        public IList<Marca> Marcas { get; set; }

        public WindowMarca()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Marcas = ctx.Marcas.ToList();

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

        Marca Marca = new Marca();

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoTime)
            {
                ctx.Marcas.Add(MarcaSelecionada);
                ctx.SaveChanges();
                if (this.MarcaSelecionada.Id <= 0)
                {

                    ctx.Marcas.Add(this.MarcaSelecionada);
                }
            }
            ctx.SaveChanges();
            MessageBox.Show("Cadastrado/Salvo com sucesso");
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MarcasDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Marca item in e.RemovedItems)
            {
                ctx.Marcas.Remove(item);
            }
        }
    }
}
