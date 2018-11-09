echo "Executing Script From: $(PWD; echo on  $(HOSTNAME))"
echo

PS3='Select The Runtime Environment: '

options=("Development" "Production" "Quit")

select option in "${options[@]}"

do
	case $option in
		"Development")
			echo "Runtime Environment: $option"
			$(bash $(PWD)/CCCPhus.API/CCPhus.API_Development.SH)
			$(bash $(PWD)/CCCPhus.SPA/CCPhus.SPA_Development.SH)
			break
			;;
		"Production")
			echo "Runtime Environment: $option"
			$(bash $(PWD)/CCCPhus.API/CCPhus.API_Production.SH)
			$(bash $(PWD)/CCCPhus.SPA/CCPhus.SPA_Production.SH)
			break
			;;
		"Quit")
			break
			;;
		*)
			echo "Invalid Selection: $REPLY"
			echo "Try Again"
			echo
			;;
	esac
done

read
