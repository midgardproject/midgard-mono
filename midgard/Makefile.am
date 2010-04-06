
pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = midgard-sharp.pc

MCS=mcs -debug
RAW_API=midgard-api.raw
API=midgard-api.xml
METADATA=midgard.metadata

ASSEMBLY_NAME= midgard-sharp
ASSEMBLY= $(ASSEMBLY_NAME).dll

CODEGEN=gapi2-codegen
FIXUP=gapi2-fixup

#sources = Something.cs
sources = 

build_sources = AssemblyInfo.cs $(sources)

customs = 
#customs = App.custom Widget.custom Project.custom WidgetClass.custom

CLEANFILES = midgard-sharp.dll generated-stamp generated/*.cs $(API)

DISTCLEANFILES= AssemblyInfo.cs midgard-sharp.pc

noinst_DATA = midgard-sharp.dll

all: generated-stamp midgard-sharp.dll

$(API): $(srcdir)/$(RAW_API) $(srcdir)/$(METADATA)
	cp $(srcdir)/$(RAW_API) $(API)
	chmod u+w $(API)
	$(FIXUP) --api=$(srcdir)/$(API) --metadata=$(srcdir)/$(METADATA)

generated-stamp: $(API)
	 $(CODEGEN) --generate $(srcdir)/$(API) $(GTK_SHARP_CFLAGS) --outdir=generated --customdir=$(srcdir) --assembly-name=midgard-sharp && touch generated-stamp

midgard-sharp.dll: $(build_sources) generated-stamp
	$(MCS) -nowarn:169 -unsafe -target:library $(GTK_SHARP_LIBS) \
	$(build_sources) generated/*.cs -out:midgard-sharp.dll

install-data-local:
	echo "$(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS)";  \
        $(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS) || exit 1;

uninstall-local:
	echo "$(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS)"; \
        $(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS) || exit 1;

EXTRA_DIST = $(RAW_API) $(sources) $(customs) $(METADATA) AssemblyInfo.cs.in midgard-sharp.pc.in $(API)
