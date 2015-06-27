var express = require('express');
var router = express.Router();
var getConnection = require('../connection.js');

/* GET users listing. */
router.get('/', function (req, res) {
    getConnection(function(err,db) {
         var col = db.collection('bigraph');
        col.find({ $query: {}, $orderby: { count: -1 } },{}).limit(1000).toArray(function(err, result) {
            res.send(result);
        });
    });
});

router.get('/groups', function (req, res) {
    getConnection(function(err,db) {
         var col = db.collection('groups');
          col.find({ $query: {}} ,{}).toArray(function(err, result) {
            res.send(result);
        });
    });
});
module.exports = router;