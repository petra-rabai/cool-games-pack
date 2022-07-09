using System.IO.Abstractions;

namespace CoolGames.Installer.Helpers
{
	public interface IFileSystemHelper
	{
		IFileSystem SystemInitialize();
	}
}