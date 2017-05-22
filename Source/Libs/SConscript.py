#!/usr/bin/env python2
import SCons.Script
from SCons.Environment import Environment

import os
import os.path as path

from dotnetcore_helper import DotNetCoreHelper

# Setup environment
Import('env')
parentenv = env
env = parentenv.Clone(tools = ['default', 'dotnetcore'])

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
