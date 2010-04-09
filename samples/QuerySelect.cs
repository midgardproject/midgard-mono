/* Run storage and objects examples first. */

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

			Midgard.QueryStorage storage = new Midgard.QueryStorage ("midgard_person");
			Midgard.QuerySelect select = new Midgard.QuerySelect (mgd, storage);
			
			Midgard.QueryProperty prop = new Midgard.QueryProperty ("name", null);
			GLib.Value value = new GLib.Value ("John");
			Midgard.QueryValue val = new Midgard.QueryValue (value);
			Midgard.QueryConstraint cnstr = new Midgard.QueryConstraint (prop, "=", val, storage);

			Midgard.QueryProperty prop2 = new Midgard.QueryProperty ("name", null);
			value = new GLib.Value ("Alice");
			Midgard.QueryValue val2 = new Midgard.QueryValue (value);
			Midgard.QueryConstraint cnstr2 = new Midgard.QueryConstraint (prop2, "=", val, null);

			//Midgard.QueryGroupConstraint group_constraint = new Midgard.QueryGroupConstraint ("OR", cnstr, cnstr2);

			//select.SetConstraint (cnstr);
			select.Execute();

			uint nobjects;
			Midgard.DBObject objects = select.ListObjects(out nobjects);
		}

	}
}
