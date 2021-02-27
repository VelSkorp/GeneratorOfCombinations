using System.Collections.Generic;
using System.Windows.Input;

namespace GeneratorOfCombinations
{
	public class MainViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// A set of elements 
		/// </summary>
		public List<string> Set { get; set; }

		/// <summary>
		/// Combination size
		/// </summary>
		public string CombinationSize { get; set; }

		/// <summary>
		/// Possible combinations of m elements from the set of element with size n. 
		/// </summary>
		public List<string> Combinations { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command to сalculate сombinations
		/// </summary>
		public ICommand CalculateCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public MainViewModel()
		{
			// Create commands
			CalculateCommand = new RelayCommand(CalculateCombinations);
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Calculate сombinations
		/// </summary>
		public void CalculateCombinations()
		{
			if (!int.TryParse(CombinationSize, out int size))
			{
				//TODO: Implement Dialog Window
				return;
			}

			Combinations = Generator.Generate(Set, size);
		}

		#endregion
	}
}