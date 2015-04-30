using System;
using Android.Widget;
using Android.Content;
using Android.Util;
using Florismart.Neverendingview.Droid.Core;
using Android.Content.Res;
using Florismart.Neverendingview.Droid.Core.Entity;
using Android.App;
using Android.Views;

namespace Florismart.Neverendingview.Droid.Views
{
	public class VerticalNeverendingView : ScrollView, INeverendingScrolllable
	{
		private NeverendingScrollController controller;
		public EventHandler ScrollLimitReached;

		private bool DEFAULT_ENABLED = true;
		private NeverendingModes DEFAULT_MODE = NeverendingModes.Natural;

		public VerticalNeverendingView (Context context) : base (context)
		{
		}

		public VerticalNeverendingView (Context context, IAttributeSet attrs) : base (context, attrs)
		{
			initAttributes (context, attrs);
		}

		public VerticalNeverendingView (Context context, IAttributeSet attrs, int defStyle) : base (context, attrs, defStyle)
		{
			initAttributes (context, attrs);
		}

		protected virtual void initAttributes (Context context, IAttributeSet attrs)
		{
			var enabled = DEFAULT_ENABLED;
			var mode = DEFAULT_MODE;
			if (attrs != null) {
				TypedArray a = context.ObtainStyledAttributes (attrs, Resource.Styleable.Neverender);
				enabled = a.GetBoolean (Resource.Styleable.Neverender_enabled, DEFAULT_ENABLED);
				int modeIndex = a.GetInteger (Resource.Styleable.Neverender_mode, 0);
				mode = (NeverendingModes)modeIndex;
				var frequency = a.GetInteger (Resource.Styleable.Neverender_frequency, 10);
				var delta = a.GetInteger (Resource.Styleable.Neverender_delta, 1);
				var speed = a.GetInteger (Resource.Styleable.Neverender_speed, -1);
				controller = new NeverendingScrollController (enabled, mode, this, getLope (speed, delta, frequency));
				a.Recycle ();
			} else {
				controller = new NeverendingScrollController (DEFAULT_ENABLED, DEFAULT_MODE, this, NeverendingLoader.GetIstance ().DefaultConfig);
			}
			if (enabled)
				controller.Start ();
		}

		private NeverendingLopeEntity getLope (int speed, int delta, int frequency)
		{
			var lopeEntity = NeverendingLoader.GetIstance ().DefaultConfig;
			if (speed != -1) {
				lopeEntity = NeverendingLoader.GetIstance ().GetConfiguration ((NeverendingSpeeds)speed);
			} else {
				lopeEntity = new NeverendingLopeEntity (delta, frequency);
			}
			return lopeEntity;
		}

		public void Scroll (int delta, int direction)
		{
			ScrollBy (0, delta * direction);
		}

		public override bool OnTouchEvent (MotionEvent _event)
		{
			switch (_event.Action) {
			case MotionEventActions.Down:
				return false;
			default:
				return base.OnTouchEvent (_event);
			}
		}

		public override bool OnInterceptTouchEvent (MotionEvent ev)
		{
			return false;
		}

		protected override void OnScrollChanged (int x, int y, int oldX, int oldY)
		{
			base.OnScrollChanged (x, y, oldX, oldY);

			if (NeverendingModes.Natural.Equals (controller.Mode)) {
				if (y + Height >= GetChildAt (0).Height)
					onLimitReached ();
			} else {
				if (y <= 0)
					onLimitReached ();
			}
		}

		protected void onLimitReached ()
		{
			if (ScrollLimitReached != null)
				ScrollLimitReached (this, new EventArgs ());
			controller.OnLimitReached ();
		}

		public NeverendingScrollController GetController ()
		{
			return controller;
		}

		public void SetController (NeverendingScrollController controller)
		{
			this.controller = controller;
		}

		public void ScrollBaseNaturalPosition ()
		{
			ScrollTo (0, 0);
		}

		public void ScrollBaseInnaturalPosition ()
		{
			ScrollTo (0, GetChildAt (0).Height);
		}

	}
}

