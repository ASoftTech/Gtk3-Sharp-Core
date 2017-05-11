// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gtk {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class NumerableIcon : GLib.EmblemedIcon {

		public NumerableIcon (IntPtr raw) : base(raw) {}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_numerable_icon_new(IntPtr base_icon);

		public NumerableIcon (GLib.IIcon base_icon) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (NumerableIcon)) {
				var vals = new List<GLib.Value> ();
				var names = new List<string> ();
				CreateNativeObject (names.ToArray (), vals.ToArray ());
				return;
			}
			Raw = gtk_numerable_icon_new(base_icon == null ? IntPtr.Zero : ((base_icon is GLib.Object) ? (base_icon as GLib.Object).Handle : (base_icon as GLib.IconAdapter).Handle));
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_numerable_icon_new_with_style_context(IntPtr base_icon, IntPtr context);

		public NumerableIcon (GLib.IIcon base_icon, Gtk.StyleContext context) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (NumerableIcon)) {
				var vals = new List<GLib.Value> ();
				var names = new List<string> ();
				CreateNativeObject (names.ToArray (), vals.ToArray ());
				return;
			}
			Raw = gtk_numerable_icon_new_with_style_context(base_icon == null ? IntPtr.Zero : ((base_icon is GLib.Object) ? (base_icon as GLib.Object).Handle : (base_icon as GLib.IconAdapter).Handle), context == null ? IntPtr.Zero : context.Handle);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gtk_numerable_icon_get_count(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_numerable_icon_set_count(IntPtr raw, int count);

		[Obsolete]
		[GLib.Property ("count")]
		public int Count {
			get  {
				int raw_ret = gtk_numerable_icon_get_count(Handle);
				int ret = raw_ret;
				return ret;
			}
			set  {
				gtk_numerable_icon_set_count(Handle, value);
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_numerable_icon_get_label(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_numerable_icon_set_label(IntPtr raw, IntPtr label);

		[Obsolete]
		[GLib.Property ("label")]
		public string Label {
			get  {
				IntPtr raw_ret = gtk_numerable_icon_get_label(Handle);
				string ret = GLib.Marshaller.Utf8PtrToString (raw_ret);
				return ret;
			}
			set  {
				IntPtr native_value = GLib.Marshaller.StringToPtrGStrdup (value);
				gtk_numerable_icon_set_label(Handle, native_value);
				GLib.Marshaller.Free (native_value);
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_numerable_icon_get_style_context(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_numerable_icon_set_style_context(IntPtr raw, IntPtr style);

		[Obsolete]
		[GLib.Property ("style-context")]
		public Gtk.StyleContext StyleContext {
			get  {
				IntPtr raw_ret = gtk_numerable_icon_get_style_context(Handle);
				Gtk.StyleContext ret = GLib.Object.GetObject(raw_ret) as Gtk.StyleContext;
				return ret;
			}
			set  {
				gtk_numerable_icon_set_style_context(Handle, value == null ? IntPtr.Zero : value.Handle);
			}
		}

		[GLib.Property ("background-icon")]
		public GLib.IIcon BackgroundIcon {
			get {
				GLib.Value val = GetProperty ("background-icon");
				GLib.IIcon ret = GLib.IconAdapter.GetObject ((GLib.Object) val);
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("background-icon", val);
				val.Dispose ();
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_numerable_icon_get_background_icon_name(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_numerable_icon_set_background_icon_name(IntPtr raw, IntPtr icon_name);

		[Obsolete]
		[GLib.Property ("background-icon-name")]
		public string BackgroundIconName {
			get  {
				IntPtr raw_ret = gtk_numerable_icon_get_background_icon_name(Handle);
				string ret = GLib.Marshaller.Utf8PtrToString (raw_ret);
				return ret;
			}
			set  {
				IntPtr native_value = GLib.Marshaller.StringToPtrGStrdup (value);
				gtk_numerable_icon_set_background_icon_name(Handle, native_value);
				GLib.Marshaller.Free (native_value);
			}
		}

		[StructLayout (LayoutKind.Sequential)]
		struct GtkNumerableIconClass {
			[MarshalAs (UnmanagedType.ByValArray, SizeConst=16)]
			private IntPtr[] Padding;
		}

		static uint class_offset = ((GLib.GType) typeof (GLib.EmblemedIcon)).GetClassSize ();
		static Dictionary<GLib.GType, GtkNumerableIconClass> class_structs;

		static GtkNumerableIconClass GetClassStruct (GLib.GType gtype, bool use_cache)
		{
			if (class_structs == null)
				class_structs = new Dictionary<GLib.GType, GtkNumerableIconClass> ();

			if (use_cache && class_structs.ContainsKey (gtype))
				return class_structs [gtype];
			else {
				IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
				GtkNumerableIconClass class_struct = (GtkNumerableIconClass) Marshal.PtrToStructure (class_ptr, typeof (GtkNumerableIconClass));
				if (use_cache)
					class_structs.Add (gtype, class_struct);
				return class_struct;
			}
		}

		static void OverrideClassStruct (GLib.GType gtype, GtkNumerableIconClass class_struct)
		{
			IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
			Marshal.StructureToPtr (class_struct, class_ptr, false);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_numerable_icon_get_background_gicon(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_numerable_icon_set_background_gicon(IntPtr raw, IntPtr icon);

		[Obsolete]
		public GLib.IIcon BackgroundGicon { 
			get {
				IntPtr raw_ret = gtk_numerable_icon_get_background_gicon(Handle);
				GLib.IIcon ret = GLib.IconAdapter.GetObject (raw_ret, false);
				return ret;
			}
			set {
				gtk_numerable_icon_set_background_gicon(Handle, value == null ? IntPtr.Zero : ((value is GLib.Object) ? (value as GLib.Object).Handle : (value as GLib.IconAdapter).Handle));
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_numerable_icon_get_type();

		[Obsolete]
		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gtk_numerable_icon_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
	}
}