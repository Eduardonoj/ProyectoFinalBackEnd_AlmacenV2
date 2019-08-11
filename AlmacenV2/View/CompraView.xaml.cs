﻿using AlmacenV2.ModelView;
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
using System.Windows.Shapes;

namespace AlmacenV2.View
{
    /// <summary>
    /// Lógica de interacción para CompraView.xaml
    /// </summary>
    public partial class CompraView : Window
    {
        public CompraView()
        {
            InitializeComponent();
            this.DataContext = new CompraViewModel();
        }
    }
}
