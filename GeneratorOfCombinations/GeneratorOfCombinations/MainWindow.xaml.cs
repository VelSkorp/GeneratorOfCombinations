using System.Windows;

namespace GeneratorOfCombinations
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataContext = new WindowViewModel();
		}
	}
}