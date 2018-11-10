#!/bin/bash
printf '\033[8;40;160t'

echo "Executing Script From: $(PWD) on $(HOSTNAME)" && echo

PS3='Select An Option: '

options=("Deploy Development Servers" "Deploy Production Servers" "Kill Currently Running Servers" "Run CCPhus" "Quit")

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
			
		"Kill Currently Running Servers")
			stty -echo igncr && tput civis && echo
			echo "Terminating CCPhus.API On Port 5000" && fkill :5000 --force && sleep 2s
			echo "Terminating CCPhus.API On Port 5001" && fkill :5001 --force && sleep 2s
			echo "Terminating CCPhus.SPA On Port 4200" && fkill :4200 --force && sleep 2s
			stty echo -igncr && tput cnorm && echo ;;
			
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
			echo "Try Again" && echo ;;
	esac
done
