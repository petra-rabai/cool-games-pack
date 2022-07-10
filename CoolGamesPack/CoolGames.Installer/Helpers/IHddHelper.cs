using System.Collections.Generic;
using CoolGames.Installer.Helpers.Models;

namespace CoolGames.Installer.Helpers
{
	public interface IHddHelper
	{
		List<Hdd> HddList { get; set; }
		string DefaultHddName { get; set; }
		void InitializeListofHdds();
		string SearchDefaultDrive();
	}
}