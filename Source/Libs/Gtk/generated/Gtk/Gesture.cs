// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gtk {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class Gesture : Gtk.EventController {

		public Gesture (IntPtr raw) : base(raw) {}

		protected Gesture() : base(IntPtr.Zero)
		{
			CreateNativeObject (new string [0], new GLib.Value [0]);
		}

		[GLib.Property ("n-points")]
		public uint NPoints {
			get {
				GLib.Value val = GetProperty ("n-points");
				uint ret = (uint) val;
				val.Dispose ();
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_gesture_get_window(IntPtr raw);

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_gesture_set_window(IntPtr raw, IntPtr window);

		[GLib.Property ("window")]
		public Gdk.Window Window {
			get  {
				IntPtr raw_ret = gtk_gesture_get_window(Handle);
				Gdk.Window ret = GLib.Object.GetObject(raw_ret) as Gdk.Window;
				return ret;
			}
			set  {
				gtk_gesture_set_window(Handle, value == null ? IntPtr.Zero : value.Handle);
			}
		}

		[GLib.Signal("update")]
		public event Gtk.UpdateHandler Update {
			add {
				this.AddSignalHandler ("update", value, typeof (Gtk.UpdateArgs));
			}
			remove {
				this.RemoveSignalHandler ("update", value);
			}
		}

		[GLib.Signal("cancel")]
		public event Gtk.CancelHandler Cancel {
			add {
				this.AddSignalHandler ("cancel", value, typeof (Gtk.CancelArgs));
			}
			remove {
				this.RemoveSignalHandler ("cancel", value);
			}
		}

		[GLib.Signal("sequence-state-changed")]
		public event Gtk.SequenceStateChangedHandler SequenceStateChanged {
			add {
				this.AddSignalHandler ("sequence-state-changed", value, typeof (Gtk.SequenceStateChangedArgs));
			}
			remove {
				this.RemoveSignalHandler ("sequence-state-changed", value);
			}
		}

		[GLib.Signal("end")]
		public event Gtk.EndHandler End {
			add {
				this.AddSignalHandler ("end", value, typeof (Gtk.EndArgs));
			}
			remove {
				this.RemoveSignalHandler ("end", value);
			}
		}

		[GLib.Signal("begin")]
		public event Gtk.BeginHandler Begin {
			add {
				this.AddSignalHandler ("begin", value, typeof (Gtk.BeginArgs));
			}
			remove {
				this.RemoveSignalHandler ("begin", value);
			}
		}

		static CheckNativeDelegate Check_cb_delegate;
		static CheckNativeDelegate CheckVMCallback {
			get {
				if (Check_cb_delegate == null)
					Check_cb_delegate = new CheckNativeDelegate (Check_cb);
				return Check_cb_delegate;
			}
		}

		static void OverrideCheck (GLib.GType gtype)
		{
			OverrideCheck (gtype, CheckVMCallback);
		}

		static void OverrideCheck (GLib.GType gtype, CheckNativeDelegate callback)
		{
			GtkGestureClass class_iface = GetClassStruct (gtype, false);
			class_iface.Check = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate bool CheckNativeDelegate (IntPtr inst);

		static bool Check_cb (IntPtr inst)
		{
			try {
				Gesture __obj = GLib.Object.GetObject (inst, false) as Gesture;
				bool __result;
				__result = __obj.OnCheck ();
				return __result;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gtk.Gesture), ConnectionMethod="OverrideCheck")]
		protected virtual bool OnCheck ()
		{
			return InternalCheck ();
		}

		private bool InternalCheck ()
		{
			CheckNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).Check;
			if (unmanaged == null) return false;

			bool __result = unmanaged (this.Handle);
			return __result;
		}

		static BeginNativeDelegate Begin_cb_delegate;
		static BeginNativeDelegate BeginVMCallback {
			get {
				if (Begin_cb_delegate == null)
					Begin_cb_delegate = new BeginNativeDelegate (Begin_cb);
				return Begin_cb_delegate;
			}
		}

		static void OverrideBegin (GLib.GType gtype)
		{
			OverrideBegin (gtype, BeginVMCallback);
		}

		static void OverrideBegin (GLib.GType gtype, BeginNativeDelegate callback)
		{
			GtkGestureClass class_iface = GetClassStruct (gtype, false);
			class_iface.Begin = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void BeginNativeDelegate (IntPtr inst, IntPtr sequence);

		static void Begin_cb (IntPtr inst, IntPtr sequence)
		{
			try {
				Gesture __obj = GLib.Object.GetObject (inst, false) as Gesture;
				__obj.OnBegin (sequence == IntPtr.Zero ? null : (Gdk.EventSequence) GLib.Opaque.GetOpaque (sequence, typeof (Gdk.EventSequence), false));
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gtk.Gesture), ConnectionMethod="OverrideBegin")]
		protected virtual void OnBegin (Gdk.EventSequence sequence)
		{
			InternalBegin (sequence);
		}

		private void InternalBegin (Gdk.EventSequence sequence)
		{
			BeginNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).Begin;
			if (unmanaged == null) return;

			unmanaged (this.Handle, sequence == null ? IntPtr.Zero : sequence.Handle);
		}

		static UpdateNativeDelegate Update_cb_delegate;
		static UpdateNativeDelegate UpdateVMCallback {
			get {
				if (Update_cb_delegate == null)
					Update_cb_delegate = new UpdateNativeDelegate (Update_cb);
				return Update_cb_delegate;
			}
		}

		static void OverrideUpdate (GLib.GType gtype)
		{
			OverrideUpdate (gtype, UpdateVMCallback);
		}

		static void OverrideUpdate (GLib.GType gtype, UpdateNativeDelegate callback)
		{
			GtkGestureClass class_iface = GetClassStruct (gtype, false);
			class_iface.Update = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void UpdateNativeDelegate (IntPtr inst, IntPtr sequence);

		static void Update_cb (IntPtr inst, IntPtr sequence)
		{
			try {
				Gesture __obj = GLib.Object.GetObject (inst, false) as Gesture;
				__obj.OnUpdate (sequence == IntPtr.Zero ? null : (Gdk.EventSequence) GLib.Opaque.GetOpaque (sequence, typeof (Gdk.EventSequence), false));
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gtk.Gesture), ConnectionMethod="OverrideUpdate")]
		protected virtual void OnUpdate (Gdk.EventSequence sequence)
		{
			InternalUpdate (sequence);
		}

		private void InternalUpdate (Gdk.EventSequence sequence)
		{
			UpdateNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).Update;
			if (unmanaged == null) return;

			unmanaged (this.Handle, sequence == null ? IntPtr.Zero : sequence.Handle);
		}

		static EndNativeDelegate End_cb_delegate;
		static EndNativeDelegate EndVMCallback {
			get {
				if (End_cb_delegate == null)
					End_cb_delegate = new EndNativeDelegate (End_cb);
				return End_cb_delegate;
			}
		}

		static void OverrideEnd (GLib.GType gtype)
		{
			OverrideEnd (gtype, EndVMCallback);
		}

		static void OverrideEnd (GLib.GType gtype, EndNativeDelegate callback)
		{
			GtkGestureClass class_iface = GetClassStruct (gtype, false);
			class_iface.End = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void EndNativeDelegate (IntPtr inst, IntPtr sequence);

		static void End_cb (IntPtr inst, IntPtr sequence)
		{
			try {
				Gesture __obj = GLib.Object.GetObject (inst, false) as Gesture;
				__obj.OnEnd (sequence == IntPtr.Zero ? null : (Gdk.EventSequence) GLib.Opaque.GetOpaque (sequence, typeof (Gdk.EventSequence), false));
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gtk.Gesture), ConnectionMethod="OverrideEnd")]
		protected virtual void OnEnd (Gdk.EventSequence sequence)
		{
			InternalEnd (sequence);
		}

		private void InternalEnd (Gdk.EventSequence sequence)
		{
			EndNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).End;
			if (unmanaged == null) return;

			unmanaged (this.Handle, sequence == null ? IntPtr.Zero : sequence.Handle);
		}

		static CancelNativeDelegate Cancel_cb_delegate;
		static CancelNativeDelegate CancelVMCallback {
			get {
				if (Cancel_cb_delegate == null)
					Cancel_cb_delegate = new CancelNativeDelegate (Cancel_cb);
				return Cancel_cb_delegate;
			}
		}

		static void OverrideCancel (GLib.GType gtype)
		{
			OverrideCancel (gtype, CancelVMCallback);
		}

		static void OverrideCancel (GLib.GType gtype, CancelNativeDelegate callback)
		{
			GtkGestureClass class_iface = GetClassStruct (gtype, false);
			class_iface.Cancel = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void CancelNativeDelegate (IntPtr inst, IntPtr sequence);

		static void Cancel_cb (IntPtr inst, IntPtr sequence)
		{
			try {
				Gesture __obj = GLib.Object.GetObject (inst, false) as Gesture;
				__obj.OnCancel (sequence == IntPtr.Zero ? null : (Gdk.EventSequence) GLib.Opaque.GetOpaque (sequence, typeof (Gdk.EventSequence), false));
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gtk.Gesture), ConnectionMethod="OverrideCancel")]
		protected virtual void OnCancel (Gdk.EventSequence sequence)
		{
			InternalCancel (sequence);
		}

		private void InternalCancel (Gdk.EventSequence sequence)
		{
			CancelNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).Cancel;
			if (unmanaged == null) return;

			unmanaged (this.Handle, sequence == null ? IntPtr.Zero : sequence.Handle);
		}

		static SequenceStateChangedNativeDelegate SequenceStateChanged_cb_delegate;
		static SequenceStateChangedNativeDelegate SequenceStateChangedVMCallback {
			get {
				if (SequenceStateChanged_cb_delegate == null)
					SequenceStateChanged_cb_delegate = new SequenceStateChangedNativeDelegate (SequenceStateChanged_cb);
				return SequenceStateChanged_cb_delegate;
			}
		}

		static void OverrideSequenceStateChanged (GLib.GType gtype)
		{
			OverrideSequenceStateChanged (gtype, SequenceStateChangedVMCallback);
		}

		static void OverrideSequenceStateChanged (GLib.GType gtype, SequenceStateChangedNativeDelegate callback)
		{
			GtkGestureClass class_iface = GetClassStruct (gtype, false);
			class_iface.SequenceStateChanged = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void SequenceStateChangedNativeDelegate (IntPtr inst, IntPtr sequence, int state);

		static void SequenceStateChanged_cb (IntPtr inst, IntPtr sequence, int state)
		{
			try {
				Gesture __obj = GLib.Object.GetObject (inst, false) as Gesture;
				__obj.OnSequenceStateChanged (sequence == IntPtr.Zero ? null : (Gdk.EventSequence) GLib.Opaque.GetOpaque (sequence, typeof (Gdk.EventSequence), false), (Gtk.EventSequenceState) state);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gtk.Gesture), ConnectionMethod="OverrideSequenceStateChanged")]
		protected virtual void OnSequenceStateChanged (Gdk.EventSequence sequence, Gtk.EventSequenceState state)
		{
			InternalSequenceStateChanged (sequence, state);
		}

		private void InternalSequenceStateChanged (Gdk.EventSequence sequence, Gtk.EventSequenceState state)
		{
			SequenceStateChangedNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).SequenceStateChanged;
			if (unmanaged == null) return;

			unmanaged (this.Handle, sequence == null ? IntPtr.Zero : sequence.Handle, (int) state);
		}

		[StructLayout (LayoutKind.Sequential)]
		struct GtkGestureClass {
			public CheckNativeDelegate Check;
			public BeginNativeDelegate Begin;
			public UpdateNativeDelegate Update;
			public EndNativeDelegate End;
			public CancelNativeDelegate Cancel;
			public SequenceStateChangedNativeDelegate SequenceStateChanged;
			[MarshalAs (UnmanagedType.ByValArray, SizeConst=10)]
			private IntPtr[] Padding;
		}

		static uint class_offset = ((GLib.GType) typeof (Gtk.EventController)).GetClassSize ();
		static Dictionary<GLib.GType, GtkGestureClass> class_structs;

		static GtkGestureClass GetClassStruct (GLib.GType gtype, bool use_cache)
		{
			if (class_structs == null)
				class_structs = new Dictionary<GLib.GType, GtkGestureClass> ();

			if (use_cache && class_structs.ContainsKey (gtype))
				return class_structs [gtype];
			else {
				IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
				GtkGestureClass class_struct = (GtkGestureClass) Marshal.PtrToStructure (class_ptr, typeof (GtkGestureClass));
				if (use_cache)
					class_structs.Add (gtype, class_struct);
				return class_struct;
			}
		}

		static void OverrideClassStruct (GLib.GType gtype, GtkGestureClass class_struct)
		{
			IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
			Marshal.StructureToPtr (class_struct, class_ptr, false);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gtk_gesture_get_bounding_box(IntPtr raw, IntPtr rect);

		public bool GetBoundingBox(Gdk.Rectangle rect) {
			IntPtr native_rect = GLib.Marshaller.StructureToPtrAlloc (rect);
			bool raw_ret = gtk_gesture_get_bounding_box(Handle, native_rect);
			bool ret = raw_ret;
			Marshal.FreeHGlobal (native_rect);
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gtk_gesture_get_bounding_box_center(IntPtr raw, out double x, out double y);

		public bool GetBoundingBoxCenter(out double x, out double y) {
			bool raw_ret = gtk_gesture_get_bounding_box_center(Handle, out x, out y);
			bool ret = raw_ret;
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_gesture_get_device(IntPtr raw);

		public Gdk.Device Device { 
			get {
				IntPtr raw_ret = gtk_gesture_get_device(Handle);
				Gdk.Device ret = GLib.Object.GetObject(raw_ret) as Gdk.Device;
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_gesture_get_last_event(IntPtr raw, IntPtr sequence);

		public Gdk.Event GetLastEvent(Gdk.EventSequence sequence) {
			IntPtr raw_ret = gtk_gesture_get_last_event(Handle, sequence == null ? IntPtr.Zero : sequence.Handle);
			Gdk.Event ret = Gdk.Event.GetEvent (raw_ret);
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_gesture_get_last_updated_sequence(IntPtr raw);

		public Gdk.EventSequence LastUpdatedSequence { 
			get {
				IntPtr raw_ret = gtk_gesture_get_last_updated_sequence(Handle);
				Gdk.EventSequence ret = raw_ret == IntPtr.Zero ? null : (Gdk.EventSequence) GLib.Opaque.GetOpaque (raw_ret, typeof (Gdk.EventSequence), false);
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gtk_gesture_get_point(IntPtr raw, IntPtr sequence, out double x, out double y);

		public bool GetPoint(Gdk.EventSequence sequence, out double x, out double y) {
			bool raw_ret = gtk_gesture_get_point(Handle, sequence == null ? IntPtr.Zero : sequence.Handle, out x, out y);
			bool ret = raw_ret;
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gtk_gesture_get_sequence_state(IntPtr raw, IntPtr sequence);

		public Gtk.EventSequenceState GetSequenceState(Gdk.EventSequence sequence) {
			int raw_ret = gtk_gesture_get_sequence_state(Handle, sequence == null ? IntPtr.Zero : sequence.Handle);
			Gtk.EventSequenceState ret = (Gtk.EventSequenceState) raw_ret;
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_gesture_get_sequences(IntPtr raw);

		public GLib.List Sequences { 
			get {
				IntPtr raw_ret = gtk_gesture_get_sequences(Handle);
				GLib.List ret = new GLib.List(raw_ret);
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gtk_gesture_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gtk_gesture_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_gesture_group(IntPtr raw, IntPtr gesture);

		public void Group(Gtk.Gesture gesture) {
			gtk_gesture_group(Handle, gesture == null ? IntPtr.Zero : gesture.Handle);
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gtk_gesture_handles_sequence(IntPtr raw, IntPtr sequence);

		public bool HandlesSequence(Gdk.EventSequence sequence) {
			bool raw_ret = gtk_gesture_handles_sequence(Handle, sequence == null ? IntPtr.Zero : sequence.Handle);
			bool ret = raw_ret;
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gtk_gesture_is_active(IntPtr raw);

		public bool IsActive { 
			get {
				bool raw_ret = gtk_gesture_is_active(Handle);
				bool ret = raw_ret;
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gtk_gesture_is_grouped_with(IntPtr raw, IntPtr other);

		public bool IsGroupedWith(Gtk.Gesture other) {
			bool raw_ret = gtk_gesture_is_grouped_with(Handle, other == null ? IntPtr.Zero : other.Handle);
			bool ret = raw_ret;
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gtk_gesture_is_recognized(IntPtr raw);

		public bool IsRecognized { 
			get {
				bool raw_ret = gtk_gesture_is_recognized(Handle);
				bool ret = raw_ret;
				return ret;
			}
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gtk_gesture_set_sequence_state(IntPtr raw, IntPtr sequence, int state);

		public bool SetSequenceState(Gdk.EventSequence sequence, Gtk.EventSequenceState state) {
			bool raw_ret = gtk_gesture_set_sequence_state(Handle, sequence == null ? IntPtr.Zero : sequence.Handle, (int) state);
			bool ret = raw_ret;
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gtk_gesture_set_state(IntPtr raw, int state);

		public bool SetState(Gtk.EventSequenceState state) {
			bool raw_ret = gtk_gesture_set_state(Handle, (int) state);
			bool ret = raw_ret;
			return ret;
		}

		[DllImport("libgtk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gtk_gesture_ungroup(IntPtr raw);

		public void Ungroup() {
			gtk_gesture_ungroup(Handle);
		}

#endregion
	}
}