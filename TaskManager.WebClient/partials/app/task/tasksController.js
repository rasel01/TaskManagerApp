angular.module('taskmanager').controller('tasksController', ['$scope', 'taskService', function ($scope, taskService) {
    $scope.pagename = "Task List";
    $scope.tasks = [];

    $scope.loadTasks = function () {
        $scope.tasks = [];
        taskService.getAll().then(function (response) {
            if (response.IsSuceess) {
                $scope.tasks = response.Data;
            }
        }, function (error) {
            alert(error);
        });
    };

    $scope.remove = function (task) {
        taskService.remove(task.Id).then(
            function (response) {
                if (response.IsSuceess) {
                    $scope.loadTasks();
                }
                else {
                    alert(response.Mssage + '\n Detail:' + response.Exception.Message);
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