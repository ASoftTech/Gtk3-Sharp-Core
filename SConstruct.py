#!/usr/bin/env python2

# These import lines are not really needed, but it helps intellisense within VS when editing the script
import SCons.Script
from SCons.Environment import Environment

import os
import os.path as path

#TODO
# option for gtk directory

# 3 build modes
#vars = Variables()
#vars.Add(EnumVariable('mode', 'Building mode', 'debug', allowed_values=('debug', 'profile', 'release')))

env = Environment(ENV = os.environ)


# Check version of scons
EnsureSConsVersion(2,5,1)

# Build C# Libs
SConscript('Source/Libs/SConscript.py')

# Build Glue Libs
SConscript('Source/Libs-Glue/SConscript.py')
