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
			var set = value as List<string>;

			return set.Count == 0 ? string.Empty : set.Aggregate((item, item2) => $"{item}\r\n{item2}");
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var stringValue = value as string;
			var setOfItems = stringValue.Replace("\r", string.Empty)
												 .TrimEnd('\n')
												 .Split('\n')
												 .Where(item => !string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
												 .ToList();

			return setOfItems;
		}
	}
}