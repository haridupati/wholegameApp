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
	public class ClubPlayerDataService : IClubPlayerDataService
	{
		private readonly IClubPlayerRepository _clubPlayerRepository;
		private readonly IPlayerRepository _playerRepository;
		public ClubPlayerDataService(IClubPlayerRepository clubPlayerRepository, IPlayerRepository playerRepository)
		{
			_clubPlayerRepository = clubPlayerRepository;
			_playerRepository = playerRepository;
		}
		public async Task AddClubPlayer(int clubId, int playerId)
		{
			await _clubPlayerRepository.AddClubPlayer(clubId,playerId);
		}

		public async Task<IEnumerable<ClubPlayer>> GetClubPlayers(int clubId)
		{
			var list = await _clubPlayerRepository.GetClubPlayers(clubId);
			foreach (var clubPlayer in list)
			{
				var player = await _playerRepository.GetPlayerDetails(clubPlayer.PlayerId);
				clubPlayer.Player = player;
			}

			return list;
		}
	}
}
