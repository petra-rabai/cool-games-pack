using System.IO.Abstractions;

namespace CoolGames.Installer.Helpers
{
	public class FileSystemHelper : IFileSystemHelper
	{
		
		public IFileSystem SystemInitialize()
		{
			return new FileSystem();
		}
	}
}