'use strict';

/**
 * @ngdoc function
 * @name vakspamApp.controller:GraphCtrl
 * @description
 * # GraphCtrl
 * Controller of the vakspamApp
 */
angular.module('vakspamApp')
  .controller('GraphCtrl', function ($scope,VisDataSet,randVal,$http) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];

//    var randValues = randVal.randReviews(100000);
    var randValues;
     var items = [];
    
    $http.get('/reviews/').then(function(reviews){
        var rev = reviews.data;
        for(var i=0;i<rev.length;++i)
            items.push({x:rev[i].date,y:rev[i].business_id});
        $scope.data = {items: new vis.DataSet(items)};
    });
    
    
   
    

    
    $scope.options = {
        dataAxis: {showMinorLabels: false},
        legend: {left:{position:"bottom-left"}},
        start: '2014-12-31',
        end: '2016-06-18'
    };
})
.run(function($httpBackend,randVal){
   
});
