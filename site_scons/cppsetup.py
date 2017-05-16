#!/usr/bin/env python2
import SCons.Script
from SCons.Environment import Environment

import os, sys, shutil, glob
import os.path as path

# Common settings for C / C++ Projects
class CPPSetup(object):

    # Class Init
    def __init__(self, env):
        self.env = env
        self.SourcesDir = path.join(self.env.Dir('#').abspath, 'Build', 'Sources')

        self.GCC_CFlags = "-g -Wall -Wunused -Wmissing-prototypes -Wmissing-declarations -Wstrict-prototypes"
        self.GCC_CFlags += "-Wnested-externs  -Wshadow -Wpointer-arith -Wno-cast-qual -Wcast-align -Wwrite-strings"

    def test1(self):
        print(self.env['CC'])
        print(self.env['CXX'])


    def get_includedirs(self):
        ret = []
        # Microsoft compiler
        if self.env['CC'] == 'cl':
            print("Test MS")

        elif self.env['CC'] == 'gcc':
            print("Test Linux")

        #ret.append(Dir)