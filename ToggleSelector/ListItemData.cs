namespace ToggleSelector
{
	public class ListItemData
	{
		public ListItemData()
		{
		}

		public ListItemData(object value, object displayValue)
		{
			Value = value;
			DisplayValue = displayValue;
		}

		public object Value { get; set; }

		public object DisplayValue { get; set; }

		public object ToolTip { get; set; }
	}
}