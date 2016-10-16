using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;
using Wholegame.Core.Contracts.ViewModel;
using Wholegame.Core.Contracts.Services;
using Wholegame.Core.Model;
using Wholegame.Core.Extensions;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;

namespace Wholegame.Core.ViewModel
{
	public class ClubPlayersViewModel : BaseViewModel, IClubPlayersViewModel
	{
		private ObservableCollection<ClubPlayer> _clubPlayers;
		private IClubPlayerDataService _clubPlayerDataService;
		public ClubPlayersViewModel(IMvxMessenger messenger, IClubPlayerDataService clubPlayerDataService) : base(messenger)
		{
			_clubPlayerDataService = clubPlayerDataService;
		}

		public MvxCommand ReloadDataCommand
		{
			get
			{
				return new MvxCommand(async () =>
				{
					ClubPlayers = (await _clubPlayerDataService.GetClubPlayers(1)).ToObservableCollection();
				});
			}
		}


		public ObservableCollection<ClubPlayer> ClubPlayers
		{
			get { return _clubPlayers; }
			set
			{
				_clubPlayers = value;
				RaisePropertyChanged(() => ClubPlayers);
			}
		}

		public override async void Start()
		{
			base.Start();

			await ReloadDataAsync();
		}


		protected override async Task InitializeAsync()
		{
			await base.InitializeAsync();

			//if (_connectionService.CheckOnline())
			//{
				await LoadClubPlayers();

			//				}
			//else
			//{
			//	await _dialogService.ShowAlertAsync("No internet available", "My Trains says...", "OK");
			//	//maybe we can navigate to a start page here, for you to add to this code base!
			//}
		}

		internal async Task LoadClubPlayers()
		{
			ClubPlayers = (await _clubPlayerDataService.GetClubPlayers(1)).ToObservableCollection();			
		}
	}
}
