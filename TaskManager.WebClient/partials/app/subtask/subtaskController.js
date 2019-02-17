/// <reference path="../../helpers/script/angular.min.js" />
/// <reference path="../../helpers/script/angular-route.min.js" />
/// <reference path="../../helpers/script/angular-resource.min.js" />

angular.module('taskmanager').controller('subtaskController', ['$scope', 'subtaskService', 'taskService', function ($scope, subtaskService, taskService) {
    $scope.pagename = "Create Subtask";
    $scope.btnname = "Create";
    $scope.subtask = { Task: null };
    $scope.tasks = [];

    $scope.save = function () {
        console.log($scope.subtask);
        $scope.subtask.taskId = $scope.subtask.Task.Id;
        subtaskService.save($scope.subtask)
            .then(
                function (response) {
                    if (response.IsSuceess) {
                        alert("Success");
                        $scope.subtask = {};
                    } else {
                        alert('Error' + response.Message);
                    }
                },
                function (error) {
                    alert(error);
                }
            );
    };

    var loadTasks = function () {
        taskService.getAll()
            .then(
                function (response) {
                    if (response.IsSuceess) {
                        console.log(response.Data);
                        $scope.tasks = response.Data;
                    } else {
                        alert(response.Message);
                    }
                },
                function (error) {
                    alert(error);
                });
    };

    function init() {
        loadTasks();
    }

    init();

}]);