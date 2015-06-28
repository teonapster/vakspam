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
  .config(function ($httpProvider){
       var HttpProviderInterceptor =
function($rootScope, $location, $q, $injector) {
	var startBusy = function () {
		if($rootScope.busy){
			++$rootScope.busy;
		} else {
			$rootScope.busy=1;
		}
	}
	
	var stopBusy = function () {
		if($rootScope.busy>0){
			--$rootScope.busy;
		} else {
			$rootScope.busy=undefined;
		}
	}
	
	return {
		'request': function(config){
			startBusy();
			return config;
		},
		'requestError': function(rejection){
			stopBusy();
			return rejection;
		 },
		'response': function(response){stopBusy();return response;},			
		'responseError': function(rejection) {
			stopBusy();
			
			return $q.reject(rejection);
		}
	};
};
    
    $httpProvider.interceptors.push(HttpProviderInterceptor);
 })
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
           
                
            groups: function($http){
                return $http.get('/bigraph/groups');
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
