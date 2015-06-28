angular.module('vakspamApp').controller('BiGraphCtrl',function($scope,httpService,businessNames,groups){
    $scope.businesses = businessNames.data;
    $scope.data = {};
    var groups = groups.data[0];
//    var data = bigraph.data;
//    
    
    
    var getCategory = function(value,isUser){
        var ti = 0; //type interval
        var type = isUser?"u_":"b_";
        if(!isUser) ti=3;
        if(value<=groups[type+"uif"])
            return ti+1; 
        if(value>groups[type+"uif"]&&value<groups[type+"uof"])
            return ti+2; 
        else
            return ti+3; //fraud
    }
    
    var validateCats = function(filterCat,businessCat){
        var valid = false;
        angular.forEach(filterCat,function(filter,index){
            if(businessCat.indexOf(filter)!=-1){
                valid= true;
                return;
            } 
        });
        return valid;             
    }
    
    $scope.getFilteredBigraph = function(){
     httpService.makeCall('GET','/bigraph/',{categories: $scope.cat}).then(function(res){
           updateNetwork(res.data); 
        });
    }
           
    /*b_uif: 4.0483
b_uof: 5.36659
u_uif: 7.72865
u_uof: 11.70497*/
    var updateNetwork = function(data){
        var totalReviews = 0;
        var totalUsers= 0;
        var totalBusinesses= 0;
        var businesses = [];
        var nodes = []; 
        var edges = [];
        var userCount = data.length;
        var emptyUsers = 0;
        angular.forEach(data,function(user,userIndex){
            var hasEdge = false;
            totalUsers++;
            //Add user 
            nodes.push({"id":user.uid, "title": "user "+user.uid,"group": getCategory(user.ufr,true)}); //TODO add title
            
           angular.forEach(user.rating,function(review,reviewIndex){
                
               var curPos = totalReviews+userCount;
               var exists = businesses.indexOf(review.bid);
               
               var selectedCategories =[$scope.cat];
               var isValid = validateCats(selectedCategories,review.cat);
               if(exists==-1&&isValid){
                   //Add business
                    nodes.push({"id": review.bid, "label": "","title": "business "+review.bid,"group": getCategory(review.bfr,false)}); //TODO add title     
                    businesses.push(review.bid);
                   totalBusinesses++;
               }

               //Add review
               if(isValid){
                   hasEdge = true;
                   edges.push({"from": user.uid, "to": review.bid});
                   totalReviews++;
               }
           });
            if(user.rating.length<=1||hasEdge==false){
                emptyUsers++;
                nodes.splice(nodes.length-1);
            }
        });
        $scope.data={
            edges: edges,
            nodes: nodes
        }
    }
            
            $scope.options = {
                  nodes: {
                    shape: 'dot',
                    scaling: {
                      min: 10,
                      max: 30
                    },
                    font: {
                      size: 12,
                      face: 'Tahoma'
                    }
                  },
                  edges: {
                    color:{inherit:true},
                    width: 0.15,
                    smooth: {
                      type: 'dynamic'
                    }
                  },
                physics: { stabilization: false }
            };
            //var network = new vis.Network(container, data, options);
        
        
});