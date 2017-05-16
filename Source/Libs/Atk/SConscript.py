#!/usr/bin/env python2

# These import lines are not really needed, but it helps intellisense within VS when editing the script
import SCons.Script
from SCons.Environment import Environment

from dotnetcore_helper import DotNetCoreHelper

import os
import os.path as path

Import('builddir')
env = Environment(ENV = os.environ, tools = ['default', 'dotnetcore'])

proj = DotNetCoreHelper(builddir = builddir)
csbuild = env.DotNetCore(proj.get_buildfiles(), proj.get_sources())
Default(csbuild)
