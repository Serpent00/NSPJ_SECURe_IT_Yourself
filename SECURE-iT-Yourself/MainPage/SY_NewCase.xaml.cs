﻿using System;
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

namespace MainPage
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SY_NewCase : Window
    {
        public SY_NewCase()
        {
            InitializeComponent();
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {

        }

        private void Verify_Next(object sender, RoutedEventArgs e)
        {

            //Validation
            if (!(String.IsNullOrEmpty(case_name.Text)))
            {
                if (!(String.IsNullOrEmpty(case_desc.Text)))
                {
                    if (!(investigated_List.Items.Count==0))
                    {
                        //Push to next page and ask for network file



                    }
                    else
                    {
                        Console.WriteLine("Null or Empty");

                    }
                }
                else
                {
                    Console.WriteLine("Null or Empty");
                }
            }
            else {
                Console.WriteLine("Null or Empty");
            }

        }
    }
}
