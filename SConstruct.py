#!/usr/bin/env python2

# These import lines are not really needed, but it helps intellisense within VS when editing the script
import SCons.Script
from SCons.Environment import Environment

import os
import os.path as path
import opts.opts_common
import opts.opts_dotnet

# Setup environment
env = Environment(ENV = os.environ)

# Check version of scons
EnsureSConsVersion(2,5,1)

# Setup options
opts.opts_common.setup_opts(env)

# Setup variables
vars = Variables(path.join(env['common_builddir'], 'config.py'), ARGUMENTS)
vars = opts.opts_common.setup_vars(env, vars)
vars = opts.opts_dotnet.setup_vars(env, vars)
Help(vars.GenerateHelpText(env))

Export('env')

# Build C# Libs
SConscript('Source/Libs/SConscript.py')

# Build Glue Libs
#SConscript('Source/Libs-Glue/SConscript.py')

# Check if we need to save the build variables
opts.opts_common.check_save(env, vars)
