using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wholegame.Core.Model
{
	public class ClubPlayer : BaseModel
	{
		public int ClubId { get; set; }
		public int PlayerId { get; set;}
		public Player Player { get; set; }
	}
}
