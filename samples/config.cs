using System;
using Midgard;

namespace MidgardSample
{
	public class ConfigSample
	{
		public static void Main (string[] args)
		{
			// Initialize midgard
			Midgard.Context.Init ();

			// Create midgard config connection
			Midgard.Config cfg = new Midgard.Config ();
			cfg.DatabaseType = "SQLite";
			cfg.DatabaseName = "midgard";
			cfg.SaveFile ("monotest", true);

			// Show config properties
			Console.WriteLine ("Creating Midgard config...");
			Console.WriteLine ("> DatabaseType={0}", cfg.DatabaseType);
			Console.WriteLine ("> DatabaseName={0}", cfg.DatabaseName);
			Console.WriteLine ("");

			// Read config file to check values
			Midgard.Config chkcfg = new Midgard.Config ();
			chkcfg.ReadFile ("monotest", true);

			// Show loaded values
			Console.WriteLine ("Checking config...");
			Console.WriteLine ("> DatabaseType={0}", chkcfg.DatabaseType);
			Console.WriteLine ("> DatabaseName={0}", chkcfg.DatabaseName);
			Console.WriteLine ("");

			// Try to connect
			Connection conn = new Midgard.Connection ();
			if (!conn.OpenConfig (chkcfg))
				Console.WriteLine ("Connection failed!");
			else
				Console.WriteLine ("Connection established!");
		}
	}
}
