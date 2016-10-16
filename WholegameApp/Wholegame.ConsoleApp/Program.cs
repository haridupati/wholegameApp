using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wholegame.Core.Repositories;
using Wholegame.Core.Services.Data;

namespace Wholegame.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			PlayerDataService playerDataService = new PlayerDataService(new PlayerRepository());
			var players = playerDataService.SearchPlayers("Ian").Result;

			ClubPlayerDataService clubPlayerDataService = new ClubPlayerDataService(new ClubPlayerRepository(),new PlayerRepository());
			var clubPlayers = clubPlayerDataService.GetClubPlayers(1).Result;

			Console.WriteLine(clubPlayers.Count());

			Console.ReadLine();


		}
	}
}
