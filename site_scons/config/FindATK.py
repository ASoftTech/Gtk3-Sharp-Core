#!/usr/bin/env python2

from SCons.Script import *

# Find the ATK Library
# conf = the Scons SConf configure context
# hints = additional list of directories / paths to search

class FindATK(object):

    # Class Init
    def __init__(self, conf, hints=[]):
        self.conf = conf
        self.ATK_INCLUDE_DIRS = []
        self.ATK_LIBRARIES = []
        conf.AddTests({
            'FindATK' : self.run_FindATK,
            'FindAtk_Headers' : self.run_FindATK})

    def run_FindATK(self, context):
        context.Message("Searching for Atk... ")

        # TODO
        # Path_SUFFIXES specified additional subdirectories to search below each search path

        context.Message("Searching for atk/atk.h")
        if not FindFile('atk/atk.h', includedirs):
            context.Result("No header found")
            return self
        context.Result("Yes")

        return self

     #def find_includes(self):
