echo "Executing Script From: $(PWD; echo on  $(HOSTNAME))" && echo

PS3='Select The Runtime Environment: '

options=("Development" "Production" "Quit")

select option in "${options[@]}"

do
	case $option in
		"Development")
			echo "Runtime Environment: $option"
			
			echo "Deploying CC.API"
			(cd CCPhus.API && bash CCPhus.API_Development.SH && cd ..) &
			
			sleep 5s
			
			echo && echo "Deploying CC.SPA"
			(cd CCPhus.SPA && bash CCPhus.SPA_Development.SH && cd ..) & ;;
			
		"Production")
			echo "Runtime Environment: $option"
			
			echo "Deploying CC.API"
			(cd CCPhus.API && bash CCPhus.API_Production.SH && cd ..) &
			
			sleep 5s
			
			echo && echo "Deploying CC.SPA"
			(cd CCPhus.SPA && bash CCPhus.SPA_Production.SH && cd ..) & ;;
			
		"Quit")
			break ;;
			
		*)
			echo "Invalid Selection: $REPLY"
			echo "Try Again"
			echo ;;
	esac
done

read
