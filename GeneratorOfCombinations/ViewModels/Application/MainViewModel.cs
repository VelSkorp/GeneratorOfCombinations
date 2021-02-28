﻿using System.Collections.Generic;
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
			CalculateCommand = new RelayCommand(CalculateCombinationsAsync);
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Calculate сombinations
		/// </summary>
		public async void CalculateCombinationsAsync()
		{
			if (!int.TryParse(CombinationSize, out int size))
			{
				await DI.UI.ShowMessage(new MessageBoxDialogViewModel()
				{
					Title = "Wrong format",
					Message = "Combination size must be a number"
				});

				return;
			}

			if (Set == null || Set.Count == 0)
			{
				await DI.UI.ShowMessage(new MessageBoxDialogViewModel()
				{
					Title = "Wrong format",
					Message = "Set must be filled"
				});

				return;
			}

			if (Set.Count < size)
			{
				await DI.UI.ShowMessage(new MessageBoxDialogViewModel()
				{
					Title = "Wrong format",
					Message = "The number of elements in the set must be greater than the size of the combination"
				});

				return;
			}

			Combinations = Generator.Generate(Set, size);
		}

		#endregion
	}
}