// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gtk {

	using System;

	public delegate void ChildAttachedHandler(object o, ChildAttachedArgs args);

	public class ChildAttachedArgs : GLib.SignalArgs {
		public Gtk.Widget Child{
			get {
				return (Gtk.Widget) Args [0];
			}
		}

	}
}
