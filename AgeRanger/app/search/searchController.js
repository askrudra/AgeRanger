angular.module('appModule')
        .controller('searchController', function SearchController($scope, $route, personService) {

            var vm = this;
            vm.caption = "Search for  person in this page.";
            vm.show = false;
            vm.search = function (searchData) {

                personService.search.get({name:searchData},
                    function ($data) {
                        console.log($data);
                        vm.show = true;
                        vm.searchResult = $data.lPersonModel;
                    }, function (err) {
                        console.log(err);
                    })

            }

        })