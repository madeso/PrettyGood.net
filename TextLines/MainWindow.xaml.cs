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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextLines
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly TextLinesData app = new TextLinesData();

		public MainWindow()
		{
			InitializeComponent();

			this.DataContext = app;
		}

		private void Trim_Click(object sender, RoutedEventArgs e)
		{
			app.Text = TextLinesApp.Trim(app.Text);
		}
		
		private void Remove_Click(object sender, RoutedEventArgs e)
		{
			app.Text = TextLinesApp.RemoveEmpty(app.Text);
		}
		
		private void Unique_Click(object sender, RoutedEventArgs e)
		{
			app.Text = TextLinesApp.Unique(app.Text);
		}

		private void Sort_Click(object sender, RoutedEventArgs e)
		{
			app.Text = TextLinesApp.Sort(app.Text);
		}
		
		private void Filter_Click(object sender, RoutedEventArgs e)
		{
			app.Text = TextLinesApp.ExcludeContaining(app.Text, app.Filter);
		}
	}
}
