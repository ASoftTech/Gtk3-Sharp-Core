// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gtk {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.GType (typeof (Gtk.PrintPagesGType))]
	public enum PrintPages {

		All,
		Current,
		Ranges,
		Selection,
	}

	internal class PrintPagesGType {
		[DllImport ("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_print_pages_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (gtk_print_pages_get_type ());
			}
		}
	}
#endregion
}
