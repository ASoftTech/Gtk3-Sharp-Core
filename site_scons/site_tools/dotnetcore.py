#!python

# Tool helper script for building .Net Core projects using the .Net Core cli tool

import os, sys, subprocess
import os.path as path
from SCons.Script import *

# If Tool exists
def exists(env): return True

# Called when the tool is loaded into the environment at startup of script
def generate(env):
    assert(exists(env))
    # Default dotnet builder
    # 1. target = list filepath's expected to be created  
    # 2. source = path to project file
    bld = Builder(action = dotnetcore_build)
    env.Append(BUILDERS = {'DotNetCore' : bld})
    # Dll dotnet builder
    # 1. target[0] = build directory  
    # 2. source = path to project file
    bld = Builder(action = dotnetcore_build, emitter = dotnetcore_dll_targets)
    env.Append(BUILDERS = {'DotNetCore_Dll' : bld})

# Called during the build of the target
def dotnetcore_build(target, source, env):
    workingdir = os.getcwd()
    for item in source:
        srcpath = item.abspath
        run_cmd(['dotnet', 'restore', srcpath], workingdir)
        run_cmd(['dotnet', 'build', srcpath], workingdir)
    return None

# Assume target[0] is the build directory
# The returned targets assumes a dll is being built
def dotnetcore_dll_targets(target, source, env):
    builddir = target[0].abspath
    for item in source:
        projname = path.basename(item.abspath)
        projname = os.path.splitext(projname)[0]
        tgts = []
        tgts.append(File(path.join(builddir, projname + '.dll')))
        tgts.append(File(path.join(builddir, projname + '.deps.json')))
        tgts.append(File(path.join(builddir, projname + '.pdb')))
    return tgts, source

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
