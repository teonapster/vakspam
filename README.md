#Opinion Spam Detection
The goal of this web application is to make it easier for yelp employees to detect suspicious review activities from users that try to mislead visitors by either giving undeserving positive reviews in some businesses in order to promote them or by giving false negative opinions to some other businesses in order to damage their reputations. We are providing two ways for achieving this objective, the Review Spike Detection (RSD) module and the User Rating Behaviour (URB) module.

After downloading this project please install all the libraries by following these steps:

###Install front-end libraries
We take it for granted that you already have installed **bower** package manager. We assume also that you have a basic knowledge of command line syntax. In order to avoid manual installation for every package, a list files has been made: 
* bower.js
so run <code> bower install </code> inside ./vakspam/public 

###Install back-end libraries 
 **npm** package manager is needed here. Run the following command to download all the dependencies of backe-end engine:
 * <code> npm install </code> in the root folder (./vakspam)
 

##Run SpamJam
Run <code> node ./bin/www in ./vakspam folder (node package is needed here)

##Debug SpamJam
Run <code> node-debug ./bin/www in ./vakspam folder (node-debug package is needed here)
