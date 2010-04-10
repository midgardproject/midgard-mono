/* Run storage example, so proper storage is created for class given in this example */

using System;
using Midgard;

namespace MidgardSample
{
	public class ObjectSample
	{
		public static void Main (string[] args)
		{
			Midgard.Lib.Init ();

			// Create midgard config connection
			Config cfg = new Config ();
			cfg.DatabaseType = "SQLite";
			cfg.DatabaseName = "midgard_mono_sample";

			Connection mgd = new Connection ();
			if (!mgd.OpenConfig (cfg)) {
				Console.WriteLine ("Connection failed!");
				return;
			}

			GLib.Value val = new GLib.Value("");
			Midgard.Object john = new Midgard.Object (mgd, "midgard_person", val);
			GLib.Value name = new GLib.Value ("John");
			john.SetSchemaProperty ("username", name);

			if (!john.Create()) {
				Console.WriteLine ("Couldn't create person object. %s", mgd.ErrorString);
			}
			else {
				GLib.Value gval = john.GetSchemaProperty ("guid");
				Console.Write ("Created new person object." + (string)gval.Val.ToString() + "\n");
			}

			val = new GLib.Value("");
			Midgard.Object alice = new Midgard.Object (mgd, "midgard_person", val);
			name = new GLib.Value ("Alice");
			alice.SetSchemaProperty ("username", name);

			if (!alice.Create()) {
				Console.WriteLine ("Couldn't create person object. %s", mgd.ErrorString);
			}
			else {
				GLib.Value gval = alice.GetSchemaProperty ("guid");
				Console.Write ("Created new person object." + (string)gval.Val + "\n");
			}

			Console.WriteLine (john);
		}
	}
}
