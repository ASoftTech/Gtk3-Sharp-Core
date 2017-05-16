#!/usr/bin/env python2

import os, sys, shutil, glob
import os.path as path
from SCons.Script import *



def print_build_targets():
    print("START *************** BUILD_TARGETS")
    for item in BUILD_TARGETS:
        print(item)
    print("END *************** BUILD_TARGETS")

def print_cmdline_targets():
    print("START *************** COMMAND_LINE_TARGETS")
    for item in COMMAND_LINE_TARGETS:
        print(item)
    print("END *************** COMMAND_LINE_TARGETS")

def print_default_targets():
    print("START *************** DEFAULT_TARGETS")
    for item in DEFAULT_TARGETS:
        print(item)
    print("END *************** DEFAULT_TARGETS")

