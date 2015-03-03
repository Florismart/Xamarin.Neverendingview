using System;
using Florismart.Neverendingview.Droid.Views;
using Android.OS;
using Florismart.Neverendingview.Droid.Core.Entity;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Timers;

namespace Florismart.Neverendingview.Droid.Core
{
	public class NeverendingScrollController
	{
		private INeverendingScrolllable neverendingScrollable;
		private NeverendingModes _mode;
		private bool enabled;
		private System.Timers.Timer timer;

		public NeverendingModes Mode {
			get { 
				return _mode;
			}
			set {
				if (_mode != value) {
					_mode = value;
					if (NeverendingModes.Natural.Equals (_mode))
						neverendingScrollable.ScrollBaseNaturalPosition ();
					else
						neverendingScrollable.ScrollBaseInnaturalPosition ();
				}
			}
		}

		public NeverendingLopeEntity LopeEntity;

		public bool IsScrolling {
			get { 
				return enabled;
			}
		}

		public NeverendingScrollController (bool enabled, NeverendingModes mode, INeverendingScrolllable neverendingScrollable,
		                                    NeverendingLopeEntity lopeEntity)
		{
			this.enabled = enabled;
			this._mode = mode;
			this.neverendingScrollable = neverendingScrollable;
			this.LopeEntity = lopeEntity;

			timer = new System.Timers.Timer ();
			timer.Interval = LopeEntity.Frequency;
			timer.Elapsed += new ElapsedEventHandler (Scroll);
		}

		protected void Scroll (object sender, ElapsedEventArgs e)
		{
			neverendingScrollable.Scroll (LopeEntity.Delta, getDirection ());
		}

		/// <summary>
		/// Start the Neverendingscrolling.
		/// </summary>
		public NeverendingScrollController Start ()
		{
			enabled = true;
			timer.Start ();
			return this;
		}

		/// <summary>
		/// Stop the Neverendingscrolling.
		/// </summary>
		public NeverendingScrollController Stop ()
		{
			enabled = false;
			timer.Stop ();
			return this;
		}

		/// <summary>
		/// OnLimitReached event. Stops Neverendingscrolling and resume from base position.
		/// </summary>
		public void OnLimitReached ()
		{
			if (NeverendingModes.Natural.Equals (Mode))
				neverendingScrollable.ScrollBaseNaturalPosition ();
			else
				neverendingScrollable.ScrollBaseInnaturalPosition ();

		}

		private int getDirection ()
		{
			return NeverendingModes.Natural.Equals (Mode) ? 1 : -1;
		}
	}
}

