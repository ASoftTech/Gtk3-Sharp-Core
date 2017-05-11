#! python3
import subprocess, os, shutil, glob
import os.path as path
from lib.common import Common

class CodeGen_Runner(object):

    # Class Init
    def __init__(self, gendir, metadir, srcs):
        self.GeneratorDir = gendir
        self.MetaDir = metadir
        self.SrcsDir = srcs

    # Empty a directory
    def emptydir(self, top):
        if(top == '/' or top == "\\"): return
        else:
            for root, dirs, files in os.walk(top, topdown=False):
                for name in files:
                    os.remove(path.join(root, name))
                for name in dirs:
                    os.rmdir(path.join(root, name))

    def run(self):
        for item in self.genlist():
            item.generate()

    def copyfiles(self):
        print("Copying generated directory to Source directory")
        for item in self.genlist():
            src = path.join(self.GeneratorDir, item.GenOut.replace('/', os.path.sep))
            destdir = path.join(self.SrcsDir, 'Libs', item.GenOut.replace('/', os.path.sep))
            self.emptydir(destdir)
            if os.path.exists(destdir): os.rmdir(destdir)
            shutil.copytree(src, destdir)

        print("Copying generated glue files across")
        for item in self.genlist():
            if item.GlueOut == '':
                continue
            src = path.join(self.GeneratorDir, item.GlueOut, 'generated.c')
            destdir = path.join(self.SrcsDir, 'Libs-Glue', item.GlueOut, 'src')
            shutil.copy(src, destdir)

        print("Copying xml metadata files across")
        glob1 = glob.glob(path.join(self.GeneratorDir, "*.xml"))
        for item in glob1:
            src = item
            destdir = path.join(self.MetaDir, 'generated')
            shutil.copy(src, destdir)

    def genlist(self):
        ret = []
        gen1 = CodeGen(self.GeneratorDir, 'gio', 'Gio/generated', 'Gio.Glue')
        gen1.ApiIncludes.append(path.join(self.MetaDir, 'includes', 'glib-api.xml'))
        gen1.GlueIncludes.append('gio/gio.h')
        ret.append(gen1)

        gen1 = CodeGen(self.GeneratorDir, 'pango', 'Pango/generated', 'Pango.Glue')
        gen1.ApiIncludes.append(path.join(self.MetaDir, 'includes', 'cairo-api.xml'))
        gen1.GlueIncludes.append('pango/pango.h')
        ret.append(gen1)

        gen1 = CodeGen(self.GeneratorDir, 'atk', 'Atk/generated', 'Atk.Glue')
        gen1.GlueIncludes.append('atk/atk.h')
        ret.append(gen1)

        gen1 = CodeGen(self.GeneratorDir, 'gdk', 'Gdk/generated', '')
        gen1.ApiIncludes.append(path.join(self.MetaDir, 'includes', 'glib-api.xml'))
        gen1.ApiIncludes.append(path.join(self.MetaDir, 'includes', 'cairo-api.xml'))
        gen1.ApiIncludes.append(path.join(self.GeneratorDir, 'gio-api.xml'))
        gen1.ApiIncludes.append(path.join(self.GeneratorDir, 'pango-api.xml'))
        gen1.GlueIncludes.append('gdk/gdk.h')
        ret.append(gen1)

        gen1 = CodeGen(self.GeneratorDir, 'gtk', 'Gtk/generated', 'Gtk.Glue')
        gen1.ApiIncludes.append(path.join(self.MetaDir, 'includes', 'glib-api.xml'))
        gen1.ApiIncludes.append(path.join(self.MetaDir, 'includes', 'cairo-api.xml'))
        gen1.ApiIncludes.append(path.join(self.GeneratorDir, 'gio-api.xml'))
        gen1.ApiIncludes.append(path.join(self.GeneratorDir, 'pango-api.xml'))
        gen1.ApiIncludes.append(path.join(self.GeneratorDir, 'atk-api.xml'))
        gen1.ApiIncludes.append(path.join(self.GeneratorDir, 'gdk-api.xml'))
        gen1.GlueIncludes.append('gtk/gtk.h')
        ret.append(gen1)
        return ret

# GtkSharp Build Script
class CodeGen(object):

    # Class Init
    def __init__(self, gendir, name, genout, glueout):
        self.GeneratorDir = gendir
        self.Name = name
        self.CodeGen = "../../Build/Generator/bin/netcoreapp2.0/GtkSharp.CodeGen.dll"      
        self.ApiFile = self.Name + "-api.xml"
        self.GenOut = genout  
        self.GlueOut = glueout  
        self.GlueIncludes = []
        self.ApiIncludes = []

        self.BaseDir = path.dirname(path.abspath(__file__))
        self.CodeGen = path.abspath(path.join(self.BaseDir, self.CodeGen))
        
    # Generate sources from the .xml files from the parser
    def generate(self):
        print("Running code generation for :" + self.Name)
        if self.GlueOut != '':
            gluedir = path.join(self.GeneratorDir, self.GlueOut)
            if not path.exists(gluedir):
                os.makedirs(gluedir)

        cmdargs = ['dotnet', self.CodeGen]
        cmdargs.append('--generate=' + path.join(self.GeneratorDir, self.ApiFile))
        for item in self.ApiIncludes:
            cmdargs.append('-I:' + item)
        cmdargs.append('--outdir=' + self.GenOut)
        cmdargs.append('--assembly-name=' + self.Name + '-sharp')
        cmdargs.append('--gluelib-name=' + self.Name + 'sharpglue-3')
        if self.GlueOut != '':
            cmdargs.append('--glue-filename=' + path.join(self.GlueOut, 'generated.c'))
        for item in self.GlueIncludes:
            cmdargs.append('--glue-includes=' + item)
        cmdargs.append('--schema=gapi.xsd')
        Common.run_cmd(cmdargs ,self.GeneratorDir)
