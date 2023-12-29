using System.Globalization;
using System.Windows.Data;

namespace ToggleSelector
{
	[ValueConversion(typeof(Enum), typeof(bool))]
	public sealed class EnumToBooleanConverter : IValueConverter
	{
		private static IValueConverter instance;

		public static IValueConverter Instance => instance ?? (instance = new EnumToBooleanConverter());

		/// <summary>
		/// Compares a value and parameter.
		/// </summary>
		/// <param name="value">The value produced by the binding source.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>True,if the value equals to parameter, otherwise false.</returns>
		/// <example>
		/// This example shows how to bind a radio button to enum.
		/// <code>
		///public GroupBy GroupBy
		///{
		///	get
		///	{
		///		return groupBy;
		///	}
		///
		///	set
		///	{
		///		if (value != groupBy)
		///		{
		///			groupBy = value;
		///			GroupData();
		///			OnPropertyChanged("GroupBy");
		///		}
		///	}
		///}
		///
		/// <ciuicc:EnumToBooleanConverter x:Key="EnumToBooleanConverter"/>
		///
		///<StackPanel Orientation="Horizontal">
		///	<RadioButton Content="By chapter" IsChecked="{Binding GroupBy, Converter={StaticResource EnumToBooleanConverter}, ConverterParameter={x:Static local:GroupBy.Chapter}}" Margin="5"/>
		///	<RadioButton Content="By check" IsChecked="{Binding GroupBy, Converter={StaticResource EnumToBooleanConverter}, ConverterParameter={x:Static local:GroupBy.Check}}" Margin="5"/>
		///	<RadioButton Content="By member" IsChecked="{Binding GroupBy, Converter={StaticResource EnumToBooleanConverter}, ConverterParameter={x:Static local:GroupBy.Member}}" Margin="5"/>
		///</StackPanel>
		/// </code>
		/// </example>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (parameter is string x)
			{
				return value.Equals(Enum.Parse(value.GetType(), x, false));
			}
			else
			{
				return value.Equals(parameter);
			}
		}

		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value that is produced by the binding target.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value.Equals(false))
			{
				return Binding.DoNothing;
			}
			else
			{
				if (parameter is string)
				{
					return Enum.Parse(targetType, (string)parameter, false);
				}
				else
				{
					return parameter;
				}
			}
		}
	}
}