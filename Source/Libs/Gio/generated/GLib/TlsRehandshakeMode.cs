// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace GLib {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.GType (typeof (GLib.TlsRehandshakeModeGType))]
	public enum TlsRehandshakeMode {

		Never,
		Safely,
		Unsafely,
	}

	internal class TlsRehandshakeModeGType {
		[DllImport ("libgio-2.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr g_tls_rehandshake_mode_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (g_tls_rehandshake_mode_get_type ());
			}
		}
	}
#endregion
}