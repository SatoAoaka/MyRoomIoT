#!/bin/sh
cd `dirname $0`
at -t $1 << END_OF_INPUT
python3 send.py t `cat $2`
^D
END_OF_INPUT