#!/usr/bin/env python2

# Tool helper script for building .Net Core projects using the .Net Core cli tool

import os, sys, subprocess
import os.path as path
from SCons.Script import *

# If Tool exists
def exists(env): return True

# Called when the tool is loaded into the environment at startup of script
def generate(env):
    assert(exists(env))
    # dotnet builder
    # 1. target = list of targets, e.g. .dll, .pdb, .deps.json
    # 2. source = list of sources including the .csproj file which is actually used
    bld = Builder(action = dotnetcore_build)
    env.Append(BUILDERS = {'DotNetCore' : bld})

# Called during the build of the target
def dotnetcore_build(target, source, env):
    # scons root directory
    workingdir = Dir('#').abspath

    # Find the .csproj file
    for item in source:
        if path.splitext(item.abspath)[1] == '.csproj':
            projfile = item.abspath
            break

    run_cmd(['dotnet', 'restore', projfile], workingdir)
    run_cmd(['dotnet', 'build', projfile], workingdir)
    return None

# Used to run a command
def run_cmd(cmdarray, workingdir, stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=None, printresult=True):
    proc = subprocess.Popen(cmdarray, cwd=workingdir, stdout=stdout, stderr=stderr, stdin=stdin, universal_newlines=True)
    proc_out, proc_err = proc.communicate()
    if printresult:
        print(proc_out)
        print(proc_err)
    if proc.returncode != 0:
        raise RuntimeError("Failure to run command")
    return proc_out, proc_err
