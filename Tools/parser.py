#!/usr/bin/env python3
import os, sys, shutil, glob
import os.path as path

from lib.common import Common
from lib.gen_keysyms import Gen_Keysyms
from lib.api_parser import Api_Parser

# GtkSharp Build Script
class Parser(object):

    # Class Init
    def __init__(self):
        self.SrcXmlFile = "parser/sources.xml"
        self.SrcsDir = "../Build/Sources/"
        self.ParserDir = "../Build/Parser/"
        self.CSharpSrcs = "../Source/Libs/"

        self.BaseDir = path.dirname(path.abspath(__file__))
        self.SrcXmlFile = path.abspath(path.join(self.BaseDir, self.SrcXmlFile))
        self.SrcsDir = path.abspath(path.join(self.BaseDir, self.SrcsDir))
        self.ParserDir = path.abspath(path.join(self.BaseDir, self.ParserDir))
        self.CSharpSrcs = path.abspath(path.join(self.BaseDir, self.CSharpSrcs))

    # Clean the Parser directory
    def clean(self):
        Common.clean(self.ParserDir)

    # Generate the C# enum for Gdk
    def gen_keysyms(self):
        src_dir = ""
        glob1 = glob.glob(path.join(self.SrcsDir, "gtk+-*"))
        for item in glob1:
            if os.path.isdir(item): src_dir = item
        srcfile = path.join(src_dir, "gdk", "gdkkeysyms.h")
        destfile = path.join(self.ParserDir, "Key.cs")
        if not path.exists(self.ParserDir):
            os.makedirs(self.ParserDir)
        keysyms = Gen_Keysyms(srcfile, destfile)
        keysyms.parse()
        shutil.copyfile(destfile, path.join(self.CSharpSrcs, "Gdk/Key.cs"))

    # Generates raw xml files needed for the code generator
    def parse(self):
        parser = Api_Parser(self.SrcXmlFile, self.SrcsDir, self.ParserDir)
        parser.readxml()
        parser.process_ns()

    # Print Usage
    def usage(self):
        print ("Please use parser.py <target> where <target> is one of")
        print ("  clean          clean the parser directory")
        print ("  gen_keysyms    Generates a C# Key enum from the Gdk headers (gdkkeysyms.h)")
        print ("  parse          Generates raw xml files needed for the code generator")
        print ("  all            clean, download, extract, patch the sources")

    def main(self):
        if len(sys.argv) != 2:
            self.usage()
            return
        if sys.argv[1] == "clean":
            self.clean()
        if sys.argv[1] == "gen_keysyms":
            self.gen_keysyms()
        if sys.argv[1] == "parse":
            self.parse()
        if sys.argv[1] == "all":
            self.clean()
            self.gen_keysyms()
            self.parse()

if __name__ == "__main__":
    Parser().main()
