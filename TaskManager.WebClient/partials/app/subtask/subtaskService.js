/// <reference path="../../helpers/script/angular.min.js" />
/// <reference path="../../helpers/script/angular-route.min.js" />
/// <reference path="../../helpers/script/angular-resource.min.js" />

angular.module('taskmanager')
    .service('subtaskService', ['$resource', '$q', function ($resource, $q) {

        var baseUrl = 'http://localhost:51090/api/';


        var saveResult = function (subtask) {
            var defer = $q.defer();
            var resource = $resource(baseUrl + 'SubTask');
            resource.save(subtask,
                function (response) {
                    return defer.resolve(response);

                },
                function (error) {
                    return defer.reject(error);
                });
            return defer.promise;
        };


        var getAllByTaskId = function (taskId) {
            var defer = $q.defer();
            var resourse = $resource(baseUrl + 'SubTask?taskId=' + taskId);
            resourse.get(
                function (response) {
                    return defer.resolve(response);
                },
                function (error) {
                    return defer.reject(error);
                });
            return defer.promise;
        };

        var removeResult = function (id) {
            var defer = $q.defer();
            var resource = $resource(baseUrl + 'SubTask?id=' + id);
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


        var getByIdResult = function (id) {
            var defer = $q.defer();
            var resource = $resource(baseUrl + 'Subtask?id=' + id);
            resource.get(
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
            getAllByTask: getAllByTaskId,
            getById: getByIdResult,
            remove: removeResult

        };

    }
    ]);