using Dna;
using System.Windows;

namespace GeneratorOfCombinations
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		/// <summary>
		/// Custom startup so we load our IoC immediately before anything else
		/// </summary>
		/// <param name="e"></param>
		protected override void OnStartup(StartupEventArgs e)
		{
			// Let the base application do what it needs
			base.OnStartup(e);

			// Setup the Dna Framework
			Framework.Construct<DefaultFrameworkConstruction>()
				.AddFileLogger()
				.AddGeneratorOfCombinationsServices()
				.Build();
		}
	}
}