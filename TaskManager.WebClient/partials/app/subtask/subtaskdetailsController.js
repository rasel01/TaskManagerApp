angular.module('taskmanager').controller('subtaskdetailsController', ['$scope', '$location', '$routeParams', 'taskService', 'subtaskService', function ($scope,
    $location, $routeParams,taskService, subtaskService) {
    $scope.pagename = "Update Subtask";
    $scope.btnname = "Update";
    $scope.subtask = {};
    var id = $routeParams.id;
   
    $scope.save = function() {

        subtaskService.save($scope.subtask).then(
            function (response) {
                console.log(response);
                alert(response.Message);
                $location.path("/subtasks");
            },
            function(error) {
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

                        subtaskService.getById(id).then(
                            function (result) {
                                $scope.subtask = result.Data;
                                for (var i = 0; i < $scope.tasks.length; i++) {
                                    if ($scope.tasks[i].Id === $scope.subtask.taskId) {
                                        $scope.subtask.Task = $scope.tasks[i];
                                        break;
                                    }
                                }

                            },
                            function (error) {
                                alert(error.statusText);
                            }
                        );

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