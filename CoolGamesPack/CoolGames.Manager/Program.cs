using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolGames.Manager.Startup;

namespace CoolGames.Manager
{
	class Program
	{
		static void Main(string[] args)
		{
			Initializer.Load();
		}
	}
}
