#!/usr/bin/env python2

# These import lines are not really needed, but it helps intellisense within VS when editing the script
import SCons.Script
from SCons.Environment import Environment

import os
import os.path as path

#from ......site_tools.glue_common import GlueCommon


env = Environment(ENV = os.environ, tools = ['default'], toolpath = ['../../../site_scons'])

from glue_common import GlueCommon

x1 = GlueCommon()
print(x1.Test1)


#object_list = Object('test1/hello1.cpp')
#program_list = Program(object_list)
#print "The object file is:", object_list[0]
#print "The program file is:", program_list[0]
#print ("buildpath = " + env.GetBuildPath(object_list[0]))


# For a more detailed / cross platform build script see
# https://bitbucket.org/scons/scons/wiki/AllInSConstruct

## Add the Debug Flags if debug=1 is specified on the command line, this tends to be compiler specific
#if ARGUMENTS.get('debug', 0):
#    env.Append(CPPDEFINES = ['DEBUG', '_DEBUG'])
#    env.Append(CCFLAGS='/MDd')
#    env.Append(CCFLAGS=Split('/Zi /Fd${TARGET}.pdb'))
#    env.Append(LINKFLAGS = ['/DEBUG'])
#    variant = 'Debug'
#else:
#    env.Append(CPPDEFINES = ['NDEBUG'])
#    variant = 'Release'
#print "Building: " + variant

# TODO
srcs = ['generated.c', 'misc.c', 'util.c', 'win32dll.c']
gluelib = SharedLibrary('atksharpglue', srcs, SHLIBVERSION=3)
Default(gluelib)