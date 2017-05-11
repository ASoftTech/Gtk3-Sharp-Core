#! python3
import os, sys, subprocess, shutil, json
import wget, tarfile, glob, patch, logging, shutil 
import os.path as path

from lib.common import Common
from lib.codegen import CodeGen, CodeGen_Runner
from lib.fixer import Fixer

# GtkSharp Build Script
class Generator(object):

    # Class Init
    def __init__(self):
        self.GeneratorDir = "../Build/Generator/"
        self.ParserDir = "../Build/Parser/"
        self.MetaDir = "../Source/Metadata/"
        self.SrcsDir = "../Source/"

        self.BaseDir = path.dirname(path.abspath(__file__))
        self.GeneratorDir = path.abspath(path.join(self.BaseDir, self.GeneratorDir))
        self.ParserDir = path.abspath(path.join(self.BaseDir, self.ParserDir))
        self.MetaDir = path.abspath(path.join(self.BaseDir, self.MetaDir))
        self.SrcsDir = path.abspath(path.join(self.BaseDir, self.SrcsDir))

    # Clean the Build/Generator directory
    def clean(self):
        Common.clean(self.GeneratorDir)

    def buildgen(self):
        print("Building the .Net Generator")

        buildir = path.join(self.BaseDir, 'generator', 'GtkSharp.CodeFixup')
        cmdargs = ['dotnet', 'restore', 'GtkSharp.CodeFixup.csproj']
        Common.run_cmd(cmdargs, buildir)
        cmdargs = ['dotnet', 'build', 'GtkSharp.CodeFixup.csproj']
        Common.run_cmd(cmdargs, buildir)

        buildir = path.join(self.BaseDir, 'generator', 'GtkSharp.CodeGen')
        cmdargs = ['dotnet', 'restore', 'GtkSharp.CodeGen.csproj']
        Common.run_cmd(cmdargs, buildir)
        cmdargs = ['dotnet', 'build', 'GtkSharp.CodeGen.csproj']
        Common.run_cmd(cmdargs, buildir)

    # Fixup the .raw files output from the parser
    def fixup(self):
        xmlfixer = Fixer(self.GeneratorDir, self.ParserDir, self.MetaDir)
        xmlfixer.run()

    # Generate sources from the .xml files from the parser
    def generate(self):
        shutil.copy(path.join(self.MetaDir, 'gapi.xsd'), self.GeneratorDir)
        runner = CodeGen_Runner(self.GeneratorDir, self.MetaDir, self.SrcsDir)
        runner.run()
        print("Code generation finished")

    # Copy all files to source directory
    def copy(self):
        runner = CodeGen_Runner(self.GeneratorDir, self.MetaDir, self.SrcsDir)
        runner.copyfiles()
        print("Copy files finished")

    # Print Usage
    def usage(self):
        print ("Please use generator.py <target> where <target> is one of")
        print ("  clean          clean the Build/Generator directory")
        print ("  buildgen       build the .Net code for the generator")
        print ("  fixup          fixup the .raw files output from the parser")
        print ("  generate       generate sources from the .raw files from the fixed raw files")
        print ("  copy           copy all files to source directory")
        print ("  all            perform all steps")

    def main(self):
        if len(sys.argv) != 2:
            self.usage()
            return
        if sys.argv[1] == "clean":
            self.clean()
        if sys.argv[1] == "buildgen":
            self.buildgen()
        if sys.argv[1] == "fixup":
            self.fixup()
        if sys.argv[1] == "generate":
            self.generate()
        if sys.argv[1] == "copy":
            self.copy()
        if sys.argv[1] == "all":
            self.clean()
            self.buildgen()
            self.fixup()
            self.generate()
            self.copy()

if __name__ == "__main__":
    Generator().main()
