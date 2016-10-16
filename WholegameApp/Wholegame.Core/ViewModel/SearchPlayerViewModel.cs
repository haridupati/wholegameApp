using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wholegame.Core.Contracts.ViewModel;
using MvvmCross.Plugins.Messenger;
using Wholegame.Core.Model.App;

namespace Wholegame.Core.ViewModel
{
	public class SearchPlayerViewModel : BaseViewModel, ISearchPlayerViewModel
	{
		private string _searchPlayerName;
		public SearchPlayerViewModel(IMvxMessenger messenger) : base(messenger)
		{
		}

		public string SearchPlayerName
		{
			get { return _searchPlayerName; }
			set
			{
				if (value != _searchPlayerName)
				{
					_searchPlayerName = value;

					RaisePropertyChanged(() => SearchPlayerName);
				}
			}
		}

		public IMvxCommand SearchCommand
		{
			get
			{
				return new MvxCommand(() =>
					ShowViewModel<SearchResultViewModel>(new SearchParameters
					{
						PlayerName = SearchPlayerName
					}));
			}
		}

	}
}
