using System.ComponentModel;

namespace ToggleSelector
{
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

		public event PropertyChangedEventHandler? PropertyChanged;
	}
}