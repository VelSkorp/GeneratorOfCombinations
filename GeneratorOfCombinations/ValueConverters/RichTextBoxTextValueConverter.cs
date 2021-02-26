using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

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
			var regex = new Regex(@"{\\ltrch (\w+)}");
			var setOfItems = new List<string>();
			string stringValue = value as string;

			MatchCollection matches = regex.Matches(stringValue);

			foreach (Match match in matches)
			{
				setOfItems.Add(match.Groups[1].Value);
			}

			return setOfItems;
		}
	}
}