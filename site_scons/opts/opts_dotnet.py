#!/usr/bin/env python2
from SCons.Script import *
from SCons.Environment import Environment

import os
import os.path as path

"""
opts_dotnet
  Options for dotnet core projects
"""

def setup_vars(env, vars):

    Help("""
Dotnet Core Options:
""")
    # Build directory to use
    dotnet_builddir = path.join(env['common_builddir'], 'SourceBuild', 'dotnet')
    vars.Add('dotnet_builddir', 'Build directory for .Net', dotnet_builddir)
    
    # If to build Debug or Release
    vars.Add(EnumVariable('dotnet_config', 'Building mode', 'Debug', allowed_values=('Debug', 'Release')))

    # Additional Build options
    vars.Add('dotnet_extra', 'Additional options to pass to dotnet during the build', None)

    vars.Update(env)
    return vars


#  * --output : Use env['dotnet_builddir']
#  * --version-suffix: Use env['BuildVersion']

#  * --configuration : variable: dotnet_configuration = 'Debug'
#  * additional dotnet build options: varable: dotnet_additional = ''

#TODO
#  * Set the build output directory to default in the csproj file
#  * Is there a way of compiling for x32 / x64 explicitly
#  * Incorperate above options into build command
#  * Cleanup dotnet builder class