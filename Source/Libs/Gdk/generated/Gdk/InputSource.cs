// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gdk {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.GType (typeof (Gdk.InputSourceGType))]
	public enum InputSource {

		Mouse,
		Pen,
		Eraser,
		Cursor,
		Keyboard,
		Touchscreen,
		Touchpad,
		Trackpoint,
		TabletPad,
	}

	internal class InputSourceGType {
		[DllImport ("libgdk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gdk_input_source_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (gdk_input_source_get_type ());
			}
		}
	}
#endregion
}