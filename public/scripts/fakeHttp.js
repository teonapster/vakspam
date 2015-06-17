'use strict';

angular
.module('fakeHttp',['vakspamApp','ngMockE2E'])
.run(function($httpBackend,randVal){
    $httpBackend.whenGET(/reviews/).respond(randVal.randReviews(50));
    
    //Ignore all views
    $httpBackend.whenGET(/views\/.*/).passThrough();
    
});