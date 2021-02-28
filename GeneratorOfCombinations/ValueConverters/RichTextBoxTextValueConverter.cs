using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace GeneratorOfCombinations
{
	public class RichTextBoxTextValueConverter : BaseValueConverter<RichTextBoxTextValueConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string stringValue = value as string;
			List<string> setOfItems = stringValue.Replace("\r", string.Empty)
												 .TrimEnd('\n')
												 .Split('\n')
												 .Where(item => !string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
												 .ToList();

			return setOfItems;
		}
	}
}