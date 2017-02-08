﻿using System;
using SimpleDatabase;
using SQLite;
namespace MobileCenterApp
{
	public class Release
	{
		[PrimaryKey]
		public string Id { get; set; }

		public string Status { get; set; }

		[Indexed]
		public string AppId { get; set; }

		public string AppName { get; set; }

		public string Version { get; set; }

		[OrderBy]
		public string ShortVersion { get; set; }

		public string ReleaseNotes { get; set; }

		public string ProvisioningProfileName { get; set; }

		public double Size { get; set; }

		public string MinOs { get; set; }

		public string Fingerprint { get; set; }

		public string UploadedAt { get; set; }

		public string DownloadUrl { get; set; }

		public string AppIconUrl { get; set; }

		public string InstallUrl { get; set; }
	}
}
