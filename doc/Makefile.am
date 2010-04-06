if ENABLE_MONODOC
TARGETS = midgard-sharp-docs.zip midgard-sharp-docs.tree midgard-sharp-docs.source
docsdir = $(prefix)/lib/monodoc/sources
docs_DATA = $(TARGETS)
else
TARGETS = 
docsdir = $(datadir)
docs_DATA =
endif

ASSEMBLIES = ../midgard/midgard-sharp.dll

UPDATE_ASSEMBLIES = $(addprefix -assembly:, $(ASSEMBLIES))

midgard-sharp-docs.zip midgard-sharp-docs.tree: $(srcdir)/en/*/*.xml $(srcdir)/en/*.xml
	$(MDASSEMBLER) --ecma $(srcdir)/en -o midgard-sharp-docs

update:
	$(MONODOCER) $(UPDATE_ASSEMBLIES) -path:en

CLEANFILES = midgard-sharp-docs.zip midgard-sharp-docs.tree

EXTRA_DIST = midgard-sharp-docs.source

NAMESPACES=Midgard

dist-hook:
	mkdir -p $(distdir)/en
	cp $(srcdir)/en/*.xml $(distdir)/en/
	for i in $(NAMESPACES); do                          \
		mkdir -p $(distdir)/en/$$i;                     \
		cp $(srcdir)/en/$$i/*.xml $(distdir)/en/$$i;    \
	done
