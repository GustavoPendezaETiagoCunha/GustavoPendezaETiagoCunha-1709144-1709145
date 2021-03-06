﻿using CalcadosNosSeusPes;
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
    /// Lógica interna para WindowGerenciamentoPessoaFisica.xaml
    /// </summary>
    public partial class WindowGerenciamentoPessoaFisica : Window, INotifyPropertyChanged
    {
        private PessoaFisica _Fisica = new PessoaFisica();
        public PessoaFisica PessoaFisicaSelecionada
        {
            get
            {
                return _Fisica;
            }
            set
            {
                _Fisica = value;
                this.NotifyPropertyChanged("PessoaFisicaSelecionada");
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
        public IList<PessoaFisica> PessoasF { get; set; }

        public WindowGerenciamentoPessoaFisica()
        {
            InitializeComponent();

            this.DataContext = this;
            this.PessoasF = ctx.PessoasF.ToList();

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

        PessoaFisica PessoaFisica = new PessoaFisica();

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoTime)
            {
                ctx.PessoasF.Add(PessoaFisicaSelecionada);
                ctx.SaveChanges();
                if (this.PessoaFisicaSelecionada.Id <= 0)
                {

                    ctx.PessoasF.Add(this.PessoaFisicaSelecionada);
                }
            }
            ctx.SaveChanges();
            MessageBox.Show("Cadastrado/Salvo com sucesso");
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PessoaFDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (PessoaFisica item in e.RemovedItems)
            {
                ctx.PessoasF.Remove(item);
            }
        }
    }
}
