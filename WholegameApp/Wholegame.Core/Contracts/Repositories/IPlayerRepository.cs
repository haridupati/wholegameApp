using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wholegame.Core.Model;

namespace Wholegame.Core.Contracts.Repositories
{
	public interface IPlayerRepository
	{
		Task<IEnumerable<Player>> SearchPlayers(string name);

		Task<Player> GetPlayerDetails(int playerId);
	}
}
