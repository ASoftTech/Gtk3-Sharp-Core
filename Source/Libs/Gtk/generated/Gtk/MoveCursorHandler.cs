// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gtk {

	using System;

	public delegate void MoveCursorHandler(object o, MoveCursorArgs args);

	public class MoveCursorArgs : GLib.SignalArgs {
		public Gtk.MovementStep Step{
			get {
				return (Gtk.MovementStep) Args [0];
			}
		}

		public int Count{
			get {
				return (int) Args [1];
			}
		}

	}
}
