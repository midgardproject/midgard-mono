#!/bin/sh

aclocal
automake -a -c
autoconf
./configure --enable-maintainer-mode $*
