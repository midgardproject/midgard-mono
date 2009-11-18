using System;
using GLib;
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

			// Try to connect
			Connection conn = new Midgard.Connection ();
			if (!conn.OpenConfig (cfg)) {
				Console.WriteLine ("Connection failed");
				return;
			}
			Console.WriteLine ("Connection established");

			// Create midgard tables
			if (!cfg.CreateMidgardTables (conn)) {
				Console.WriteLine ("Tables initialization failed");
				return;
			}
			Console.WriteLine ("Tables sucefully created");

			Midgard.Object person = new Midgard.Object (conn, "person", new GLib.Value (1));
			Console.WriteLine (">> {0}", person);
		}
	}
}
