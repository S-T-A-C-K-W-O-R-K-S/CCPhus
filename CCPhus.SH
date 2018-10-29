#!/bin/bash
printf '\033[8;40;160t'

echo "Executing Script From: $(PWD; echo on  $(HOSTNAME))" && echo

PS3='Select An Option: '

options=("Deploy Development Servers" "Deploy Production Servers" "Kill Currently Running Servers" "Quit")

select option in "${options[@]}"

do
	case $option in
		"Deploy Development Servers")
			echo && echo "Executing: $option"
			(cd CCPhus.API && bash CCPhus.API_Development.SH && cd ..) &
			sleep 10s
			(cd CCPhus.SPA && bash CCPhus.SPA_Development.SH && cd ..) &
			sleep 22.5s && echo
			read -n 1 -s -r -p "Press Any Key To Exit " && exit ;;
			
		"Deploy Production Servers")
			echo && echo "Executing: $option"
			(cd CCPhus.API && bash CCPhus.API_Production.SH && cd ..) &
			sleep 10s
			(cd CCPhus.SPA && bash CCPhus.SPA_Production.SH && cd ..) &
			sleep 45s && echo
			read -n 1 -s -r -p "Press Any Key To Exit " && exit ;;
			
		"Kill Currently Running Servers")
			echo
			echo "Terminating CCPhus.API On Port 5000" && fkill :5000 --force && sleep 2s
			echo "Terminating CCPhus.API On Port 5001" && fkill :5001 --force && sleep 2s
			echo "Terminating CCPhus.SPA On Port 4200" && fkill :4200 --force && sleep 2s
			echo ;;
			
		"Quit")
			break ;;
			
		*)
			echo && echo "Invalid Selection: $REPLY"
			echo "Try Again" && echo ;;
	esac
done
