#!/usr/bin/env python2

# These import lines are not really needed, but it helps intellisense within VS when editing the script
import SCons.Script
from SCons.Environment import Environment

import os.path as path

builddir = path.join(Dir('#').abspath, 'Build/LibBuild/dotnet/netstandard2.0')
builddir = path.abspath(builddir)
print(".Net Build Directory: " + builddir)

SConscript('Atk/SConscript.py', exports='builddir')
SConscript('Cairo/SConscript.py', exports='builddir')
SConscript('Gdk/SConscript.py', exports='builddir')
SConscript('Gio/SConscript.py', exports='builddir')
SConscript('GLib/SConscript.py', exports='builddir')
SConscript('Gtk/SConscript.py', exports='builddir')
SConscript('Gtk.DotNet/SConscript.py', exports='builddir')
SConscript('Pango/SConscript.py', exports='builddir')
