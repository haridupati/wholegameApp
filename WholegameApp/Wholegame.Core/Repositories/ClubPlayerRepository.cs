using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wholegame.Core.Contracts.Repositories;
using Wholegame.Core.Model;

namespace Wholegame.Core.Repositories
{
	public class ClubPlayerRepository : IClubPlayerRepository
	{
		private static readonly List<ClubPlayer> AllClubPlayers = new List<ClubPlayer>
		{
			new ClubPlayer {ClubId = 1, PlayerId = 1},
			new ClubPlayer {ClubId = 1, PlayerId = 2},
			new ClubPlayer {ClubId = 1, PlayerId = 3},
		};

		public async Task AddClubPlayer(int clubId, int playerId)
		{
			await
			   Task.Run(
				   () =>
					   AllClubPlayers.Add(new ClubPlayer
					   {
						   ClubId = clubId,
						   PlayerId = playerId						   
					   }));
		}

		public async Task<IEnumerable<ClubPlayer>> GetClubPlayers(int clubId)
		{
			return await Task.FromResult(AllClubPlayers.Where(j => j.ClubId == clubId));
		}
	}
}
