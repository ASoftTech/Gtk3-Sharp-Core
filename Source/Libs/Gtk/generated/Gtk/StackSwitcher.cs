// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gtk {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class StackSwitcher : Gtk.Box {

		public StackSwitcher (IntPtr raw) : base(raw) {}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_stack_switcher_new();

		public StackSwitcher () : base (IntPtr.Zero)
		{
			if (GetType () != typeof (StackSwitcher)) {
				CreateNativeObject (new string [0], new GLib.Value[0]);
				return;
			}
			Raw = gtk_stack_switcher_new();
		}

		[GLib.Property ("icon-size")]
		public int IconSize {
			get {
				GLib.Value val = GetProperty ("icon-size");
				int ret = (int) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("icon-size", val);
				val.Dispose ();
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_stack_switcher_get_stack(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_stack_switcher_set_stack(IntPtr raw, IntPtr stack);

		[GLib.Property ("stack")]
		public Gtk.Stack Stack {
			get  {
				IntPtr raw_ret = gtk_stack_switcher_get_stack(Handle);
				Gtk.Stack ret = GLib.Object.GetObject(raw_ret) as Gtk.Stack;
				return ret;
			}
			set  {
				gtk_stack_switcher_set_stack(Handle, value == null ? IntPtr.Zero : value.Handle);
			}
		}

		[StructLayout (LayoutKind.Sequential)]
		struct GtkStackSwitcherClass {
			IntPtr GtkReserved1;
			IntPtr GtkReserved2;
			IntPtr GtkReserved3;
			IntPtr GtkReserved4;
		}

		static uint class_offset = ((GLib.GType) typeof (Gtk.Box)).GetClassSize ();
		static Dictionary<GLib.GType, GtkStackSwitcherClass> class_structs;

		static GtkStackSwitcherClass GetClassStruct (GLib.GType gtype, bool use_cache)
		{
			if (class_structs == null)
				class_structs = new Dictionary<GLib.GType, GtkStackSwitcherClass> ();

			if (use_cache && class_structs.ContainsKey (gtype))
				return class_structs [gtype];
			else {
				IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
				GtkStackSwitcherClass class_struct = (GtkStackSwitcherClass) Marshal.PtrToStructure (class_ptr, typeof (GtkStackSwitcherClass));
				if (use_cache)
					class_structs.Add (gtype, class_struct);
				return class_struct;
			}
		}

		static void OverrideClassStruct (GLib.GType gtype, GtkStackSwitcherClass class_struct)
		{
			IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
			Marshal.StructureToPtr (class_struct, class_ptr, false);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_stack_switcher_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gtk_stack_switcher_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
	}
}