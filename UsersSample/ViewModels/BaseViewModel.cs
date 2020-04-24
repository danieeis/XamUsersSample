using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UsersSample.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void Refresh([CallerMemberName]string propertyName = null)
		{
			PropertyChanged?.Invoke(this,
				new PropertyChangedEventArgs(propertyName));
		}

		protected bool Set<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
		{
			if (!object.Equals(field, value))
			{
				field = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}
			return false;
		}
	}
}