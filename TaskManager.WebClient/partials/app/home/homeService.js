/// <reference path="../../helpers/script/angular.min.js" />
/// <reference path="../../helpers/script/angular-route.min.js" />
/// <reference path="../../helpers/script/angular-resource.min.js" />


angular.module('taskmanager')
    .service('homeService', ['$resource', '$q', function ($resource, $q) {
        //var baseUrl = 'http://localhost:51090/api/';
        //var getResult = function () {
        //    var defer = $q.defer();
        //    var resource = $resource(baseUrl + 'Task');
        //    resource
        //        .get(
        //            function (response) {
        //                return defer.resolve(response);
        //            },
        //            function (error) {
        //                return defer.reject(error);
        //            }

        //        );

        //    return defer.promise;

        //};

        //return {
        //    getAll:getResult
        //};
}]);
