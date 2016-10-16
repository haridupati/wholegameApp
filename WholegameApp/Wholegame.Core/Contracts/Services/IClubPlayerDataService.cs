using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wholegame.Core.Model;

namespace Wholegame.Core.Contracts.Services
{
	public interface IClubPlayerDataService
	{
		Task<IEnumerable<ClubPlayer>> GetClubPlayers(int clubId);

		Task AddClubPlayer(int clubId, int playerId);
	}
}
