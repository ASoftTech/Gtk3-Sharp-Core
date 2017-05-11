#!python

# These import lines are not really needed, but it helps intellisense within VS when editing the script
import SCons.Script
from SCons.Environment import Environment

import os
import os.path as path

env = Environment(ENV = os.environ)

# Build C# Libs
#SConscript('Source/Libs/SConstruct.py')

# Build Glue Libs
SConscript('Source/Libs-Glue/SConstruct.py')
