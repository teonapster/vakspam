'use strict';

/**
 * @ngdoc function
 * @name vakspamApp.controller:GraphCtrl
 * @description
 * # GraphCtrl
 * Controller of the vakspamApp
 */
angular.module('vakspamApp')
  .controller('GraphCtrl', function ($scope,businessNames,VisDataSet,randVal,$http,httpService) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'graph'
    ];

    $scope.businesses = businessNames.data;
    
    $scope.update = function(){
        httpService.makeCall('GET','/reviews/',{_id: $scope.bid.business_id}).then(function(res){
           $scope.updateGraph(res.data); 
        });
    }
    
    $scope.updateGraph = function(timeline){
        var reviews = timeline[0].reviews;
        var items = [];
        angular.forEach(reviews,function(v,k){
            items.push({ x: v._id.date, y: v.total_score });
        });
            
        $scope.data = {items: new vis.DataSet(items)};
    }
    $scope.options = {
        dataAxis: { showMinorLabels: false },
        style:'bar',
        legend: {left:{position:"bottom-left"}},
        start: '2004-12-31',
        end: '2016-06-18'
    };
});
