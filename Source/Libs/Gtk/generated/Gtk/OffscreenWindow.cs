// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gtk {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class OffscreenWindow : Gtk.Window {

		public OffscreenWindow (IntPtr raw) : base(raw) {}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_offscreen_window_new();

		public OffscreenWindow () : base (IntPtr.Zero)
		{
			if (GetType () != typeof (OffscreenWindow)) {
				CreateNativeObject (new string [0], new GLib.Value[0]);
				return;
			}
			Raw = gtk_offscreen_window_new();
		}

		[StructLayout (LayoutKind.Sequential)]
		struct GtkOffscreenWindowClass {
			IntPtr GtkReserved1;
			IntPtr GtkReserved2;
			IntPtr GtkReserved3;
			IntPtr GtkReserved4;
		}

		static uint class_offset = ((GLib.GType) typeof (Gtk.Window)).GetClassSize ();
		static Dictionary<GLib.GType, GtkOffscreenWindowClass> class_structs;

		static GtkOffscreenWindowClass GetClassStruct (GLib.GType gtype, bool use_cache)
		{
			if (class_structs == null)
				class_structs = new Dictionary<GLib.GType, GtkOffscreenWindowClass> ();

			if (use_cache && class_structs.ContainsKey (gtype))
				return class_structs [gtype];
			else {
				IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
				GtkOffscreenWindowClass class_struct = (GtkOffscreenWindowClass) Marshal.PtrToStructure (class_ptr, typeof (GtkOffscreenWindowClass));
				if (use_cache)
					class_structs.Add (gtype, class_struct);
				return class_struct;
			}
		}

		static void OverrideClassStruct (GLib.GType gtype, GtkOffscreenWindowClass class_struct)
		{
			IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
			Marshal.StructureToPtr (class_struct, class_ptr, false);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_offscreen_window_get_pixbuf(IntPtr raw);

		public Gdk.Pixbuf Pixbuf { 
			get {
				IntPtr raw_ret = gtk_offscreen_window_get_pixbuf(Handle);
				Gdk.Pixbuf ret = GLib.Object.GetObject(raw_ret) as Gdk.Pixbuf;
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_offscreen_window_get_surface(IntPtr raw);

		public Cairo.Surface Surface { 
			get {
				IntPtr raw_ret = gtk_offscreen_window_get_surface(Handle);
				Cairo.Surface ret = Cairo.Surface.Lookup (raw_ret, true);
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_offscreen_window_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gtk_offscreen_window_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
	}
}
