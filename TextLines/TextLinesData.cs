using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TextLines.Annotations;

namespace TextLines
{
	public class TextLinesData : INotifyPropertyChanged
	{
		private string _text;
		private string _filter;

		public string Text
		{
			get => _text;
			set
			{
				if (value == _text) return;
				_text = value;
				OnPropertyChanged();
			}
		}

		public string Filter
		{
			get => _filter;
			set
			{
				if (value == _filter) return;
				_filter = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}