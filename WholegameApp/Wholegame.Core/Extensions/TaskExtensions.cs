﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wholegame.Core.Extensions
{
	public static class TaskExtensions
	{
		public static void Forget(this Task task)
		{
			task.ConfigureAwait(false);
		}
	}
}
