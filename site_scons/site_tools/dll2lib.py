#!/usr/bin/env python2

"""
Dll2Lib
  This tool will generate a .lib file under windows for a given .dll file
  This uses dumpfile to export a list of symbols
      dumpbin /exports C:\yourpath\yourlib.dll
  The list of symbols is then written to a .def file
  The lib command is then used to generate the .lib file from the .def file
      lib /def:C:\mypath\mylib.def /OUT:C:\mypath\mylib.lib
  A side affect of this is an .exp file which also requires cleanup
  We can then use the .lib file for linking with the compiler under Windows
"""

import os, sys, subprocess
import os.path as path
from SCons.Script import *

def exists(env):
    """
    For use with Windows only
    """
    if env['PLATFORM'] == 'win32':
        return True
    return False

def generate(env):
    """
    Called when the tool is loaded into the environment at startup of script
    """
    assert(exists(env))
    bld = Builder(action = dll2lib_build, emitter = dll2lib_modify_targets)
    env.Append(BUILDERS = {'Dll2Lib' : bld})

def dll2lib_build(target, source, env):
    """
    Called during the build of the target
    """
    index = 0
    # Parse list of dll's
    for item in source:
        srcfile = item.abspath
        libfile = target[index].abspath
        deffile = path.splitext(libfile)[0] + '.def'
        if path.splitext(srcfile)[1] != '.dll':
            continue
        dumpout = run_dumpbin_exports(srcfile)
        exportlist = parse_dumpbin_output(dumpout)
        write_deffile(deffile, exportlist)
        generate_lib(deffile, libfile)

def dll2lib_modify_targets(target, source, env):
    """
    Add the generated .def and .exp files to the list of targerts for cleanup
    """
    for item in target:
        libfile = item.abspath
        deffile = path.splitext(libfile)[0] + '.def'
        expfile = path.splitext(libfile)[0] + '.exp'
        target.append(deffile)
        target.append(expfile)
    return target, source

def run_dumpbin_exports(dllfile):
    """
    Run dumpbin /exports against the input dll
    """
    workingdir = Dir('#').abspath
    cmdargs = ['dumpbin', '/exports', dllfile]
    proc_out, proc_err = run_cmd(cmdargs, workingdir)
    return proc_out

def parse_dumpbin_output(input):
    """
    Parse thr output from dumpbin as a list of symbols
    """
    ret = []
    lines = input.split('\n')
    for line in lines:
        arr1 = line.split()
        if len(arr1) == 4 and arr1[1] != 'number' and arr1[1] != 'hint':
            ret.append(arr1[3])
    return ret

def write_deffile(outfile, lines):
    """
    Write the list of symbols to a .def file
    """
    with open(outfile, 'w') as f:
        f.write('EXPORTS\n')
        for line in lines:
            f.write(line + '\n')

def generate_lib(deffile, libfile):
    """
    Generate the .lib file
    """
    workingdir = Dir('#').abspath
    cmdargs = ['lib']
    cmdargs.append('/def:' + deffile)
    cmdargs.append('/OUT:' + libfile)
    proc_out, proc_err = run_cmd(cmdargs, workingdir)
    return proc_out

def run_cmd(cmdarray, workingdir, stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=None, printresult=True):
    """
    Used to run a command
    """
    proc = subprocess.Popen(cmdarray, cwd=workingdir, stdout=stdout, stderr=stderr, stdin=stdin, universal_newlines=True)
    proc_out, proc_err = proc.communicate()
    if printresult:
        print(proc_out)
        print(proc_err)
    if proc.returncode != 0:
        raise RuntimeError("Failure to run command")
    return proc_out, proc_err
