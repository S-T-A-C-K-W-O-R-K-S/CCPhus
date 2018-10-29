#!/bin/bash
printf '\033[8;40;160t'

echo && echo "Executing Script From: $(PWD) on $(HOSTNAME)"

dotnet watch run --environment Development

echo
