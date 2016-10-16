using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wholegame.Core.Contracts.Repositories;
using Wholegame.Core.Contracts.Services;
using Wholegame.Core.Model;

namespace Wholegame.Core.Services.Data
{
	public class PlayerDataService : IPlayerDataService
	{
		private readonly IPlayerRepository _playerRepository;
		public PlayerDataService(IPlayerRepository playerRepository)
		{
			_playerRepository = playerRepository;
		}
		public async Task<Player> GetPlayerDetails(int playerId)
		{
			return await _playerRepository.GetPlayerDetails(playerId);
		}

		public async Task<IEnumerable<Player>> SearchPlayers(string name)
		{
			var players = await _playerRepository.SearchPlayers(name);
			return players;
		}
	}
}
