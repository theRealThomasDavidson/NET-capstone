####JUMP capstone for C#/.Net/Angular

##Docker

to create a container from our repo you will need docker running on linux on your computer. 

To create the image you can run this command:

    docker build --tag "capstone" .

if you would prefer a different name change the tag between the double quotes.

Next, to run the image you can run this command:

    docker run -dp 80:80 capstone

with capstone as the tag you built above and the 80 before the ':' as the port you would like to access the website from. 

