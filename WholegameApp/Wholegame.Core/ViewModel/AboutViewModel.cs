using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;
using Wholegame.Core.Contracts.ViewModel;

namespace Wholegame.Core.ViewModel
{
	public class AboutViewModel : BaseViewModel, IAboutViewModel
	{
		private string _aboutContent;
		public AboutViewModel(IMvxMessenger messenger) : base(messenger)
		{
		}


		public string AboutContent
		{
			get { return _aboutContent; }
			set
			{
				_aboutContent = value;
				RaisePropertyChanged(() => AboutContent);
			}
		}


		public override async void Start()
		{
			base.Start();
			await ReloadDataAsync();
		}

		protected override Task InitializeAsync()
		{
			return Task.Run(() =>
			{
				AboutContent = "An awesome Wholegame app";// _settingsDataService.GetAboutContent();
			});
		}
	}
}
