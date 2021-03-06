// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gtk {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class SizeGroup : GLib.Object {

		public SizeGroup (IntPtr raw) : base(raw) {}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_size_group_new(int mode);

		public SizeGroup (Gtk.SizeGroupMode mode) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (SizeGroup)) {
				var vals = new List<GLib.Value> ();
				var names = new List<string> ();
				names.Add ("mode");
				vals.Add (new GLib.Value (mode));
				CreateNativeObject (names.ToArray (), vals.ToArray ());
				return;
			}
			Raw = gtk_size_group_new((int) mode);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gtk_size_group_get_mode(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_size_group_set_mode(IntPtr raw, int mode);

		[GLib.Property ("mode")]
		public Gtk.SizeGroupMode Mode {
			get  {
				int raw_ret = gtk_size_group_get_mode(Handle);
				Gtk.SizeGroupMode ret = (Gtk.SizeGroupMode) raw_ret;
				return ret;
			}
			set  {
				gtk_size_group_set_mode(Handle, (int) value);
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gtk_size_group_get_ignore_hidden(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_size_group_set_ignore_hidden(IntPtr raw, bool ignore_hidden);

		[Obsolete]
		[GLib.Property ("ignore-hidden")]
		public bool IgnoreHidden {
			get  {
				bool raw_ret = gtk_size_group_get_ignore_hidden(Handle);
				bool ret = raw_ret;
				return ret;
			}
			set  {
				gtk_size_group_set_ignore_hidden(Handle, value);
			}
		}

		[StructLayout (LayoutKind.Sequential)]
		struct GtkSizeGroupClass {
			IntPtr GtkReserved1;
			IntPtr GtkReserved2;
			IntPtr GtkReserved3;
			IntPtr GtkReserved4;
		}

		static uint class_offset = ((GLib.GType) typeof (GLib.Object)).GetClassSize ();
		static Dictionary<GLib.GType, GtkSizeGroupClass> class_structs;

		static GtkSizeGroupClass GetClassStruct (GLib.GType gtype, bool use_cache)
		{
			if (class_structs == null)
				class_structs = new Dictionary<GLib.GType, GtkSizeGroupClass> ();

			if (use_cache && class_structs.ContainsKey (gtype))
				return class_structs [gtype];
			else {
				IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
				GtkSizeGroupClass class_struct = (GtkSizeGroupClass) Marshal.PtrToStructure (class_ptr, typeof (GtkSizeGroupClass));
				if (use_cache)
					class_structs.Add (gtype, class_struct);
				return class_struct;
			}
		}

		static void OverrideClassStruct (GLib.GType gtype, GtkSizeGroupClass class_struct)
		{
			IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
			Marshal.StructureToPtr (class_struct, class_ptr, false);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_size_group_add_widget(IntPtr raw, IntPtr widget);

		public void AddWidget(Gtk.Widget widget) {
			gtk_size_group_add_widget(Handle, widget == null ? IntPtr.Zero : widget.Handle);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_size_group_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gtk_size_group_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_size_group_get_widgets(IntPtr raw);

		public Gtk.Widget[] Widgets { 
			get {
				IntPtr raw_ret = gtk_size_group_get_widgets(Handle);
				Gtk.Widget[] ret = (Gtk.Widget[]) GLib.Marshaller.ListPtrToArray (raw_ret, typeof(GLib.SList), false, false, typeof(Gtk.Widget));
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_size_group_remove_widget(IntPtr raw, IntPtr widget);

		public void RemoveWidget(Gtk.Widget widget) {
			gtk_size_group_remove_widget(Handle, widget == null ? IntPtr.Zero : widget.Handle);
		}

#endregion
	}
}
