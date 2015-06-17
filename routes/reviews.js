var express = require('express');
var router = express.Router();


var MongoClient = require('mongodb').MongoClient;
var assert = require('assert');

/* GET home page. */
router.get('/', function (req, res) {

    var url = "mongodb://vakspam:diskotsoutsouni@83.212.121.195/vakspam";
    
    MongoClient.connect(url, function (err, db) {
        
        assert.equal(null, err);
        console.log("Connected correctly to server");

        var col = db.collection('review');

        col.find({business_id:'4bEjOyTaDG24SY5TxsaUNQ'},{ date: true, stars: true}).toArray(function(err, result) {

            var items = [];
            var hashmap = {};

            //console.log(result);
            for (var i = 0; i < result.length; i++) {
               // items.push({ date: result[i].date, value: result[i].stars });
                if (hashmap[result[i].date]) {
                    hashmap[result[i].date]++;
                } else {
                    hashmap[result[i].date] = 1;
                }
            }
            
            for (var k in hashmap) {
                items.push({ date: k, value: hashmap[k] });
            }

            //console.log(hashmap);

            res.send(items);
        });

        //col.find(function (err, cur) {
        //    cur.count(function (err, count) {
        //        console.log(count);
        //    });
        //});
    });
    
    //res.send('respond with a resource db');
    console.log('request data...');
    //res.send([{ date:'2013-10-10', value: '10' }, { date:'2013-10-11', value:'20' }]);


});

module.exports = router;