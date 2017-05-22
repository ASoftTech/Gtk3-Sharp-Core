#!/usr/bin/env python2
import SCons.Script
from SCons.Environment import Environment

import os
import os.path as path
from dotnetcore_helper import DotNetCoreHelper

Import('env', 'vars')
parentenv = env
env = parentenv.Clone(tools = ['default', 'dotnetcore'])




vars.Add(EnumVariable('mode', 'Building mode', 'debug', allowed_values=('debug', 'profile', 'release')))
vars.Update(env)
Help(vars.GenerateHelpText(env))




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





#  * --output : Use env['BuildDir']
#  * --version-suffix: Use env['BuildVersion']

#  * --configuration : variable: dotnet_configuration = 'Debug'
#  * additional dotnet build options: varable: dotnet_additional = ''

#TODO
#  * Set the build output directory to default in the csproj file
#  * Is there a way of compiling for x32 / x64 explicitly
#  * Incorperate above options into build command
#  * Cleanup dotnet builder class