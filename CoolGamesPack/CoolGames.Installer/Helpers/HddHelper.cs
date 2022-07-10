using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using CoolGames.Installer.Helpers.Models;

namespace CoolGames.Installer.Helpers
{
	public class HddHelper : IHddHelper
	{
		private readonly IFileSystemHelper _fileSystemHelper;

		public HddHelper(IFileSystemHelper fileSystemHelper)
		{
			_fileSystemHelper = fileSystemHelper;
		}

		public List<Hdd> HddList { get; set; } = new List<Hdd>();
		public string DefaultHddName { get; set; }

		private IFileSystem _fileSystem;
		private IDriveInfoFactory _driveInfoFactory;
		private IDriveInfo[] _driveInfoCollection;

		public void InitializeListofHdds()
		{
			HddList = GetHddListFromDriveInfos();
		}

		public string SearchDefaultDrive()
		{
			List<Hdd> hdds = GetHddListFromDriveInfos();
			int hddCount = hdds.Count;
			int hddSize = hdds[0].FreeSpace;

			for (int i = 0; i < hddCount; i++)
			{
				if (hdds[i].FreeSpace > hddSize)
				{
					DefaultHddName = hdds[i].Name;
				}
			}

			return DefaultHddName;
		}

		private List<Hdd> GetHddListFromDriveInfos()
		{
			_driveInfoCollection = GetDriveInfosFromFileSystem();

			foreach (IDriveInfo drive in _driveInfoCollection)
			{
				Hdd hdd = new Hdd
				{
					Name = drive.Name,
					FreeSpace = Convert.ToInt32(drive.AvailableFreeSpace)
				};

				HddList.Add(hdd);
			}

			return HddList;
		}

		private IDriveInfo[] GetDriveInfosFromFileSystem()
		{
			_fileSystem = _fileSystemHelper.SystemInitialize();

			_driveInfoFactory = _fileSystem.DriveInfo;

			return _driveInfoFactory.GetDrives();
		}
	}
}