// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Pango {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class Renderer : GLib.Object {

		public Renderer (IntPtr raw) : base(raw) {}

		protected Renderer() : base(IntPtr.Zero)
		{
			CreateNativeObject (new string [0], new GLib.Value [0]);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr pango_renderer_get_matrix(IntPtr raw);

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_set_matrix(IntPtr raw, IntPtr value);

		public Pango.Matrix Matrix {
			get  {
				IntPtr raw_ret = pango_renderer_get_matrix(Handle);
				Pango.Matrix ret = Pango.Matrix.New (raw_ret);
				return ret;
			}
			set  {
				IntPtr native_value = GLib.Marshaller.StructureToPtrAlloc (value);
				pango_renderer_set_matrix(Handle, native_value);
				Marshal.FreeHGlobal (native_value);
			}
		}

		static DrawGlyphsNativeDelegate DrawGlyphs_cb_delegate;
		static DrawGlyphsNativeDelegate DrawGlyphsVMCallback {
			get {
				if (DrawGlyphs_cb_delegate == null)
					DrawGlyphs_cb_delegate = new DrawGlyphsNativeDelegate (DrawGlyphs_cb);
				return DrawGlyphs_cb_delegate;
			}
		}

		static void OverrideDrawGlyphs (GLib.GType gtype)
		{
			OverrideDrawGlyphs (gtype, DrawGlyphsVMCallback);
		}

		static void OverrideDrawGlyphs (GLib.GType gtype, DrawGlyphsNativeDelegate callback)
		{
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.DrawGlyphs = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void DrawGlyphsNativeDelegate (IntPtr inst, IntPtr font, IntPtr glyphs, int x, int y);

		static void DrawGlyphs_cb (IntPtr inst, IntPtr font, IntPtr glyphs, int x, int y)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnDrawGlyphs (GLib.Object.GetObject(font) as Pango.Font, glyphs == IntPtr.Zero ? null : (Pango.GlyphString) GLib.Opaque.GetOpaque (glyphs, typeof (Pango.GlyphString), false), x, y);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverrideDrawGlyphs")]
		protected virtual void OnDrawGlyphs (Pango.Font font, Pango.GlyphString glyphs, int x, int y)
		{
			InternalDrawGlyphs (font, glyphs, x, y);
		}

		private void InternalDrawGlyphs (Pango.Font font, Pango.GlyphString glyphs, int x, int y)
		{
			DrawGlyphsNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).DrawGlyphs;
			if (unmanaged == null) return;

			unmanaged (this.Handle, font == null ? IntPtr.Zero : font.Handle, glyphs == null ? IntPtr.Zero : glyphs.Handle, x, y);
		}

		static DrawRectangleNativeDelegate DrawRectangle_cb_delegate;
		static DrawRectangleNativeDelegate DrawRectangleVMCallback {
			get {
				if (DrawRectangle_cb_delegate == null)
					DrawRectangle_cb_delegate = new DrawRectangleNativeDelegate (DrawRectangle_cb);
				return DrawRectangle_cb_delegate;
			}
		}

		static void OverrideDrawRectangle (GLib.GType gtype)
		{
			OverrideDrawRectangle (gtype, DrawRectangleVMCallback);
		}

		static void OverrideDrawRectangle (GLib.GType gtype, DrawRectangleNativeDelegate callback)
		{
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.DrawRectangle = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void DrawRectangleNativeDelegate (IntPtr inst, int part, int x, int y, int width, int height);

		static void DrawRectangle_cb (IntPtr inst, int part, int x, int y, int width, int height)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnDrawRectangle ((Pango.RenderPart) part, x, y, width, height);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverrideDrawRectangle")]
		protected virtual void OnDrawRectangle (Pango.RenderPart part, int x, int y, int width, int height)
		{
			InternalDrawRectangle (part, x, y, width, height);
		}

		private void InternalDrawRectangle (Pango.RenderPart part, int x, int y, int width, int height)
		{
			DrawRectangleNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).DrawRectangle;
			if (unmanaged == null) return;

			unmanaged (this.Handle, (int) part, x, y, width, height);
		}

		static DrawErrorUnderlineNativeDelegate DrawErrorUnderline_cb_delegate;
		static DrawErrorUnderlineNativeDelegate DrawErrorUnderlineVMCallback {
			get {
				if (DrawErrorUnderline_cb_delegate == null)
					DrawErrorUnderline_cb_delegate = new DrawErrorUnderlineNativeDelegate (DrawErrorUnderline_cb);
				return DrawErrorUnderline_cb_delegate;
			}
		}

		static void OverrideDrawErrorUnderline (GLib.GType gtype)
		{
			OverrideDrawErrorUnderline (gtype, DrawErrorUnderlineVMCallback);
		}

		static void OverrideDrawErrorUnderline (GLib.GType gtype, DrawErrorUnderlineNativeDelegate callback)
		{
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.DrawErrorUnderline = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void DrawErrorUnderlineNativeDelegate (IntPtr inst, int x, int y, int width, int height);

		static void DrawErrorUnderline_cb (IntPtr inst, int x, int y, int width, int height)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnDrawErrorUnderline (x, y, width, height);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverrideDrawErrorUnderline")]
		protected virtual void OnDrawErrorUnderline (int x, int y, int width, int height)
		{
			InternalDrawErrorUnderline (x, y, width, height);
		}

		private void InternalDrawErrorUnderline (int x, int y, int width, int height)
		{
			DrawErrorUnderlineNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).DrawErrorUnderline;
			if (unmanaged == null) return;

			unmanaged (this.Handle, x, y, width, height);
		}

		static DrawShapeNativeDelegate DrawShape_cb_delegate;
		static DrawShapeNativeDelegate DrawShapeVMCallback {
			get {
				if (DrawShape_cb_delegate == null)
					DrawShape_cb_delegate = new DrawShapeNativeDelegate (DrawShape_cb);
				return DrawShape_cb_delegate;
			}
		}

		static void OverrideDrawShape (GLib.GType gtype)
		{
			OverrideDrawShape (gtype, DrawShapeVMCallback);
		}

		static void OverrideDrawShape (GLib.GType gtype, DrawShapeNativeDelegate callback)
		{
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.DrawShape = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void DrawShapeNativeDelegate (IntPtr inst, IntPtr attr, int x, int y);

		static void DrawShape_cb (IntPtr inst, IntPtr attr, int x, int y)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnDrawShape (Pango.Attribute.GetAttribute (attr), x, y);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverrideDrawShape")]
		protected virtual void OnDrawShape (Pango.Attribute attr, int x, int y)
		{
			InternalDrawShape (attr, x, y);
		}

		private void InternalDrawShape (Pango.Attribute attr, int x, int y)
		{
			DrawShapeNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).DrawShape;
			if (unmanaged == null) return;

			unmanaged (this.Handle, attr.Handle, x, y);
		}

		static DrawTrapezoidNativeDelegate DrawTrapezoid_cb_delegate;
		static DrawTrapezoidNativeDelegate DrawTrapezoidVMCallback {
			get {
				if (DrawTrapezoid_cb_delegate == null)
					DrawTrapezoid_cb_delegate = new DrawTrapezoidNativeDelegate (DrawTrapezoid_cb);
				return DrawTrapezoid_cb_delegate;
			}
		}

		static void OverrideDrawTrapezoid (GLib.GType gtype)
		{
			OverrideDrawTrapezoid (gtype, DrawTrapezoidVMCallback);
		}

		static void OverrideDrawTrapezoid (GLib.GType gtype, DrawTrapezoidNativeDelegate callback)
		{
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.DrawTrapezoid = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void DrawTrapezoidNativeDelegate (IntPtr inst, int part, double y1_, double x11, double x21, double y2, double x12, double x22);

		static void DrawTrapezoid_cb (IntPtr inst, int part, double y1_, double x11, double x21, double y2, double x12, double x22)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnDrawTrapezoid ((Pango.RenderPart) part, y1_, x11, x21, y2, x12, x22);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverrideDrawTrapezoid")]
		protected virtual void OnDrawTrapezoid (Pango.RenderPart part, double y1_, double x11, double x21, double y2, double x12, double x22)
		{
			InternalDrawTrapezoid (part, y1_, x11, x21, y2, x12, x22);
		}

		private void InternalDrawTrapezoid (Pango.RenderPart part, double y1_, double x11, double x21, double y2, double x12, double x22)
		{
			DrawTrapezoidNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).DrawTrapezoid;
			if (unmanaged == null) return;

			unmanaged (this.Handle, (int) part, y1_, x11, x21, y2, x12, x22);
		}

		static DrawGlyphNativeDelegate DrawGlyph_cb_delegate;
		static DrawGlyphNativeDelegate DrawGlyphVMCallback {
			get {
				if (DrawGlyph_cb_delegate == null)
					DrawGlyph_cb_delegate = new DrawGlyphNativeDelegate (DrawGlyph_cb);
				return DrawGlyph_cb_delegate;
			}
		}

		static void OverrideDrawGlyph (GLib.GType gtype)
		{
			OverrideDrawGlyph (gtype, DrawGlyphVMCallback);
		}

		static void OverrideDrawGlyph (GLib.GType gtype, DrawGlyphNativeDelegate callback)
		{
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.DrawGlyph = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void DrawGlyphNativeDelegate (IntPtr inst, IntPtr font, uint glyph, double x, double y);

		static void DrawGlyph_cb (IntPtr inst, IntPtr font, uint glyph, double x, double y)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnDrawGlyph (GLib.Object.GetObject(font) as Pango.Font, glyph, x, y);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverrideDrawGlyph")]
		protected virtual void OnDrawGlyph (Pango.Font font, uint glyph, double x, double y)
		{
			InternalDrawGlyph (font, glyph, x, y);
		}

		private void InternalDrawGlyph (Pango.Font font, uint glyph, double x, double y)
		{
			DrawGlyphNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).DrawGlyph;
			if (unmanaged == null) return;

			unmanaged (this.Handle, font == null ? IntPtr.Zero : font.Handle, glyph, x, y);
		}

		static PartChangedNativeDelegate PartChanged_cb_delegate;
		static PartChangedNativeDelegate PartChangedVMCallback {
			get {
				if (PartChanged_cb_delegate == null)
					PartChanged_cb_delegate = new PartChangedNativeDelegate (PartChanged_cb);
				return PartChanged_cb_delegate;
			}
		}

		static void OverridePartChanged (GLib.GType gtype)
		{
			OverridePartChanged (gtype, PartChangedVMCallback);
		}

		static void OverridePartChanged (GLib.GType gtype, PartChangedNativeDelegate callback)
		{
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.PartChanged = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void PartChangedNativeDelegate (IntPtr inst, int part);

		static void PartChanged_cb (IntPtr inst, int part)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnPartChanged ((Pango.RenderPart) part);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverridePartChanged")]
		protected virtual void OnPartChanged (Pango.RenderPart part)
		{
			InternalPartChanged (part);
		}

		private void InternalPartChanged (Pango.RenderPart part)
		{
			PartChangedNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).PartChanged;
			if (unmanaged == null) return;

			unmanaged (this.Handle, (int) part);
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
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.Begin = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void BeginNativeDelegate (IntPtr inst);

		static void Begin_cb (IntPtr inst)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnBegin ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverrideBegin")]
		protected virtual void OnBegin ()
		{
			InternalBegin ();
		}

		private void InternalBegin ()
		{
			BeginNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).Begin;
			if (unmanaged == null) return;

			unmanaged (this.Handle);
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
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.End = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void EndNativeDelegate (IntPtr inst);

		static void End_cb (IntPtr inst)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnEnd ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverrideEnd")]
		protected virtual void OnEnd ()
		{
			InternalEnd ();
		}

		private void InternalEnd ()
		{
			EndNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).End;
			if (unmanaged == null) return;

			unmanaged (this.Handle);
		}

		static PrepareRunNativeDelegate PrepareRun_cb_delegate;
		static PrepareRunNativeDelegate PrepareRunVMCallback {
			get {
				if (PrepareRun_cb_delegate == null)
					PrepareRun_cb_delegate = new PrepareRunNativeDelegate (PrepareRun_cb);
				return PrepareRun_cb_delegate;
			}
		}

		static void OverridePrepareRun (GLib.GType gtype)
		{
			OverridePrepareRun (gtype, PrepareRunVMCallback);
		}

		static void OverridePrepareRun (GLib.GType gtype, PrepareRunNativeDelegate callback)
		{
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.PrepareRun = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void PrepareRunNativeDelegate (IntPtr inst, IntPtr run);

		static void PrepareRun_cb (IntPtr inst, IntPtr run)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnPrepareRun (Pango.LayoutRun.New (run));
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverridePrepareRun")]
		protected virtual void OnPrepareRun (Pango.LayoutRun run)
		{
			InternalPrepareRun (run);
		}

		private void InternalPrepareRun (Pango.LayoutRun run)
		{
			PrepareRunNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).PrepareRun;
			if (unmanaged == null) return;

			IntPtr native_run = GLib.Marshaller.StructureToPtrAlloc (run);
			unmanaged (this.Handle, native_run);
			Marshal.FreeHGlobal (native_run);
		}

		static DrawGlyphItemNativeDelegate DrawGlyphItem_cb_delegate;
		static DrawGlyphItemNativeDelegate DrawGlyphItemVMCallback {
			get {
				if (DrawGlyphItem_cb_delegate == null)
					DrawGlyphItem_cb_delegate = new DrawGlyphItemNativeDelegate (DrawGlyphItem_cb);
				return DrawGlyphItem_cb_delegate;
			}
		}

		static void OverrideDrawGlyphItem (GLib.GType gtype)
		{
			OverrideDrawGlyphItem (gtype, DrawGlyphItemVMCallback);
		}

		static void OverrideDrawGlyphItem (GLib.GType gtype, DrawGlyphItemNativeDelegate callback)
		{
			PangoRendererClass class_iface = GetClassStruct (gtype, false);
			class_iface.DrawGlyphItem = callback;
			OverrideClassStruct (gtype, class_iface);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void DrawGlyphItemNativeDelegate (IntPtr inst, IntPtr text, IntPtr glyph_item, int x, int y);

		static void DrawGlyphItem_cb (IntPtr inst, IntPtr text, IntPtr glyph_item, int x, int y)
		{
			try {
				Renderer __obj = GLib.Object.GetObject (inst, false) as Renderer;
				__obj.OnDrawGlyphItem (GLib.Marshaller.Utf8PtrToString (text), Pango.GlyphItem.New (glyph_item), x, y);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Pango.Renderer), ConnectionMethod="OverrideDrawGlyphItem")]
		protected virtual void OnDrawGlyphItem (string text, Pango.GlyphItem glyph_item, int x, int y)
		{
			InternalDrawGlyphItem (text, glyph_item, x, y);
		}

		private void InternalDrawGlyphItem (string text, Pango.GlyphItem glyph_item, int x, int y)
		{
			DrawGlyphItemNativeDelegate unmanaged = GetClassStruct (this.LookupGType ().GetThresholdType (), true).DrawGlyphItem;
			if (unmanaged == null) return;

			IntPtr native_text = GLib.Marshaller.StringToPtrGStrdup (text);
			IntPtr native_glyph_item = GLib.Marshaller.StructureToPtrAlloc (glyph_item);
			unmanaged (this.Handle, native_text, native_glyph_item, x, y);
			GLib.Marshaller.Free (native_text);
			Marshal.FreeHGlobal (native_glyph_item);
		}

		[StructLayout (LayoutKind.Sequential)]
		struct PangoRendererClass {
			public DrawGlyphsNativeDelegate DrawGlyphs;
			public DrawRectangleNativeDelegate DrawRectangle;
			public DrawErrorUnderlineNativeDelegate DrawErrorUnderline;
			public DrawShapeNativeDelegate DrawShape;
			public DrawTrapezoidNativeDelegate DrawTrapezoid;
			public DrawGlyphNativeDelegate DrawGlyph;
			public PartChangedNativeDelegate PartChanged;
			public BeginNativeDelegate Begin;
			public EndNativeDelegate End;
			public PrepareRunNativeDelegate PrepareRun;
			public DrawGlyphItemNativeDelegate DrawGlyphItem;
			IntPtr PangoReserved2;
			IntPtr PangoReserved3;
			IntPtr PangoReserved4;
		}

		static uint class_offset = ((GLib.GType) typeof (GLib.Object)).GetClassSize ();
		static Dictionary<GLib.GType, PangoRendererClass> class_structs;

		static PangoRendererClass GetClassStruct (GLib.GType gtype, bool use_cache)
		{
			if (class_structs == null)
				class_structs = new Dictionary<GLib.GType, PangoRendererClass> ();

			if (use_cache && class_structs.ContainsKey (gtype))
				return class_structs [gtype];
			else {
				IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
				PangoRendererClass class_struct = (PangoRendererClass) Marshal.PtrToStructure (class_ptr, typeof (PangoRendererClass));
				if (use_cache)
					class_structs.Add (gtype, class_struct);
				return class_struct;
			}
		}

		static void OverrideClassStruct (GLib.GType gtype, PangoRendererClass class_struct)
		{
			IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
			Marshal.StructureToPtr (class_struct, class_ptr, false);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_activate(IntPtr raw);

		public void Activate() {
			pango_renderer_activate(Handle);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_deactivate(IntPtr raw);

		public void Deactivate() {
			pango_renderer_deactivate(Handle);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_draw_error_underline(IntPtr raw, int x, int y, int width, int height);

		public void DrawErrorUnderline(int x, int y, int width, int height) {
			pango_renderer_draw_error_underline(Handle, x, y, width, height);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_draw_glyph(IntPtr raw, IntPtr font, uint glyph, double x, double y);

		public void DrawGlyph(Pango.Font font, uint glyph, double x, double y) {
			pango_renderer_draw_glyph(Handle, font == null ? IntPtr.Zero : font.Handle, glyph, x, y);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_draw_glyph_item(IntPtr raw, IntPtr text, IntPtr glyph_item, int x, int y);

		public void DrawGlyphItem(string text, Pango.GlyphItem glyph_item, int x, int y) {
			IntPtr native_text = GLib.Marshaller.StringToPtrGStrdup (text);
			IntPtr native_glyph_item = GLib.Marshaller.StructureToPtrAlloc (glyph_item);
			pango_renderer_draw_glyph_item(Handle, native_text, native_glyph_item, x, y);
			GLib.Marshaller.Free (native_text);
			Marshal.FreeHGlobal (native_glyph_item);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_draw_glyphs(IntPtr raw, IntPtr font, IntPtr glyphs, int x, int y);

		public void DrawGlyphs(Pango.Font font, Pango.GlyphString glyphs, int x, int y) {
			pango_renderer_draw_glyphs(Handle, font == null ? IntPtr.Zero : font.Handle, glyphs == null ? IntPtr.Zero : glyphs.Handle, x, y);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_draw_layout(IntPtr raw, IntPtr layout, int x, int y);

		public void DrawLayout(Pango.Layout layout, int x, int y) {
			pango_renderer_draw_layout(Handle, layout == null ? IntPtr.Zero : layout.Handle, x, y);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_draw_layout_line(IntPtr raw, IntPtr line, int x, int y);

		public void DrawLayoutLine(Pango.LayoutLine line, int x, int y) {
			pango_renderer_draw_layout_line(Handle, line == null ? IntPtr.Zero : line.Handle, x, y);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_draw_rectangle(IntPtr raw, int part, int x, int y, int width, int height);

		public void DrawRectangle(Pango.RenderPart part, int x, int y, int width, int height) {
			pango_renderer_draw_rectangle(Handle, (int) part, x, y, width, height);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_draw_trapezoid(IntPtr raw, int part, double y1_, double x11, double x21, double y2, double x12, double x22);

		public void DrawTrapezoid(Pango.RenderPart part, double y1_, double x11, double x21, double y2, double x12, double x22) {
			pango_renderer_draw_trapezoid(Handle, (int) part, y1_, x11, x21, y2, x12, x22);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern ushort pango_renderer_get_alpha(IntPtr raw, int part);

		public ushort GetAlpha(Pango.RenderPart part) {
			ushort raw_ret = pango_renderer_get_alpha(Handle, (int) part);
			ushort ret = raw_ret;
			return ret;
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr pango_renderer_get_color(IntPtr raw, int part);

		public Pango.Color GetColor(Pango.RenderPart part) {
			IntPtr raw_ret = pango_renderer_get_color(Handle, (int) part);
			Pango.Color ret = Pango.Color.New (raw_ret);
			return ret;
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr pango_renderer_get_layout(IntPtr raw);

		public Pango.Layout Layout { 
			get {
				IntPtr raw_ret = pango_renderer_get_layout(Handle);
				Pango.Layout ret = GLib.Object.GetObject(raw_ret) as Pango.Layout;
				return ret;
			}
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr pango_renderer_get_layout_line(IntPtr raw);

		public Pango.LayoutLine LayoutLine { 
			get {
				IntPtr raw_ret = pango_renderer_get_layout_line(Handle);
				Pango.LayoutLine ret = raw_ret == IntPtr.Zero ? null : (Pango.LayoutLine) GLib.Opaque.GetOpaque (raw_ret, typeof (Pango.LayoutLine), false);
				return ret;
			}
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr pango_renderer_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = pango_renderer_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_part_changed(IntPtr raw, int part);

		public void PartChanged(Pango.RenderPart part) {
			pango_renderer_part_changed(Handle, (int) part);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_set_alpha(IntPtr raw, int part, ushort alpha);

		public void SetAlpha(Pango.RenderPart part, ushort alpha) {
			pango_renderer_set_alpha(Handle, (int) part, alpha);
		}

		[DllImport("libpango-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void pango_renderer_set_color(IntPtr raw, int part, IntPtr color);

		public void SetColor(Pango.RenderPart part, Pango.Color color) {
			IntPtr native_color = GLib.Marshaller.StructureToPtrAlloc (color);
			pango_renderer_set_color(Handle, (int) part, native_color);
			Marshal.FreeHGlobal (native_color);
		}

#endregion
	}
}
