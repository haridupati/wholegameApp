﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Wholegame.Core.Repositories
{
	public class BaseRepository
	{
		private HttpClient CreateHttpClient()
		{
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return httpClient;
		}

		protected async Task<T> GetAsync<T>(string url)
			where T : new()
		{
			HttpClient httpClient = CreateHttpClient();
			T result;

			try
			{
				var response = await httpClient.GetStringAsync(url);
				result = await Task.Run(() => JsonConvert.DeserializeObject<T>(response));
			}
			catch
			{
				result = new T();
			}

			return result;
		}
	}
}
