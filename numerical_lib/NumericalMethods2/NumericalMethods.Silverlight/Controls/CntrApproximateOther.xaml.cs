﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace NumericalMethods_Silverlight
{
	public partial class CntrApproximateOther : UserControl
    {
        WndModify wndModify;
		public CntrApproximateOther()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {

            wndModify = new WndModify();
            wndModify.Closed += new EventHandler(WndModify_Closed);
            wndModify.SetFunction(nameFunction.Text);
            wndModify.Show();
        }
        private void WndModify_Closed(object sender, EventArgs e)
        {
            if ((bool)wndModify.DialogResult)
            {
                nameFunction.Text = wndModify.ContenFunction.Text;
            }
        }
	}
}