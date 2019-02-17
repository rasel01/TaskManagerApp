/// <reference path="../../helpers/script/angular.min.js" />
/// <reference path="../../helpers/script/angular-route.min.js" />
/// <reference path="../../helpers/script/angular-resource.min.js" />

angular.module('taskmanager')
    .service('taskService', ['$resource', '$q', function ($resource, $q) {

        var baseUrl = 'http://localhost:51090/api/';
        var saveResult = function (task) {
            var defer = $q.defer();
            var resource = $resource(baseUrl + 'Task');
            resource
                .save(task,
                function (response) {
                    return defer.resolve(response);
                },
                function (error) {
                    return defer.reject(error);
                }

                );

            return defer.promise;
        };

        var getResult = function () {
            var defer = $q.defer();
            var resource = $resource(baseUrl + 'Task');
            resource
                .get(
                function (response) {
                    return defer.resolve(response);
                },
                function (error) {
                    return defer.reject(error);
                }

                );

            return defer.promise;

        };

        var getByIdResult = function (id) {

            var defer = $q.defer();
            var resource = $resource(baseUrl + 'Task?id=' + id);
            resource
                .get(
                function (response) {
                    return defer.resolve(response);
                },
                function (error) {
                    return defer.reject(error);
                }

                );
            return defer.promise;
        };


        var removeResult = function (id) {

            var defer = $q.defer();
            var resource = $resource(baseUrl + 'Task?id=' + id);
            resource.delete(
                function (response) {
                    return defer.resolve(response);
                },
                function (error) {
                    return defer.reject(error);
                }
            );
            return defer.promise;
        };

        return {
            save: saveResult,
            getAll: getResult,
            getById: getByIdResult,
            remove: removeResult
        };

    }]);