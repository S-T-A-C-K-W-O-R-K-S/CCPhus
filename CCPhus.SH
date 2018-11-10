#!/bin/bash
printf '\033[8;40;160t'

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
			stty -echo igncr && tput civis && echo
			echo "Terminating CCPhus.API On Port 5000" && fkill :5000 --force 2>CCPHUS.LOG
			stty echo -igncr && tput cnorm && error=$(<CCPHUS.LOG)
			if [ ! -z "$error" ] ; then
				# echo "$error"
				echo "No Process Running On Port 5000"
			elif [ -z "$error" ] ; then
				echo "Process Running On Port 5000 Has Been Terminated"
			fi && rm -f CCPHUS.LOG
			
			stty -echo igncr && tput civis && echo
			echo "Terminating CCPhus.API On Port 5001" && fkill :5001 --force 2>CCPHUS.LOG
			stty echo -igncr && tput cnorm && error=$(<CCPHUS.LOG)
			if [ ! -z "$error" ] ; then
				# echo "$error"
				echo "No Process Running On Port 5001"
			elif [ -z "$error" ] ; then
				echo "Process Running On Port 5000 Has Been Terminated"
			fi && rm -f CCPHUS.LOG
			
			stty -echo igncr && tput civis && echo
			echo "Terminating CCPhus.API On Port 4200" && fkill :4200 --force 2>CCPHUS.LOG
			stty echo -igncr && tput cnorm && error=$(<CCPHUS.LOG)
			if [ ! -z "$error" ] ; then
				# echo "$error"
				echo "No Process Running On Port 4200"
			elif [ -z "$error" ] ; then
				echo "Process Running On Port 5000 Has Been Terminated"
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
			echo && echo "Invalid Selection: $REPLY"
			echo "Try Again" ;;
	esac
done
