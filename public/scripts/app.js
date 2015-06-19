'use strict';

/**
 * @ngdoc overview
 * @name vakspamApp
 * @description
 * # vakspamApp
 *
 * Main module of the application.
 */
angular
  .module('vakspamApp', [
    'ngAnimate',
    'ngCookies',
    'ngMessages',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'ngVis'
])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl'
    })
      .when('/about', {
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl'
    })
      .when('/graph', {
        templateUrl: 'views/graph.html',
        controller: 'GraphCtrl',
        resolve:{
            timeline: function($http){
                return $http.get('/reviews/');
            },
            businessNames: function($http){
                return $http.get('/business/');
            }
        }
    })
      .when('/test' , {
        templateUrl : 'views/test.html',
        controller : 'TestCtrl'
    })
      .otherwise({
        redirectTo: '/'
    });
});
