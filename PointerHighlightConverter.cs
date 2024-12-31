using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace BrainfInterpreter
{
	public class PointerHighlightConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int index && parameter is int pointer)
			{
				// Zwraca kolor w zależności od porównania
				return index == pointer ? Colors.Red : Colors.Gray;
			}
			return Colors.Gray;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
