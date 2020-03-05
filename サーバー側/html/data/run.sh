#!/bin/sh
cd `dirname $0`

python3 send.py t `cat $1`


