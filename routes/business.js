var express = require('express');
var router = express.Router();
var getConnection = require('../connection.js');

/* GET users listing. */
router.get('/', function (req, res) {
    getConnection(function(err,db) {
         var col = db.collection('review');
        col.find({},{ name: true}).toArray(function(err, result) {
            res.send(items);
        });
    });
});

module.exports = router;