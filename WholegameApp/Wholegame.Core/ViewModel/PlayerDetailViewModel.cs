using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;
using Wholegame.Core.Contracts.Services;
using MvvmCross.Core.ViewModels;
using Wholegame.Core.Model;
using MvvmCross.Platform.Platform;

namespace Wholegame.Core.ViewModel
{
	public class PlayerDetailViewModel : BaseViewModel
	{
		private IPlayerDataService _playerDataService;
		private IClubPlayerDataService _clubPlayerDataService;
		private IDialogService _dialogService;
		private int _playerId;
		private Player _selectedPlayer;
		public PlayerDetailViewModel(IMvxMessenger messenger, 
			IPlayerDataService playerDataService,
			IClubPlayerDataService clubPlayerDataService,
			IDialogService dialogService) : base(messenger)
		{
			_playerDataService = playerDataService;
			_clubPlayerDataService = clubPlayerDataService;
			_dialogService = dialogService;
		}
		public void Init(int playerId)
		{
			_playerId = playerId;
		}

		public MvxCommand AddPlayerToClubCommand
		{
			get
			{
				return new MvxCommand(async () =>
				{
					await _clubPlayerDataService.AddClubPlayer(1,SelectedPlayer.PlayerId);

					//Hardcoded text, better with resx translations
					await	_dialogService.ShowAlertAsync("This Player is added to the club!", "Wholegame says...", "OK");
					
					//await
					//	_dialogService.ShowAlertAsync
					//	(TextSource.GetText("AddedToSavedJourneysMessage"),
					//	 TextSource.GetText("AddedToSavedJourneysTitle"),
					//	 TextSource.GetText("AddedToSavedJourneysButton"));
				});
			}
		}

		public MvxCommand CloseCommand
		{ get { return new MvxCommand(() => Close(this)); } }

		public Player SelectedPlayer
		{
			get { return _selectedPlayer; }
			set
			{
				_selectedPlayer = value;
				RaisePropertyChanged(() => SelectedPlayer);
			}
		}

		public override async void Start()
		{
			base.Start();
			await ReloadDataAsync();
		}

		protected override async Task InitializeAsync()
		{
			SelectedPlayer = await _playerDataService.GetPlayerDetails(_playerId);
		}

		public class SavedState
		{
			public int PlayerId { get; set; }
		}

		public SavedState SaveState()
		{
			MvxTrace.Trace("SaveState called");
			return new SavedState { PlayerId = _playerId };
		}

		public void ReloadState(SavedState savedState)
		{
			MvxTrace.Trace("ReloadState called with {0}",
				savedState.PlayerId);
			_playerId = savedState.PlayerId;
		}

	}
}
