'use strict';

/**
 * @ngdoc function
 * @name vakspamApp.controller:GraphCtrl
 * @description
 * # GraphCtrl
 * Controller of the vakspamApp
 */
angular.module('vakspamApp')
  .controller('GraphCtrl', function ($scope,VisDataSet) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];

    var dataGroups = new VisDataSet();
    dataGroups.add({});
    var dataItems = new VisDataSet();
    dataItems.add([{}]);
    $scope.graphData = {
      items: dataItems,
      groups: dataGroups
    };
});