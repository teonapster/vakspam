'use strict';

/**
 * @ngdoc function
 * @name vakspamApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the vakspamApp
 */
angular.module('vakspamApp')
  .controller('AboutCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  })
.run(function($httpBackend){
    $httpBackend.whenGET('views\/.*\..*').passThrough(); 
});
