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
    
    var groups = new vis.DataSet();
     groups.add(
          {
            id: 1,
            content: 'Normal review'
          });
    groups.add(
            { id: 2,
            content: 'Possible spam'
          });
    
    $scope.updateGraph = function(timeline){
        var reviews = timeline[0].reviews;
        var items = [];
        var spam = 0;
        $scope.upperThreshold = Math.round((timeline[0].avg_score+3*timeline[0].std_score) * 100) / 100;
        $scope.lowerThreshold = Math.round((timeline[0].avg_score-3*timeline[0].std_score) * 100) / 100;
        angular.forEach(reviews,function(v,k){
            var group = v.total_score>$scope.upperThreshold||v.total_score<$scope.lowerThreshold?2:1;
            if(group==2)spam++;
            items.push({ x: v._id.date, y: v.total_score, group: group, label: "skata"});
        });
        spam = spam*100/timeline[0].reviews.length;
        $scope.spamPer = Math.round(spam * 100) / 100;
        
        $scope.data = {items: new vis.DataSet(items),groups: groups};
    }
    $scope.options = {
        dataAxis: { showMinorLabels: false },
        style:'points',
        legend: {left:{position:"bottom-left"}},
        start: '2004-12-31',
        end: '2016-06-18',
        drawPoints: {
          enabled: true,
          size: 6,
          style: 'circle' // square, circle
       },
    };
});
