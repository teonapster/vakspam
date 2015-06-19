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
        httpService.makeCall('GET','/reviews/',{_id: $scope.bid._id.bid}).then(function(res){
           $scope.updateGraph(res.data); 
        });
    }
    
    $scope.updateGraph = function(timeline){
        var items = [];
        var rev =timeline;

        for(var i=0;i<rev.length;++i)
            items.push({ x: rev[i].date, y: rev[i].value });
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
