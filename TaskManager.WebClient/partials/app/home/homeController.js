/// <reference path="../../helpers/script/angular.min.js" />
/// <reference path="../../helpers/script/angular-route.min.js" />
/// <reference path="../../helpers/script/angular-resource.min.js" />


angular.module('taskmanager')
    .controller('homeController', ['$scope', 'homeService', 'taskService', 'subtaskService', function ($scope, homeService, taskService, subtaskService) {

        $scope.pagename = "home page";
        $scope.tasks = [];
        $scope.subTasks = [];
        $scope.selectedTask = '';
        $scope.loadSubTask = function (t) {
            $scope.selectedTask = t;
            subtaskService.getAllByTask(t.Id)
                .then(
                function (response) {
                    if (response.IsSuceess) {
                        $scope.subTasks = response.Data;
                        console.log('Task' + t);
                        if ($scope.subTasks.length === 0) {
                            alert('No subtask for ' + t.Name);
                        }
                    }
                    else {
                        alert('Error' + response.Message);
                    }
                },
                function (error) {
                    console.log(error);
                }

                );

        };

        $scope.loadTasks = function () {
            $scope.tasks = [];

            taskService.getAll()
                .then(

                function (response) {
                    if (response.IsSuceess) {
                        $scope.tasks = response.Data;
                        if ($scope.tasks.length > 0) {
                            $scope.loadSubTask($scope.tasks[0]);
                        }
                    }
                    else {
                        alert('Error' + response.Message);
                    }

                },
                function (error) {
                    console.log(error);
                }

                );
        };


        function init() {
            $scope.loadTasks();
        }

        init();
    }]);