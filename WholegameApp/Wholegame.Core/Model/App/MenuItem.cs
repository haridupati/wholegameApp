using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wholegame.Core.Utility;

namespace Wholegame.Core.Model.App
{
	public class MenuItem : MvxViewModel
	{
		private bool _isSelected;

		public string Title { get; set; }
		public Type ViewModelType { get; set; }
		public MenuOption Option { get; set; }
		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;
				RaisePropertyChanged(() => IsSelected);
			}
		}
	}
}
