using System;
using System.Collections.Generic;
using Florismart.Neverendingview.Droid.Core.Entity;

namespace Florismart.Neverendingview.Droid.Core
{
	public class NeverendingLoader
	{
		private static NeverendingLoader istance = null;
		private Dictionary<NeverendingSpeeds, NeverendingLopeEntity> configs;
		public NeverendingLopeEntity DefaultConfig;

		private NeverendingLoader ()
		{
			configs = new Dictionary<NeverendingSpeeds, NeverendingLopeEntity> ();

			configs.Add (NeverendingSpeeds.Falcon, new NeverendingLopeEntity (5, 20));
			configs.Add (NeverendingSpeeds.Mork, new NeverendingLopeEntity (2, 10));
			configs.Add (NeverendingSpeeds.Rockbiter, new NeverendingLopeEntity (1, 10));
			configs.Add (NeverendingSpeeds.Morla, new NeverendingLopeEntity (1, 15));

			DefaultConfig = new NeverendingLopeEntity (5, 20);
		}

		public static NeverendingLoader GetIstance ()
		{
			if (istance == null)
				istance = new NeverendingLoader ();
			return istance;
		}

		public NeverendingLoader Init (Dictionary<NeverendingSpeeds, NeverendingLopeEntity> configs)
		{
			this.configs = configs;
			return this;
		}

		public NeverendingLopeEntity GetConfiguration (NeverendingSpeeds speed)
		{
			return configs.ContainsKey (speed) ? configs [speed] : DefaultConfig;
		}

	}
}
