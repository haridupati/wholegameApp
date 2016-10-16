using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wholegame.Core.Contracts.ViewModel;

namespace Wholegame.Core.ViewModel
{
	public class MainViewModel : MvxViewModel, IMainViewModel
	{
		private readonly Lazy<SearchPlayerViewModel> _searchPlayerViewModel;
		private readonly Lazy<ClubPlayersViewModel> _clubPlayersViewModel;
		private readonly Lazy<AboutViewModel> _aboutViewModel;

		public SearchPlayerViewModel SearchPlayerViewModel => _searchPlayerViewModel.Value;

		public ClubPlayersViewModel ClubPlayersViewModel => _clubPlayersViewModel.Value;

		public AboutViewModel AboutViewModel => _aboutViewModel.Value;

		public MainViewModel()
		{
			_searchPlayerViewModel = new Lazy<SearchPlayerViewModel>(Mvx.IocConstruct<SearchPlayerViewModel>);
			_clubPlayersViewModel = new Lazy<ClubPlayersViewModel>(Mvx.IocConstruct<ClubPlayersViewModel>);
			_aboutViewModel = new Lazy<AboutViewModel>(Mvx.IocConstruct<AboutViewModel>);
		}

		public void ShowMenu()
		{
			try
			{
				ShowViewModel<MenuViewModel>();
			}
			catch(Exception e)
			{
				throw e;
			}
			
		}

		public void ShowClubPlayers()
		{
			ShowViewModel<ClubPlayersViewModel>();
		}
	}
}
