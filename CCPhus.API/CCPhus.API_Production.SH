echo "Environment: Production"
echo "Executing Script From: $(PWD; echo on  $(HOSTNAME))"

dotnet watch run --environment Production

read
