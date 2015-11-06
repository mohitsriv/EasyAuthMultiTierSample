'use strict';
angular.module('todoApp')
.factory('todoListSvc', ['$http', function ($http) {
    var apiEndpoint = "https://MyDashAPI.azure-api.net/";

    $http.defaults.useXDomain = true;
    $http.defaults.headers.common['Ocp-Apim-Subscription-Key'] = 'fe52eccc59134660a37607e9d9476331';
    delete $http.defaults.headers.common['X-Requested-With']; 

    return {
        getItems : function(){
            return $http.get(apiEndpoint + 'api/TodoList');
        },
        getItem : function(id){
            return $http.get(apiEndpoint + '/api/TodoList/' + id);
        },
        postItem : function(item){
            return $http.post(apiEndpoint + 'api/TodoList', item);
        },
        putItem : function(item){
            return $http.put(apiEndpoint + 'api/TodoList/', item);
        },
        deleteItem : function(id){
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/TodoList/' + id
            });
        }
    };
}]);