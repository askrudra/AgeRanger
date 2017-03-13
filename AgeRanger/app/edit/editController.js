angular.module('appModule')
        .controller('editController', function EditController($scope, $route, $routeParams,$location ,personService) {

            var vm = this;
            vm.caption = "Edit person in this page.";

            vm.personId = $routeParams.Id;

            vm.initPerson = function () {

                personService.search.get({ name: vm.personId },
                    function ($data) {
                        console.log($data);
                        vm.searchResult = $data.lPersonModel;
                    }, function (err) {
                        console.log(err);
                    })


            }

            vm.savePerson = function (person)
            {
                personService.editPerson.save(person,
                    function ($data) {
                        console.log($data);
                        alert($data.MessageDetails);
                        $location.path('#!/');
                    },
                    function (err) {
                        console.log(err);
                    })
                console.log(person);
            }

        })