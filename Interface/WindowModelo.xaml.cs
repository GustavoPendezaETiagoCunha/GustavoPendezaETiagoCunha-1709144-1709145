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
    /// Lógica interna para WindowModelo.xaml
    /// </summary>
    public partial class WindowModelo : Window, INotifyPropertyChanged
    {
        private Modelo _Modelo = new Modelo();
        public Modelo ModeloSelecionado
        {
            get
            {
                return _Modelo;
            }
            set
            {
                _Modelo = value;
                this.NotifyPropertyChanged("ModeloSelecionado");
            }
        }

        public Boolean ModoCriacaoTime { get; set; } = false;

        public ICollection<Marca> Marcas
        {
            get
            {
                return _marcas;
            }
            set
            {
                _marcas = value;
                this.NotifyPropertyChanged("Marca");
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
        private ICollection<Marca> _marcas;

        public IList<Modelo> Modelos { get; set; }

        public WindowModelo()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Modelos = ctx.Modelos.ToList();
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

        Modelo Modelo = new Modelo();

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoTime)
            {
                ctx.Modelos.Add(ModeloSelecionado);
                ctx.SaveChanges();
                if(this.ModeloSelecionado.Id <= 0)
                {
                    
                    ctx.Modelos.Add(this.ModeloSelecionado);
                }
            }
            ctx.SaveChanges();
            MessageBox.Show("Cadastrado/Salvo com sucesso");
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ModeloDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Modelo item in e.RemovedItems)
            {
                ctx.Modelos.Remove(item);
            }
        }
    }
}
