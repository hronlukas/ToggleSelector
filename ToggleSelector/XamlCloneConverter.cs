using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xml;

namespace ToggleSelector
{
	public sealed class XamlCloneConverter : IValueConverter
	{
		private static IValueConverter instance;

		public static IValueConverter Instance => instance ?? (instance = new XamlCloneConverter());

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string xaml = XamlWriter.Save(value);
			StringReader stringReader = new StringReader(xaml);
			XmlReader xmlReader = XmlReader.Create(stringReader);
			object @object = XamlReader.Load(xmlReader);
			return @object;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}