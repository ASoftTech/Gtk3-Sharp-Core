#!/usr/bin/env python2
from SCons.Script import *
from SCons.Environment import Environment

import os
import os.path as path

"""
opts_common
  Common options such as build directory, storage of build variables
"""

def setup_opts(env):

    Help("""
Common Options:
  -h                          Show this help
  -c                          Clean the build

  --builddir=DIR              Specify the Build Directory
  --config-save               Save any build variables such as variable=value to config.py
  --config-list               List the saved build variables
  --config-delete             Delete the config.py file within the build directory
""")

    # Check for the Build directory option
    AddOption('--builddir', dest='builddir', default=Dir('#/Build').abspath, 
        type='string', nargs='?', action='store', metavar='DIR', help='Specify the Build Directory')
    builddir = GetOption('builddir')
    env.Replace(common_builddir = builddir)
    if not path.exists(builddir):
        os.makedirs(builddir)

    cfgpath = path.join(env['common_builddir'], 'config.py')

    # List configuration variables that have been set
    AddOption('--config-list', dest='config-list', action="store_true", help='List the saved build variables')
    if GetOption('config-list'):
        print('Configuration variables set:')
        if path.exists(cfgpath):
            with open(cfgpath) as f:
                for line in f.readlines():
                    print('    ' + line.strip())
        Exit(0)

    # Check if we need to remove the build variables file
    AddOption('--config-delete', dest='config-delete', action="store_true", help='Clears the saved build variables')
    if GetOption('config-delete'):
        if path.exists(cfgpath):
            print('Removing Configuration: ' + cfgpath)
            os.remove(cfgpath)
        Exit(0)

def setup_vars(env, vars):
    vars.Add('common_buildversion', 'version to use for build', '3.22.10')
    vars.Update(env)
    return vars

def check_save(env, vars):
    """
    Check if we need to save the configuration build variables, variable=value
    """
    cfgpath = path.join(env['common_builddir'], 'config.py')
    AddOption('--config-save', dest='config-save', action="store_true", help='Save the specified build variables to config.py within the build directory')
    if GetOption('config-save'):
        print('Saving Configuration: ' + cfgpath)
        vars.Save(cfgpath, env)
        Exit(0)
