using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.ViewModels
{
    public class TranslatorViewModel : ViewModelBase
    {
		private string _russian;
		public string Russian
		{
			get
			{
				return _russian;
			}
			set
			{
				_russian = value;
				OnPropertyChanged();
			}
		}
		private string _english;
		public string English
		{
			get
			{
				return _english;
			}
			set
			{
				_english = value;
				OnPropertyChanged();
			}
		}
	}
}
