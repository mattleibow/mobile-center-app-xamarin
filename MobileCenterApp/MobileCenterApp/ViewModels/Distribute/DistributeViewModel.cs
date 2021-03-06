﻿using System;
using System.Threading.Tasks;

namespace MobileCenterApp
{
	public class DistributeViewModel : BaseViewModel
	{
		public DistributeViewModel()
		{
			Title = "Releases";
			Icon = Images.DistributePageIcon;
		}

		SimpleDatabaseSource<Release> items = new SimpleDatabaseSource<Release>(Database.Main) { IsGrouped = false};
		public SimpleDatabaseSource<Release> Items
		{
			get { return items; }
			set { ProcPropertyChanged(ref items, value); }
		}
		public AppClass CurrentApp { get; set; }

		public override async Task OnRefresh()
		{
			var currentId = Settings.CurrentAppId;
			if (string.IsNullOrWhiteSpace(currentId))
				return;
			CurrentApp = Database.Main.GetObject<AppClass>(currentId);
			SetGroupInfo();
			await SyncManager.Shared.SyncReleases(CurrentApp);
			Items.ResfreshData();
		}

		void SetGroupInfo()
		{
			var groupInfo = Database.Main.GetGroupInfo<Release>().Clone();
			groupInfo.OrderByDesc = true;
			groupInfo.Filter = "AppId = @AppId";
			groupInfo.Params["@AppId"] = CurrentApp?.Id;
			Items.GroupInfo = groupInfo;
		}

		public async void OnSelected(Release release)
		{
			if (release == null)
				return;
			await NavigationService.PushAsync(new ReleaseDetailsViewModel { Release = release });
		}
	}
}
