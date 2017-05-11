#! python3
import os, sys, subprocess

from jinja2 import Environment, FileSystemLoader
from bs4 import BeautifulSoup
from shutil import copyfile

# Doxygen Build Script
class DoxygenBuild(object):

    # Class Init
    def __init__(self):
        self.DOXYGENBUILD = "C:/Program Files/doxygen/bin/doxygen.exe"
        self.BUILDDIR = "../MkDocs/Docs/doxygen"
        self.DOXYDIR = "./"

    # Print Usage
    def usage(self):
        print ("Please use build.py <target> where <target> is one of")
        print ("  build           to make standalone HTML files")
        print ("  clean           to clean the html output directory")
        print ("  template_def    generate default templates for header / footer / css")
        print ("  template_mkdocs generate templates based on mkdocs html output")

    # Empty a directory
    def emptydir(self, top):
        if(top == '/' or top == "\\"): return
        else:
            for root, dirs, files in os.walk(top, topdown=False):
                for name in files:
                    os.remove(os.path.join(root, name))
                for name in dirs:
                    os.rmdir(os.path.join(root, name))

    # Clean the Build directory
    def clean(self):
        self.emptydir("../MkDocs/Docs/doxygen")
        print ("Clean finished")

    # Run a command
    def run_cmd(self, cmdarray, workingdir):
        proc = subprocess.Popen(cmdarray, cwd=workingdir, stdout=subprocess.PIPE, stderr=subprocess.PIPE, universal_newlines=True)
        proc_out, proc_err = proc.communicate()
        print(proc_out)
        print(proc_err)
        if proc.returncode != 0:
            raise RuntimeError("Failure to run command")
        return

    # Do the main build of doxygen html
    def build(self):
        self.clean()
        cmdopts = []
        cmdopts.append(self.DOXYGENBUILD)
        cmdopts.append('Doxyfile')
        self.run_cmd(cmdopts, self.DOXYDIR)
        # Copy custom search.css across
        searchcss_src = os.path.abspath(os.path.join(self.DOXYDIR, "theme/search.js"))
        searchcss_dest = os.path.abspath(os.path.join(self.DOXYDIR, self.BUILDDIR, "search/search.js"))
        copyfile(searchcss_src, searchcss_dest)
        searchcss_src = os.path.abspath(os.path.join(self.DOXYDIR, "theme/doxygen.css"))
        searchcss_dest = os.path.abspath(os.path.join(self.DOXYDIR, self.BUILDDIR, "doxygen.css"))
        copyfile(searchcss_src, searchcss_dest)
        print ("Build finished. The HTML pages are in " + self.BUILDDIR)

    # Generate Default Templates
    def template_def(self):
        deftemp_path = os.path.abspath(os.path.join(self.DOXYDIR, "theme/default"))
        if not os.path.exists(deftemp_path):
            os.mkdir(deftemp_path)
        cmdopts = []
        cmdopts.append(self.DOXYGENBUILD)
        cmdopts += ["-w", "html"]
        cmdopts += ["theme/default/header.html", "theme/default/footer.html", "theme/default/customdoxygen.css"]
        cmdopts.append('Doxyfile')
        self.run_cmd(cmdopts, self.DOXYDIR)

    # Generate MkDocs Templates for use with Doxygen
    def template_mkdocs(self):
        print ("Generating Templates for Doxygen from mkdocs html source")

        # Setup Jinja template directory
        themedir = os.path.abspath(os.path.join(self.DOXYDIR, "theme"))
        j2_env = Environment(loader=FileSystemLoader(themedir), trim_blocks=True)

        # Src html to extract from for the Doxygen templates
        srcpath = os.path.abspath(os.path.join(self.DOXYDIR, "../MkDocs/site/index.html"))
        soup = BeautifulSoup(open(srcpath).read(), 'html.parser')
    
        # Construct Mkdocs footer
        mkdocs_footer = ""
        for item in soup.findAll("footer", { "class" : "col-md-12" }):
            mkdocs_footer += str(item.prettify())
        for item in soup.findAll("script"):
            # Make sure js is linked via parent directory
            if item.has_attr('data-main'):
                item['data-main'] = item['data-main'].replace('./', '../')
            if item.has_attr('src'):
                item['src'] = item['src'].replace('./', '../')
            if item.text != '':
                item.string = (item.text.replace('.', '..'))
            # Add to Footer
            mkdocs_footer += str(item.prettify())
        for item in soup.findAll("div", { "id" : "mkdocs_search_modal" }):
            mkdocs_footer += str(item.prettify())

        # Write the Footer
        footer_tmpl = j2_env.get_template('footer.tmpl.html')
        footer_render = footer_tmpl.render(mkdocs_footer=mkdocs_footer)
        with open('theme/footer.html', 'w') as file:
            file.write(footer_render)
        
        # Construct Mkdocs header
        mkdocs_head = ""
        for item in soup.head.findAll(['meta', 'title', 'link']):
            if item.name == 'meta':
                item.string = ''
                mkdocs_head += str(item) + '\n'
            elif item.name == 'link':
                item.string = ''
                item['href'] = item['href'].replace('./', '../')
                mkdocs_head += str(item) + '\n'
            else:
                mkdocs_head += str(item) + '\n'

        # Remove the Edit / Previous / Next links from the menu for Doxygen
        for item in soup.find("ul", { "class" : "nav navbar-nav navbar-right" }).findAll("li"):
            if "Edit" in str(item.text) or "Previous" in str(item.text) or "Next" in str(item.text):
                item.decompose()


        # Make sure menu links point to parent directory
        for item in soup.find("ul", { "class" : "nav navbar-nav" }).findAll("li"):
            alink = item.find("a")
            alink['href'] = "../" + alink['href']

        mkdocs_topnavbar = ""
        for item in soup.findAll("div", { "class" : "navbar navbar-default navbar-fixed-top" }):
            mkdocs_topnavbar += str(item.prettify())

        # Write the Header
        header_tmpl = j2_env.get_template('header.tmpl.html')
        header_render = header_tmpl.render(
            mkdocs_head = mkdocs_head,
            mkdocs_topnavbar = mkdocs_topnavbar)
        with open('theme/header.html', 'w') as file:
            file.write(header_render)

    def main(self):
        if len(sys.argv) != 2:
            self.usage()
            return
        if sys.argv[1] == "build":
            self.build()
        if sys.argv[1] == "clean":
            self.clean()
        if sys.argv[1] == "template_def":
            self.template_def()
        if sys.argv[1] == "template_mkdocs":
            self.template_mkdocs()

if __name__ == "__main__":
    DoxygenBuild().main()
