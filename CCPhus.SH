#!/bin/bash
printf '\033[8;40;160t'
NC='\033[0m' && RED='\e[38;5;196m' && YEL='\e[38;5;226m' && GR='\e[38;5;46m' # https://misc.flogisoft.com/bash/tip_colors_and_formatting

echo "Executing Script From: $(PWD) on $(HOSTNAME)" && echo

PS3=$'\n'"Select An Option: "

options=("Deploy Development Servers" "Deploy Production Servers" "Kill Servers" "Run CCPhus" "Quit")

select option in "${options[@]}"

do
	case $option in
		"Deploy Development Servers")
			stty -echo igncr && tput civis && echo && echo "Executing: $option"
			(cd CCPhus.API && bash CCPhus.API_Development.SH && cd ..) &
			sleep 10s
			
			(cd CCPhus.SPA && bash CCPhus.SPA_Development.SH && cd ..) &
			sleep 22.5s && echo
			
			# stty echo -igncr && tput cnorm && read -n 1 -s -r -p "Press Any Key To Exit\n\n" && exit
			echo && read ;; # keeps the terminal window open, but prevents user input
			
		"Deploy Production Servers")
			stty -echo igncr && tput civis && echo && echo "Executing: $option"
			(cd CCPhus.API && bash CCPhus.API_Production.SH && cd ..) &
			sleep 10s
			
			(cd CCPhus.SPA && bash CCPhus.SPA_Production.SH && cd ..) &
			sleep 45s && echo
			
			# stty echo -igncr && tput cnorm && read -n 1 -s -r -p "Press Any Key To Exit\n\n" && exit
			echo && read ;; # keeps the terminal window open, but prevents user input
			
		"Kill Servers")
			noprocess="Error: Couldn't find a process with port"
			
			stty -echo igncr && tput civis && echo
			echo "Terminating CCPhus.API On Port 5000" && fkill :5000 --force 2>CCPHUS.LOG
			stty echo -igncr && tput cnorm && error=$(<CCPHUS.LOG)
			
			if [ ! -z "$error" ] && [[ "$error" =~ "$noprocess \`5000\`" ]] ; then
				echo -e "${YEL}No Process Running On Port 5000${NC}"
			elif [ -z "$error" ] ; then
				echo -e "${GR}Process Running On Port 5000 Has Been Terminated${NC}"
			else
				echo -e "${RED}\033[1A" && echo "$error" && echo -e "${NC}\033[1A"
			fi && rm -f CCPHUS.LOG
			
			stty -echo igncr && tput civis && echo
			echo "Terminating CCPhus.API On Port 5001" && fkill :5001 --force 2>CCPHUS.LOG
			stty echo -igncr && tput cnorm && error=$(<CCPHUS.LOG)
			
			if [ ! -z "$error" ] && [[ "$error" =~ "$noprocess \`5001\`" ]] ; then
				echo -e "${YEL}No Process Running On Port 5001${NC}"
			elif [ -z "$error" ] ; then
				echo -e "${GR}Process Running On Port 5000 Has Been Terminated${NC}"
			else
				echo -e "${RED}\033[1A" && echo "$error" && echo -e "${NC}\033[1A"
			fi && rm -f CCPHUS.LOG
			
			stty -echo igncr && tput civis && echo
			echo "Terminating CCPhus.API On Port 4200" && fkill :4200 --force 2>CCPHUS.LOG
			stty echo -igncr && tput cnorm && error=$(<CCPHUS.LOG)
			
			if [ ! -z "$error" ] && [[ "$error" =~ "$noprocess \`4200\`" ]] ; then
				echo -e "${YEL}No Process Running On Port 4200${NC}"
			elif [ -z "$error" ] ; then
				echo -e "${GR}Process Running On Port 5000 Has Been Terminated${NC}"
			else
				echo -e "${RED}\033[1A" && echo "$error" && echo -e "${NC}\033[1A"
			fi && rm -f CCPHUS.LOG ;;
			
		"Run CCPhus")
			viewer=echo
			
			for possibility in xdg-open gnome-open cygstart start open ; do
				if command -v "$possibility" >/dev/null 2>&1 ; then # ">/dev/null 2>&1" redirects the output to /dev/null; includes both stderr and stdout
					viewer="$possibility"
					break
				fi
			done
			
			if [ "$viewer" = echo ] ; then
				echo && echo 'No Viewer Found' 1>&2 # outputs to stderr (standard error) rather than stdout (standard output)
			fi
			
			"$viewer" "http://localhost:4200/" && echo ;;
		
		"Quit")
			break ;;
			
		*)
			echo && echo -e "${RED}Invalid Selection: $REPLY${NC}" ;;
	esac
done
