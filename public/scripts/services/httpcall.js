(function(){
    var httpcall = function($http){
     var service = {}
     
     //e.g makeCall('GET','/my/path/',{id:23})
     service.makeCall= function(type,url,parameters){
        return $http({
            url: url,
            method: type,
            params: parameters
        });
     }
    
     return service;
    }
    angular
    .module('vakspamApp')
    .factory('httpService',httpcall);
})()