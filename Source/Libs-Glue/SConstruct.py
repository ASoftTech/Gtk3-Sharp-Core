#!python

# These import lines are not really needed, but it helps intellisense within VS when editing the script
import SCons.Script
from SCons.Environment import Environment

import os.path as path

builddir = '../../Build/LibBuild/glue'
builddir = path.abspath(builddir)
print("Glue Build Directory: " + builddir)

SConscript('Atk.Glue/SConstruct.py', variant_dir=builddir, duplicate=0)
#SConscript('Gio.Glue/SConscript', variant_dir=builddir, duplicate=0)
#SConscript('Gtk.Glue/SConscript', variant_dir=builddir, duplicate=0)
#SConscript('Pango.Glue/SConscript', variant_dir=builddir, duplicate=0)
Default(builddir)
