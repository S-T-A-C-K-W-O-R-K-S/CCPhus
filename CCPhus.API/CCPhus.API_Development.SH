#!/bin/bash
printf '\033[8;40;120t'

echo
echo "Executing Script From: $(PWD; echo on  $(HOSTNAME))"

dotnet watch run --environment Development

echo
