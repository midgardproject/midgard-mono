using System;
using Midgard;

namespace MidgardSample
{
	public class StorageSample
	{
		public static void Main (string[] args)
		{
			Lib.Init ();

			// Create midgard config connection
			Config cfg = new Config ();
			cfg.DatabaseType = "SQLite";
			cfg.DatabaseName = "midgard_mono_sample";

			Connection mgd = new Connection ();
			if (!mgd.OpenConfig (cfg)) {
				Console.WriteLine ("Connection failed!");
				return;
			}

			/* Create base storage if it doesn't exist */
			if (Midgard.Storage.CreateBaseStorage(mgd))
				Console.WriteLine ("Base Midgard storage created");
			
			/* Create midgard_person storage if it doesn't exist */
			if (Midgard.Storage.Exists (mgd, "midgard_person")) {
				Console.WriteLine ("Storage for midgard_person class exists");
			}
			else {
				if (Midgard.Storage.Create (mgd, "midgard_person"))
					Console.WriteLine ("Created new storage for midgard_person class");
				else 
					Console.WriteLine ("Failed to create storage for midgard_person class");
			}
		}
	}
}
