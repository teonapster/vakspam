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
    
    $scope.showInfo = function(){
       messageCenterService.remove(0);
    messageCenterService.add('info', '<div><label>Description: </label>Choose a business category from the drop-down menu and a network will appear on the graph. A node can either be a user or a business and each edge represents a review written by a user for a business.</div> <div><label>Note: </label> Please be patient, as the process takes some time, especially for the more popular categories. </div>', {html:true});
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
       messageCenterService.add('warning', 'Preparing the visualization may take some time. Please wait... (Free tip: Grab the chance and have some delicious marmalade-spiced ham combo)', { timeout: 5000 });
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
            nodes.push({"id":curNode++, "title": "user "+user.uid,"group": getCategory(user.ufr,true), "value": getCategory(user.ufr,true)}); //TODO add title
            var curUser = curNode-1;
           angular.forEach(user.rating,function(review,reviewIndex){
               
               var exists = $filter('filter')(businesses, {bid: review.bid})[0];
               var selectedCategories =[$scope.cat];
               var isValid = validateCats(selectedCategories,review.cat);

               if(exists==undefined&&isValid){
                   //Add business
                    nodes.push({"id": curNode++, "label": "","title": "business "+review.bid,"group": getCategory(review.bfr,false), "value": getCategory(review.bfr,false) * 10}); //TODO add title
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
                    size: 50,
                    scaling: {
                      min: 10,
                      max: 50
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
                  1: { shape:   'circle', color:   'blue' },
                  2: { shape:   'circle', color: 'orange' },
                  3: { shape:   'circle', color:    'red' },
                  4: { shape: 'triangle', color:  'green' },
                  5: { shape: 'triangle', color: 'orange' },
                  6: { shape: 'triangle', color:    'red' }
                },
                physics: { stabilization: false }
            };
            //var network = new vis.Network(container, data, options);
        
        
});