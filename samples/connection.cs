using System;
using Midgard;

namespace MidgardSample
{
	public class ConnectionSample
	{
		public static void Main (string[] args)
		{
			Context.Init ();

			// Create midgard config connection
			Config cfg = new Config ();
			cfg.DatabaseType = "SQLite";
			cfg.DatabaseName = "midgard";

			Connection conn = new Connection ();
			if (!conn.OpenConfig (cfg)) {
				Console.WriteLine ("Connection failed!");
				return;
			}
			
			Console.WriteLine ("Connection established!");
		}
	}
}
