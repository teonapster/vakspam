var express = require('express');
var router = express.Router();


//
// http://83.212.121.195:28017/
// u: vakspam
// p: diskotsoutsouni
//
var MongoClient = require('mongodb').MongoClient
  , assert = require('assert');




/* GET users listing. */
router.get('/', function (req, res) {

    var url = "mongodb://vakspam:diskotsoutsouni@83.212.121.195/vakspam";
    
    MongoClient.connect(url, function (err, db) {

        assert.equal(null, err);
        console.log("Connected correctly to server");
        var col = db.collection('business');
        col.find(function(err, cur) {


            cur.count(function(err, count) {
                console.log(count);
            });


        });


    });

    res.send('respond with a resource db');
});

module.exports = router;