using System.Windows;
using System.Windows.Controls;

namespace GeneratorOfCombinations
{
	/// <summary>
	/// The View Model for the custom flat window
	/// </summary>
	public class DialogWindowViewModel : WindowViewModel
	{
		#region Public Properties

		/// <summary>
		/// The title of this dialog window
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The content to host inside the dialog
		/// </summary>
		public Control Content { get; set; }

		/// <summary>
		/// The smallest width the window can go to
		/// </summary>
		public double WindowMinimumWidth { get; set; }

		/// <summary>
		/// The smallest height the window can go to
		/// </summary>
		public double WindowMinimumHeight { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public DialogWindowViewModel(Window window)
		{
			// Make minimum size smaller
			WindowMinimumWidth = 250;
			WindowMinimumHeight = 100;
		}

		#endregion
	}
}