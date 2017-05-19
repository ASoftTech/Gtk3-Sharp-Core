#!/usr/bin/env python2
import SCons.Script
from SCons.Environment import Environment

import os, glob
import os.path as path


# Helper code for .NEt Core projects
class DotNetCoreHelper(object):

    # Class Init
    def __init__(self, projfile = None, projdir = '.', builddir = '.'):
        self.ProjectFile = projfile
        self.ProjectDir = projdir
        self.BuildDir = builddir
        if self.ProjectFile == None:
            self.get_project_file()
        self.CSFiles = []
        self.ProjectName = path.splitext(path.basename(self.ProjectFile))[0]

    # Find the first .csproj file in the directory if one isn't specified
    def get_project_file(self):
        projfiles = self.search_files('.csproj')
        self.ProjectFile = projfiles[0]

    # Get a list of source files for the dotnet builder tool
    # The csproj file actually handles the build.
    # But we track all .cs files as source inputs to the builder
    # so that we know if to rebuild if one of them changes
    def get_cs_files(self):
        self.CSFiles = self.search_files('.cs')
        return self.CSFiles

    def get_sources(self):
        self.get_cs_files()
        return [self.ProjectFile] + self.CSFiles

    def get_buildfiles(self):
        ret = []
        ret.append(path.join(self.BuildDir, self.ProjectName + '.dll'))
        ret.append(path.join(self.BuildDir, self.ProjectName + '.deps.json'))
        ret.append(path.join(self.BuildDir, self.ProjectName + '.pdb'))
        return ret

    # Find files recursively by extension
    def search_files(self, find_ext):
        ret = []
        for root, directories, filenames in os.walk(self.ProjectDir):
            for filename in filenames:
                filepath = path.join(root,filename)
                name, ext = path.splitext(filename)
                if ext != find_ext:
                    continue
                pathsplit = root.split(os.sep)
                if len(pathsplit) > 1 and pathsplit[1] == 'obj':
                    continue
                ret.append(filepath)
        return ret
