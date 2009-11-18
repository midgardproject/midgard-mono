
SOURCE_DIRS = \
	midgard

EXTRA_DIST = midgard-sharp-sources.xml

api:
	PERLLIB=$(GTKSHARP_PREFIX)/share/perl5 \
	PATH=$(GTKSHARP_PREFIX)/bin:$$PATH \
	gapi2-parser midgard-sharp-sources.xml

clean:
	@for i in $(SOURCE_DIRS); do \
		rm -rf $$i ;             \
	done;
