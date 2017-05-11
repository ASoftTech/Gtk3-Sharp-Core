#! python3
import subprocess, os, glob, shutil
import os.path as path
from lib.common import Common

# GtkSharp Build Script
class Fixer(object):

    # Class Init
    def __init__(self, gendir, parserdir, metadir):
        self.CodeFixup = "../../Build/Generator/bin/netcoreapp2.0/GtkSharp.CodeFixup.dll"
        self.GeneratorDir = gendir
        self.ParserDir = parserdir
        self.MetaDir = metadir

        self.BaseDir = path.dirname(path.abspath(__file__))
        self.CodeFixup = path.abspath(path.join(self.BaseDir, self.CodeFixup))

    # Fixup the .raw files output from the parser
    def run(self):
        if not path.exists(self.GeneratorDir):
            os.makedirs(self.GeneratorDir)

        glob1 = glob.glob(path.join(self.ParserDir, "*.raw"))
        for item in glob1:
            self.run_rawfile(item)
        print("Finished Fixing .xml files")

    # Fixup the .raw files output from the parser
    def run_rawfile(self, item):
        src_base = path.basename(item)
        dest_base = path.splitext(src_base)[0] + ".xml"
        print("Fixing: " + dest_base)
        shutil.copy(item, path.join(self.GeneratorDir, dest_base))
        cmdargs = ['dotnet', self.CodeFixup]
        cmdargs.append('--api=' + path.join(self.GeneratorDir, dest_base))
        metafile = path.join(self.MetaDir, 'meta', dest_base + '.metadata')
        if path.exists(metafile):
            cmdargs.append('--metadata=' + metafile)
        else:
            return
        symbolsfile = path.join(self.MetaDir, 'meta', dest_base + '.symbols')
        if path.exists(symbolsfile):
            cmdargs.append('--symbols=' + symbolsfile)
        Common.run_cmd(cmdargs, self.GeneratorDir)
