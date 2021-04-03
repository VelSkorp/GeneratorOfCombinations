using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeneratorOfCombinations
{
	public class MainViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// A set of elements 
		/// </summary>
		public List<string> Set { get; set; } = new List<string>();

		/// <summary>
		/// Combination size
		/// </summary>
		public string CombinationSize { get; set; }

		/// <summary>
		/// Possible combinations of m elements from the set of element with size n. 
		/// </summary>
		public List<string> Combinations { get; set; }

		/// <summary>
		/// A flag indicating if the calculate command is running
		/// </summary>
		public bool CalculateIsRunning { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command to сalculate сombinations
		/// </summary>
		public ICommand CalculateCommand { get; set; }

		/// <summary>
		/// The command to clear combinations
		/// </summary>
		public ICommand ClearCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public MainViewModel()
		{
			// Create commands
			CalculateCommand = new RelayCommand(async () => await CalculateCombinationsAsync());
			ClearCommand = new RelayCommand(ClearCombinations);
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// Clear сombinations
		/// </summary>
		public void ClearCombinations()
		{
			Combinations = new List<string>();
		}

		/// <summary>
		/// Calculate сombinations
		/// </summary>
		public async Task CalculateCombinationsAsync()
		{
			await RunCommandAsync(() => CalculateIsRunning, async () =>
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

				await Task.Delay(500);

				Combinations = Generator.Generate(Set, size);
			});
		}

		#endregion
	}
}