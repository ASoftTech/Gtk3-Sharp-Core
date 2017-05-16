#!/usr/bin/env python2
import os, sys, shutil, glob
import os.path as path

# Code and settings common between different libs
class GlueCommon(object):

    # Class Init
    def __init__(self):
        self.Test1 = "Test1"