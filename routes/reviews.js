var express = require('express');
var router = express.Router();
var getConnection = require('../connection.js');
var assert = require('assert');

/* GET home page. */
router.get('/', function (req, res) {

   getConnection(function(err,db) { 
        var col = db.collection('reviewFinal');
        
        col.find({ "_id" : { "bid" : req.query._id }},{ reviews: true,
                                                        lower_threshold: true,
                                                        upper_threshold: true,
                                                        avg_score: true,
                                                        std_score: true
                                                      }).toArray(function(err, result) {
            res.send(result);
        });

    });
});

module.exports = router;