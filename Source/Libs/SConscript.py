#!/usr/bin/env python2

# These import lines are not really needed, but it helps intellisense within VS when editing the script
import SCons.Script
from SCons.Environment import Environment

import os
import os.path as path
from dotnetcore_helper import DotNetCoreHelper

env = Environment(ENV = os.environ, tools = ['default', 'dotnetcore'])

builddir = path.join(Dir('#').abspath, 'Build/LibBuild/dotnet/netstandard2.0')
builddir = path.abspath(builddir)
print(".Net Build Directory: " + builddir)

projdirs = [
    'Atk',
    'Cairo',
    'Gdk',
    'Gio',
    'GLib',
    'Gtk',
    'Gtk.DotNet',
    'Pango',
    ]

for item in projdirs:
    projdir = path.join(Dir('.').abspath, item)
    proj = DotNetCoreHelper(projdir = projdir, builddir = builddir)
    csbuild = env.DotNetCore(proj.get_buildfiles(), proj.get_sources())
    Default(csbuild)
