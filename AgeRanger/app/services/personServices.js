'use strict'
angular.module('appModule')
        .service('personService', function ($resource) {
            this.getPersonData = $resource(webApiUrl + 'api/person/getlitsofperson');
            this.addPerson = $resource(webApiUrl + 'api/person/addperson');
            this.search = $resource(webApiUrl + 'api/person/searchperson/:name/', { name: '@name' });
            this.editPerson = $resource(webApiUrl + 'api/person/editperson');
        });