#!/bin/bash
printf '\033[8;40;160t'

NC="\033[0m" && RED="\e[38;5;196m" && YEL="\e[38;5;226m" && GR="\e[38;5;46m" && MAG="\e[38;5;201m"
# https://misc.flogisoft.com/bash/tip_colors_and_formatting
# https://jonasjacek.github.io/colors/

echo && echo -e "${MAG}Executing Script From: $(PWD) on $(HOSTNAME)${NC}"

ng serve --configuration Production

echo
