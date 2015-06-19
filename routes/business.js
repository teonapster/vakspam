var express = require('express');
var router = express.Router();
var getConnection = require('../connection.js');

/* GET users listing. */
router.get('/', function (req, res) {
    getConnection(function(err,db) {
         var col = db.collection('reviewFinal');
        col.find({ $query: {}, $orderby: { numdays: -1 } } ,{_id:true}).limit(100).toArray(function(err, result) {
            res.send(result);
        });
    });
});

module.exports = router;