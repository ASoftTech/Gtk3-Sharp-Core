#!python

# These import lines are not really needed, but it helps intellisense within VS when editing the script
import SCons.Script
from SCons.Environment import Environment

import os
import os.path as path

env = Environment(ENV = os.environ, tools = ['default', 'dotnetcore'], toolpath = ['../../site_scons/site_tools'])

projs = [
'Atk/Atk.csproj',
'Cairo/Cairo.csproj',
'Gdk/Gdk.csproj',
'Gio/Gio.csproj',
'GLib/GLib.csproj',
'Gtk/Gtk.csproj',
'Gtk.DotNet/Gtk.DotNet.csproj',
'Pango/Pango.csproj']

builddir = '../../Build/LibBuild/dotnet/netstandard2.0'
builddir = path.abspath(builddir)
basedir = os.getcwd()

for item in projs:
    src = path.join(basedir, item)
    src = path.abspath(src)
    csbuild = env.DotNetCore_Dll(Dir(builddir), src)
    Default(csbuild)
