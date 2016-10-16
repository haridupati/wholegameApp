using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wholegame.Core.Contracts.Repositories;
using Wholegame.Core.Model;

namespace Wholegame.Core.Repositories
{
	public class PlayerRepository : IPlayerRepository
	{
		private static readonly List<Player> AllPlayers = new List<Player>
		{
			new Player
			{
				PlayerId = 1,
				PlayerName = "Ashley",
				Age=37
			},
			new Player
			{
				PlayerId = 2,
				PlayerName = "Bravo",
				Age = 25
			},
			new Player
			{
				PlayerId = 3,
				PlayerName = "Charlie",
				Age = 26
			},
			 new Player
			{
				PlayerId = 4,
				PlayerName = "Donald",
				 Age = 26
			},

			 new Player
			{
				PlayerId = 5,
				PlayerName = "Eduard",
				Age = 24
			},

			 new Player
			{
				PlayerId = 6,
				PlayerName = "Faizal",
				Age = 15
			},
			 new Player
			 {
				PlayerId = 7,
				PlayerName = "Hari",
				Age = 33
			},
			  new Player
			 {
				PlayerId = 8,
				PlayerName = "Hari Dupati",
				Age = 45
			},
			 new Player
			 {
				PlayerId = 9,
				PlayerName = "Ian",
				Age = 29
			},
			 new Player
			 {
				PlayerId = 10,
				PlayerName = "Ian Smith",
				Age = 32
			}
		};

		public async Task<Player> GetPlayerDetails(int playerId)
		{
			return await Task.FromResult(AllPlayers.FirstOrDefault(c => c.PlayerId == playerId));
		}

		public async Task<IEnumerable<Player>> SearchPlayers(string name)
		{
			return await Task.FromResult(AllPlayers.Where(c => c.PlayerName.Contains(name)));
		}
	}
}
