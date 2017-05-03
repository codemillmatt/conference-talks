# Xamarin Dev Days Madison - Azure/Xamarin Integration

### Overview
This repo contains the source code demoed during the Xamarin Dev Days in Madison on August 22, 2013.

The slides are contained within the  "Heads In The Clouds.pdf"

Before we get this to work, we first have to create a portal within Azure however ... we can either do this the easy way, or the hard way.

## Azure Setup

### Things you'll need to do no matter what
1. Go to http://windowsazure.com and create an account. (Just create a free one - it gives you more than enough credits to try this demo out).
2. Create a new mobile service. Follow the wizard that it gives you. You'll probably need to create a new SQL Server and database, and will need a new user id and password for each.
3. Remember all the names from step from steps 1 and 2.

### The Easy Way 
1. Create a new table from within the data section (use javascript).
2. Call the table "Cheese"
3. Create the following columns: "cheesename" "dairyname" (both strings) and "dateadded" date
4. Create another table named "Rating"
5. Create the following columns in that table: "cheeseid" (string), "wedgerating" (int), "notes" (string), "daterated" date

### The Hard Way
1. Clone the Git repo that Azure mobile services gives you
1. Fork this (my) repository
2. Take what's in /Azure/cheesed-devdays/service and put it into the cloned repo from step 1.
3. Push the repo up to Azure.

Yeah ... go with the easy way.

* Then note the "application key* found under the "manage keys" button on the button of the "dashboard tab".

## Code demos
Just clone or fork this repo ... then within the /Devdays/Cheesed/Cheesed/DataService directory - within AzureCheeseDataService.cs and OfflineCheeseDataService.cs - find the *YOUR_URL_HERE* and *YOUR_KEY_HERE* and replace those with the values you copied.

Once you did that ... you're good to go with the demo!


## Acknowledgments and credits
* UI inspiration for the details view and card view on the "recent ratings" from [Syntax Is My UI](http://syntaxismyui.com)

Icons from The Noun Project
* Cheese Wedge: Elliott Snyder
* Cheese Block: artworkbean
* Beer Mug: sachan

* Cow photo: Kosmopolitat [GFDL (http://www.gnu.org/copyleft/fdl.html) or CC-BY-SA-3.0 (http://creativecommons.org/licenses/by-sa/3.0/)], via Wikimedia Commons


