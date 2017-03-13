'use strict';
angular.module('appModule').config(['$routeProvider', '$locationProvider',
  function ($routeProvider, $templateCache, $location,$locationProvider, $rootScope) {
     
      $routeProvider.
        when('/', {
            templateUrl: "app/home/home.html",
            controller: "homeController"            
            }).
        when('/Person', {
            templateUrl: "app/person/addperson.html",
            controller: "personController"
        }).
        when('/Search', {
            templateUrl: "app/search/searchperson.html",
            controller: "searchController"
        }).
        when('/Edit/:Id', {
            templateUrl: "app/edit/editperson.html",
            controller: "editController"
        }).
        otherwise({
            redirectTo: "/"
        });
  }]);