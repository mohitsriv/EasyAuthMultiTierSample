'use strict';
angular.module('todoApp', ['ngRoute','AdalAngular'])
.config(['$routeProvider', '$httpProvider', 'adalAuthenticationServiceProvider', function ($routeProvider, $httpProvider, adalProvider) {

    $routeProvider.when("/Home", {
        controller: "homeCtrl",
        templateUrl: "/App/Views/Home.html",
    }).when("/TodoList", {
        controller: "todoListCtrl",
        templateUrl: "/App/Views/TodoList.html",
        requireADLogin: true,
    }).when("/UserData", {
        controller: "userDataCtrl",
        templateUrl: "/App/Views/UserData.html",
    }).otherwise({ redirectTo: "/Home" });

    var endpoints = { 
        "https://MyDashAPI.azurewebsites.net/": "3271c206-5b87-4547-aea8-04177743474b"
    };

    adalProvider.init(
        {
            instance: 'https://login.microsoftonline.com/', 
            tenant: 'cloudmouth.net',
            //clientId: '3271c206-5b87-4547-aea8-04177743474b',
            clientId: '7d79f449-6c64-4fb8-84db-ef87f682dcbd',
            extraQueryParameter: 'nux=1',
            endpoints: endpoints
            //cacheLocation: 'localStorage', // enable this for IE, as sessionStorage does not work for localhost.
        },
        $httpProvider
        );
   
}]);
