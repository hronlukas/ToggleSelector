using System.ComponentModel;

namespace ToggleSelector
{
	//public enum ViewType
	//{
	//	Zoom,
	//	ZoomByWindow,
	//	Pan,
	//}

	public class ViewModel : INotifyPropertyChanged
	{
		public List<string> Items { get; } = new List<string>
		{
			"zoom",
			"zoom by window",
			"pan",
		};

		private string selectedItem = "zoom";
		public string SelectedItem
		{
			get => selectedItem;
			set
			{
				if (selectedItem != value)
				{
					selectedItem = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
				}
			}
		}

		private bool selected = true;
		public bool IsSelected
		{
			get => selected;
			set
			{
				if (selected != value)
				{
					selected = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
				}
			}
		}

		private bool selected2 = true;
		public bool IsSelected2
		{
			get => selected2;
			set
			{
				if (selected2 != value)
				{
					selected2 = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected2)));
				}
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;
	}
}