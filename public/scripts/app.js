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
            businessNames: function($http){
                return $http.get('/business/');
            }
        }
    })
    .when('/bigraph', {
        templateUrl: 'views/bigraph.html',
        controller: 'BiGraphCtrl',
        resolve:{
            bigraph: function($http){
                //TODO add async call here. Fetch graph nodes & edges   
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
