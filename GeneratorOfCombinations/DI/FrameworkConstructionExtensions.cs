using Dna;
using Microsoft.Extensions.DependencyInjection;

namespace GeneratorOfCombinations
{
	/// <summary>
	/// Extension methods for the <see cref="FrameworkConstruction"/>
	/// </summary>
	public static class FrameworkConstructionExtensions
	{
		/// <summary>
		/// Injects the generator of combinations application services needed
		/// for the generator of combinations application
		/// </summary>
		/// <param name="construction"></param>
		/// <returns></returns>
		public static FrameworkConstruction AddGeneratorOfCombinationsServices(this FrameworkConstruction construction)
		{
			// Bind a UI Manager
			construction.Services.AddTransient<IUIManager, UIManager>();

			// Return the construction for chaining
			return construction;
		}
	}
}