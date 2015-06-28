angular.module('vakspamApp').controller('BiGraphCtrl',function($scope,httpService,businessNames,groups,$filter,messageCenterService,$timeout,$rootScope){
    $scope.businesses = businessNames.data;
//    $scope.data = {};
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
    $timeout(function() {
       if($rootScope.busy)
       messageCenterService.add('warning', 'This feature may take some time.... Be patient', { timeout: 5000 });
    }, 5000);        
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
        var curNode = 0;
        angular.forEach(data,function(user,userIndex){
            var hasEdge = false;
            totalUsers++;
            //Add user 
            nodes.push({"id":curNode++, "title": "user "+user.uid,"group": getCategory(user.ufr,true)}); //TODO add title
            var curUser = curNode-1;
           angular.forEach(user.rating,function(review,reviewIndex){
               
               var exists = $filter('filter')(businesses, {bid: review.bid})[0];
               var selectedCategories =[$scope.cat];
               var isValid = validateCats(selectedCategories,review.cat);

               if(exists==undefined&&isValid){
                   //Add business
                    nodes.push({"id": curNode++, "label": "","title": "business "+review.bid,"group": getCategory(review.bfr,false)}); //TODO add title     
                    businesses.push({bid: review.bid, index: curNode-1});
                   totalBusinesses++;
               }

               //Add review
               if(isValid){
                   hasEdge = true;
                   var businessId = exists==undefined?curNode-1:exists.index;
                   if(curUser==businessId)
                       debugger;
                   edges.push({"from": curUser, "to":businessId });
                   totalReviews++;
               }
           });
            if(user.rating.length<=1||hasEdge==false){
                emptyUsers++;
                nodes.splice(nodes.length-1);
            }
        });
        $scope.data={
            edges: new vis.DataSet(edges),
            nodes: new vis.DataSet(nodes)
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
                 groups: {
                  1: {
                    shape: 'dot',
                    color: '#2B7CE9' // blue
                  },
                  2: {
                    shape: 'dot',
                    color: "#FF9900" // orange
                  },
                  3: {
                    shape: 'dot',
                    color: "#C5000B" // purple
                  },
                  4: {
                    shape: 'triangle',
                    color: "#2B7CE9" // blue
                  },
                  5:{
                    shape: 'triangle',
                    color: "#FF9900"  //orange
                  },
                  6: {
                    shape: 'triangle',
                    color: "#C5000B" // green
                  }
                },
                physics: { stabilization: false }
            };
            //var network = new vis.Network(container, data, options);
        
        
});