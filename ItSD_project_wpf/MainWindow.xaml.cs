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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItSD_project_wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Simulation _simulation;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuItem_Click_NewSimulation(object sender, RoutedEventArgs e)
		{
			if (_simulation != null)
			{
				_simulation.Stop();
				_simulation.Dispose();
				_simulation = null;
			}
			var dialog = new AngleDialogBox();
			dialog.Owner = this;
			dialog.ShowDialog();
			if(dialog.CollectedData)
				_simulation = new Simulation(dialog.Angle, SimulationCanvas);
		}

		private void MenuItem_Click_Start(object sender, RoutedEventArgs e)
		{
			NewSimulationButton.IsEnabled = false;
			_simulation.Start();
		}

		private void MenuItem_Click_Stop(object sender, RoutedEventArgs e)
		{
			_simulation.Stop();
			NewSimulationButton.IsEnabled = true;
		}

		private void MenuItem_Click_AdjustSlipperySlope(object sender, RoutedEventArgs e)
		{

		}

		private void MenuItem_Click_AddBall(object sender, RoutedEventArgs e)
		{
			_simulation.AddBall(new Ball(new Point(250, 450), Vector.ZeroVector, 25, 1));
			//_simulation.AddBall(new Ball(new Point(300, 450), Vector.ZeroVector, 25, 1));
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(_simulation!=null)
				_simulation.Dispose();
		}
	}
}
