angular.module('appModule')
        .controller('homeController', function HoneController($scope, $route, personService) {

            var vm = this;
            vm.caption = "This is Home Page";

            vm.getperson = function () {

                personService.getPersonData.get(
                    function ($data) {
                        console.log($data);
                        vm.person = $data.lPersonModel;
                    }, function (err) {
                        console.log(err);
                    })

            }            
})