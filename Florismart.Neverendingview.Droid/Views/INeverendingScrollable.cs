using System;

namespace Florismart.Neverendingview.Droid.Views
{
	public interface INeverendingScrolllable
	{

		/**
		*
		* @param delta
		* @param direction
		*/
		void Scroll (int delta, int direction);

		/**
		* Scroll view in base Natural position: if Horizontal will scroll to (0,0)
		* - if Vertical will scroll to (0,0).
		*/
		void ScrollBaseNaturalPosition ();

		/**
		* Scroll view in base Innatural position: if Horizontal will scroll to
		* (max_x,0) - if Vertical will scroll to (0,max_y).
		*/
		void ScrollBaseInnaturalPosition ();
	}
}

