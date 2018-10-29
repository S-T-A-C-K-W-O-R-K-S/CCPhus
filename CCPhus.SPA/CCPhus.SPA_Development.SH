#!/bin/bash
printf '\033[8;40;160t'

echo && echo "Executing Script From: $(PWD) on $(HOSTNAME)"

ng serve

echo
