
rm $1.exe 2> /dev/null

# compile
mcs $1.cs

# run
mono $1.exe 

