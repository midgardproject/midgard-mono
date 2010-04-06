
TARGETS = connection.exe config.exe schema.exe storage.exe objects.exe queryselect.exe

EXTRA_DIST = connection.cs config.cs schema.cs

DEBUGS = $(addsuffix .mdb, $(TARGETS))

CLEANFILES = $(TARGETS) $(DEBUGS)

references=-r:../midgard/midgard-sharp.dll -pkg:glib-sharp-2.0

all: $(TARGETS)

connection.exe: $(srcdir)/connection.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/connection.cs

config.exe: $(srcdir)/config.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/config.cs

schema.exe: $(srcdir)/schema.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/schema.cs

storage.exe: $(srcdir)/storage.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/storage.cs

objects.exe: $(srcdir)/objects.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/objects.cs

queryselect.exe: $(srcdir)/QuerySelect.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/QuerySelect.cs
