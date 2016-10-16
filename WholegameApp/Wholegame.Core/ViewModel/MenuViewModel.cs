using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wholegame.Core.Model.App;
using Wholegame.Core.Utility;

namespace Wholegame.Core.ViewModel
{
	public class MenuViewModel : BaseViewModel
	{
		public MvxCommand<MenuItem> MenuItemSelectCommand => new MvxCommand<MenuItem>(OnMenuEntrySelect);
		public ObservableCollection<MenuItem> MenuItems { get; }

		public event EventHandler CloseMenu;

		public MenuViewModel(IMvxMessenger messenger) : base(messenger)
		{
			MenuItems = new ObservableCollection<MenuItem>();
			CreateMenuItems();
		}

		private void CreateMenuItems()
		{
			MenuItems.Add(new MenuItem
			{
				Title = "Club Players",
				ViewModelType = typeof(ClubPlayersViewModel),
				Option = MenuOption.ClubPlayers,
				IsSelected = true
			});

			MenuItems.Add(new MenuItem
			{
				Title = "Search Players",
				ViewModelType = typeof(SearchPlayerViewModel),
				Option = MenuOption.SearchPlayers,
				IsSelected = false
			});

			MenuItems.Add(new MenuItem
			{
				Title = "About",
				ViewModelType = typeof(AboutViewModel),
				Option = MenuOption.About,
				IsSelected = false
			});
		}

		private void OnMenuEntrySelect(MenuItem item)
		{
			ShowViewModel(item.ViewModelType);
			RaiseCloseMenu();
		}

		private void RaiseCloseMenu()
		{
			CloseMenu?.Invoke(this, EventArgs.Empty);
		}
	}
}
