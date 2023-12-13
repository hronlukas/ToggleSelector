using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Linq;
using System.Windows.Markup;
using System.Collections.Generic;

namespace Controls
{
	/// <summary>
	/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
	///
	/// Step 1a) Using this custom control in a XAML file that exists in the current project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:WpfApp4"
	///
	///
	/// Step 1b) Using this custom control in a XAML file that exists in a different project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:WpfApp4;assembly=WpfApp4"
	///
	/// You will also need to add a project reference from the project where the XAML file lives
	/// to this project and Rebuild to avoid compilation errors:
	///
	///     Right click on the target project in the Solution Explorer and
	///     "Add Reference"->"Projects"->[Browse to and select this project]
	///
	///
	/// Step 2)
	/// Go ahead and use your control in the XAML file.
	///
	///     <MyNamespace:ToggleSelector/>
	///
	/// </summary>
	[ContentProperty("Items")]
	[DefaultEvent("OnItemsChanged")]
	[DefaultProperty("Items")]
	[StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(ComboBoxItem))]
	public class ToggleSelector : ComboBox
	{
		public static readonly DependencyProperty IsCheckedProperty =
			DependencyProperty.Register(nameof(IsChecked), typeof(bool?), typeof(ToggleSelector), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		static ToggleSelector()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleSelector), new FrameworkPropertyMetadata(typeof(ToggleSelector)));
		}

		public bool? IsChecked
		{
			get { return (bool?)GetValue(IsCheckedProperty); }
			set { SetValue(IsCheckedProperty, value); }
		}

		public ToggleSelectorType ToggleType
		{
			get { return (ToggleSelectorType)GetValue(ToggleTypeProperty); }
			set { SetValue(ToggleTypeProperty, value); }
		}

		public static readonly DependencyProperty ToggleTypeProperty =
			DependencyProperty.Register(nameof(ToggleType), typeof(ToggleSelectorType), typeof(ToggleSelector), new PropertyMetadata(ToggleSelectorType.CheckBox));

		public string GroupName
		{
			get { return (string)GetValue(GroupNameProperty); }
			set { SetValue(GroupNameProperty, value); }
		}

		// Using a DependencyProperty as the backing store for GroupName.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty GroupNameProperty =
			DependencyProperty.Register(nameof(GroupName), typeof(string), typeof(ToggleSelector), new PropertyMetadata(string.Empty));
	}

	public enum ToggleSelectorType
	{
		CheckBox,
		RadioButton,
	}
}