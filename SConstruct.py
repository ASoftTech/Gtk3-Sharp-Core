#!/usr/bin/env python2

# These import lines are not really needed, but it helps intellisense within VS when editing the script
import SCons.Script
from SCons.Environment import Environment

import os
import os.path as path
import opts.opts_common

env = Environment(ENV = os.environ)

# Check version of scons
EnsureSConsVersion(2,5,1)

# Setup common options
opts.opts_common.setup_opts(env)

# Create a variables class for any additional option=value on the command line
vars = Variables(path.join(env['BuildDir'], 'config.py'), ARGUMENTS)
Export('env', 'vars')

# Build C# Libs
SConscript('Source/Libs/SConscript.py')

# Build Glue Libs
#SConscript('Source/Libs-Glue/SConscript.py')

# Check if we need to save the build variables
opts.opts_common.check_save(env, vars)
