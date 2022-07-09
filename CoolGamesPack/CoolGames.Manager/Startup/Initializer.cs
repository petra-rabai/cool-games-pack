using System.Diagnostics;

namespace CoolGames.Manager.Startup
{
	public static class Initializer
	{
		public static string Root { get; set; } 

		public static void Load()
		{
			Root = Configure();
			Process.Start(Root);
		}

		private static string Configure()
		{
			string installationRoute = "";
			string mainUrl = "";

			return installationRoute + mainUrl;
		}


	}
}