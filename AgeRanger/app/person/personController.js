angular.module('appModule')
        .controller('personController', function PersonController($scope, $route, personService) {

            var vm = this;
            vm.caption = "Add a new person in this page.";
            
            vm.savePerson = function (person) {
                personService.addPerson.save(person,
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