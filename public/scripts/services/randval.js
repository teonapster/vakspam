'use strict';

/**
 * @ngdoc service
 * @name vakspamApp.randVal
 * @description
 * # randVal
 * Factory in the vakspamApp.
 */
angular.module('vakspamApp')
  .factory('randVal', function () {
    var rnd = function (min, max) {
        return Math.floor(Math.random() * (max - min)) + min;
    }
    var randReviews = function(size){
        var voteTypes = ['funny','useful','cool'];
        var starRange = 5;
        var userFactor = 10;
        var businessFactor = 5;
        var reviews = [];
        
        for(var i=0;i<size;++i)
            reviews.push({
                votes:voteTypes[rnd(0,voteTypes.length)],
                stars:rnd(0,starRange),
                user_id:rnd(1,size/userFactor),
                business_id:rnd(1,size/businessFactor),
                date:'2011-'+rnd(1,12)+'-'+rnd(1,31),
                review_id:i
            });
        return reviews;
    }
        
    // Public API here
    return {
      randReviews: randReviews
    };
  });
