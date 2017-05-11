// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gtk {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class Builder : GLib.Object {

		public Builder (IntPtr raw) : base(raw) {}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_builder_new();

		public Builder () : base (IntPtr.Zero)
		{
			if (GetType () != typeof (Builder)) {
				CreateNativeObject (new string [0], new GLib.Value[0]);
				return;
			}
			Raw = gtk_builder_new();
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_builder_get_translation_domain(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_builder_set_translation_domain(IntPtr raw, IntPtr domain);

		[GLib.Property ("translation-domain")]
		public string TranslationDomain {
			get  {
				IntPtr raw_ret = gtk_builder_get_translation_domain(Handle);
				string ret = GLib.Marshaller.Utf8PtrToString (raw_ret);
				return ret;
			}
			set  {
				IntPtr native_value = GLib.Marshaller.StringToPtrGStrdup (value);
				gtk_builder_set_translation_domain(Handle, native_value);
				GLib.Marshaller.Free (native_value);
			}
		}

		static GetTypeFromNameNativeDelegate GetTypeFromName_cb_delegate;
		static GetTypeFromNameNativeDelegate GetTypeFromNameVMCallback {
			get {
				if (GetTypeFromName_cb_delegate == null)
					GetTypeFromName_cb_delegate = new GetTypeFromNameNativeDelegate (GetTypeFromName_cb);
				return GetTypeFromName_cb_delegate;
			}
		}

		static void OverrideGetTypeFromName (GLib.GType gtype)
		{
			OverrideGetTypeFromName (gtype, GetTypeFromNameVMCallback);
		}

		static void OverrideGetTypeFromName (GLib.GType gtype, GetTypeFromNameNativeDelegate callback)
		{
			GtkBuilderClass class_iface = GetClassStruct (gtype, false);
			class_iface.GetTypeFromName = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate IntPtr GetTypeFromNameNativeDelegate (IntPtr inst, IntPtr type_name);

		static IntPtr GetTypeFromName_cb (IntPtr inst, IntPtr type_name)
		{
			try {
				Builder __obj = GLib.Object.GetObject (inst, false) as Builder;
				GLib.GType __result;
				__result = __obj.OnGetTypeFromName (GLib.Marshaller.Utf8PtrToString (type_name));
				return __result.Val;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gtk.Builder), ConnectionMethod="OverrideGetTypeFromName")]
		protected virtual GLib.GType OnGetTypeFromName (string type_name)
		{
			return InternalGetTypeFromName (type_name);
		}

		private GLib.GType InternalGetTypeFromName (string type_name)
		{
			GetTypeFromNameNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).GetTypeFromName;
			if (unmanaged == null) return GLib.GType.None;

			IntPtr native_type_name = GLib.Marshaller.StringToPtrGStrdup (type_name);
			IntPtr __result = unmanaged (this.Handle, native_type_name);
			GLib.Marshaller.Free (native_type_name);
			return new GLib.GType(__result);
		}

		[StructLayout (LayoutKind.Sequential)]
		struct GtkBuilderClass {
			public GetTypeFromNameNativeDelegate GetTypeFromName;
			IntPtr GtkReserved1;
			IntPtr GtkReserved2;
			IntPtr GtkReserved3;
			IntPtr GtkReserved4;
			IntPtr GtkReserved5;
			IntPtr GtkReserved6;
			IntPtr GtkReserved7;
			IntPtr GtkReserved8;
		}

		static uint class_offset = ((GLib.GType) typeof (GLib.Object)).GetClassSize ();
		static Dictionary<GLib.GType, GtkBuilderClass> class_structs;

		static GtkBuilderClass GetClassStruct (GLib.GType gtype, bool use_cache)
		{
			if (class_structs == null)
				class_structs = new Dictionary<GLib.GType, GtkBuilderClass> ();

			if (use_cache && class_structs.ContainsKey (gtype))
				return class_structs [gtype];
			else {
				IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
				GtkBuilderClass class_struct = (GtkBuilderClass) Marshal.PtrToStructure (class_ptr, typeof (GtkBuilderClass));
				if (use_cache)
					class_structs.Add (gtype, class_struct);
				return class_struct;
			}
		}

		static void OverrideClassStruct (GLib.GType gtype, GtkBuilderClass class_struct)
		{
			IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
			Marshal.StructureToPtr (class_struct, class_ptr, false);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern unsafe uint gtk_builder_add_from_file(IntPtr raw, IntPtr filename, out IntPtr error);

		public unsafe uint AddFromFile(string filename) {
			IntPtr native_filename = GLib.Marshaller.StringToFilenamePtr (filename);
			IntPtr error = IntPtr.Zero;
			uint raw_ret = gtk_builder_add_from_file(Handle, native_filename, out error);
			uint ret = raw_ret;
			GLib.Marshaller.Free (native_filename);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern unsafe uint gtk_builder_add_from_resource(IntPtr raw, IntPtr resource_path, out IntPtr error);

		public unsafe uint AddFromResource(string resource_path) {
			IntPtr native_resource_path = GLib.Marshaller.StringToPtrGStrdup (resource_path);
			IntPtr error = IntPtr.Zero;
			uint raw_ret = gtk_builder_add_from_resource(Handle, native_resource_path, out error);
			uint ret = raw_ret;
			GLib.Marshaller.Free (native_resource_path);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern unsafe uint gtk_builder_add_from_string(IntPtr raw, IntPtr buffer, UIntPtr length, out IntPtr error);

		public unsafe uint AddFromString(string buffer) {
			IntPtr native_buffer = GLib.Marshaller.StringToPtrGStrdup (buffer);
			IntPtr error = IntPtr.Zero;
			uint raw_ret = gtk_builder_add_from_string(Handle, native_buffer, new UIntPtr ((ulong) System.Text.Encoding.UTF8.GetByteCount (buffer)), out error);
			uint ret = raw_ret;
			GLib.Marshaller.Free (native_buffer);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern unsafe uint gtk_builder_add_objects_from_file(IntPtr raw, IntPtr filename, IntPtr object_ids, out IntPtr error);

		public unsafe uint AddObjectsFromFile(string filename, string object_ids) {
			IntPtr native_filename = GLib.Marshaller.StringToPtrGStrdup (filename);
			IntPtr error = IntPtr.Zero;
			uint raw_ret = gtk_builder_add_objects_from_file(Handle, native_filename, GLib.Marshaller.StringToPtrGStrdup(object_ids), out error);
			uint ret = raw_ret;
			GLib.Marshaller.Free (native_filename);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern unsafe uint gtk_builder_add_objects_from_resource(IntPtr raw, IntPtr resource_path, IntPtr object_ids, out IntPtr error);

		public unsafe uint AddObjectsFromResource(string resource_path, string object_ids) {
			IntPtr native_resource_path = GLib.Marshaller.StringToPtrGStrdup (resource_path);
			IntPtr error = IntPtr.Zero;
			uint raw_ret = gtk_builder_add_objects_from_resource(Handle, native_resource_path, GLib.Marshaller.StringToPtrGStrdup(object_ids), out error);
			uint ret = raw_ret;
			GLib.Marshaller.Free (native_resource_path);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern unsafe uint gtk_builder_add_objects_from_string(IntPtr raw, IntPtr buffer, UIntPtr length, IntPtr object_ids, out IntPtr error);

		public unsafe uint AddObjectsFromString(string buffer, string object_ids) {
			IntPtr native_buffer = GLib.Marshaller.StringToPtrGStrdup (buffer);
			IntPtr error = IntPtr.Zero;
			uint raw_ret = gtk_builder_add_objects_from_string(Handle, native_buffer, new UIntPtr ((ulong) System.Text.Encoding.UTF8.GetByteCount (buffer)), GLib.Marshaller.StringToPtrGStrdup(object_ids), out error);
			uint ret = raw_ret;
			GLib.Marshaller.Free (native_buffer);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gtk_builder_error_quark();

		public static int ErrorQuark { 
			get {
				int raw_ret = gtk_builder_error_quark();
				int ret = raw_ret;
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_builder_expose_object(IntPtr raw, IntPtr name, IntPtr objekt);

		public void ExposeObject(string name, GLib.Object objekt) {
			IntPtr native_name = GLib.Marshaller.StringToPtrGStrdup (name);
			gtk_builder_expose_object(Handle, native_name, objekt == null ? IntPtr.Zero : objekt.Handle);
			GLib.Marshaller.Free (native_name);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern unsafe uint gtk_builder_extend_with_template(IntPtr raw, IntPtr widget, IntPtr template_type, IntPtr buffer, UIntPtr length, out IntPtr error);

		public unsafe uint ExtendWithTemplate(Gtk.Widget widget, GLib.GType template_type, string buffer) {
			IntPtr native_buffer = GLib.Marshaller.StringToPtrGStrdup (buffer);
			IntPtr error = IntPtr.Zero;
			uint raw_ret = gtk_builder_extend_with_template(Handle, widget == null ? IntPtr.Zero : widget.Handle, template_type.Val, native_buffer, new UIntPtr ((ulong) System.Text.Encoding.UTF8.GetByteCount (buffer)), out error);
			uint ret = raw_ret;
			GLib.Marshaller.Free (native_buffer);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_builder_get_application(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_builder_set_application(IntPtr raw, IntPtr application);

		public Gtk.Application Application { 
			get {
				IntPtr raw_ret = gtk_builder_get_application(Handle);
				Gtk.Application ret = GLib.Object.GetObject(raw_ret) as Gtk.Application;
				return ret;
			}
			set {
				gtk_builder_set_application(Handle, value == null ? IntPtr.Zero : value.Handle);
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_builder_get_object(IntPtr raw, IntPtr name);

		public GLib.Object GetObject(string name) {
			IntPtr native_name = GLib.Marshaller.StringToPtrGStrdup (name);
			IntPtr raw_ret = gtk_builder_get_object(Handle, native_name);
			GLib.Object ret = GLib.Object.GetObject (raw_ret);
			GLib.Marshaller.Free (native_name);
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_builder_get_objects(IntPtr raw);

		public GLib.Object[] Objects { 
			get {
				IntPtr raw_ret = gtk_builder_get_objects(Handle);
				GLib.Object[] ret = (GLib.Object[]) GLib.Marshaller.ListPtrToArray (raw_ret, typeof(GLib.SList), true, false, typeof(GLib.Object));
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_builder_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gtk_builder_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
	}
}