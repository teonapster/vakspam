var express = require('express');
var router = express.Router();
var getConnection = require('../connection.js');
var assert = require('assert');

/* GET home page. */
router.get('/', function (req, res) {

   getConnection(function(err,db) { 
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

    });
});

module.exports = router;