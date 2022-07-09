using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using CoolGames.Installer.Helpers.Models;

namespace CoolGames.Installer.Helpers
{
	public class HddHelper
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

		public List<Hdd> GetHddListFromDriveInfos()
		{
			_driveInfoCollection = GetDriveInfosFromFileSystem();

			foreach (IDriveInfo drive in _driveInfoCollection)
			{
				Hdd hdd = new Hdd();
				hdd.Name = drive.Name;
				hdd.FreeSpace = Convert.ToInt32(drive.AvailableFreeSpace);
				
				HddList.Add(hdd);
			}

			return HddList;
		}

		public string SearchDefaultDrive()
		{
			List<Hdd> _hdds = GetHddListFromDriveInfos();
			int hddCount = _hdds.Count;
			int hddSize = _hdds[0].FreeSpace;

			for (int i = 0; i < hddCount; i++)
			{
				if (_hdds[i].FreeSpace > hddSize)
				{
					DefaultHddName = _hdds[i].Name;
				}
			}

			return DefaultHddName;
		}

		private IDriveInfo[] GetDriveInfosFromFileSystem()
		{
			_fileSystem = _fileSystemHelper.SystemInitialize();

			_driveInfoFactory = _fileSystem.DriveInfo;

			return _driveInfoFactory.GetDrives();
		}
	}
}