using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;
using System.Collections.ObjectModel;
using Wholegame.Core.Model;
using Wholegame.Core.Extensions;
using MvvmCross.Core.ViewModels;
using Wholegame.Core.Model.App;
using Wholegame.Core.Contracts.Services;

namespace Wholegame.Core.ViewModel
{
	public class SearchResultViewModel : BaseViewModel
	{
		private IPlayerDataService _playerDataService;
		private string _playerName;
		public SearchResultViewModel(IMvxMessenger messenger, IPlayerDataService playerDataService) : base(messenger)
		{
			_playerDataService = playerDataService;
		}
		private ObservableCollection<Player> _players;

		public ObservableCollection<Player> Players
		{
			get { return _players; }
			set
			{
				_players = value;
				RaisePropertyChanged(() => Players);
			}
		}

		public MvxCommand<Player> ShowPlayerDetailsCommand
		{
			get
			{
				return new MvxCommand<Player>(selectedPlayer =>
				{
					ShowViewModel<PlayerDetailViewModel>
					(new { playerId = selectedPlayer.PlayerId });
				});
			}
		}


		public override async void Start()
		{
			base.Start();

			await ReloadDataAsync();
		}

		protected override async Task InitializeAsync()
		{
			Players = (await _playerDataService.SearchPlayers(_playerName)).ToObservableCollection();
		}



		public void Init(SearchParameters parameters)
		{
			_playerName = parameters.PlayerName;			
		}
	}
}
