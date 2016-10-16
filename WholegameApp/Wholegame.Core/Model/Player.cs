using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wholegame.Core.Model
{
	public class Player : BaseModel
	{
		public int PlayerId { get; set; }
		public string PlayerName { get; set; }
		public int Age { get; set; }
	}
}
