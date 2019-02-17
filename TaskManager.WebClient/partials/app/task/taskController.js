
/// <reference path="../../helpers/script/angular.min.js" />
/// <reference path="../../helpers/script/angular-route.min.js" />
/// <reference path="../../helpers/script/angular-resource.min.js" />

angular.module('taskmanager').controller('taskController', ['$scope', 'taskService', function ($scope, taskService) {
    $scope.pagename = "Create Task";
    $scope.task = { Task: null };
    $scope.save = function () {
        $scope.task.DueDate = $scope.task.DueDate.toDateString();
        taskService.save($scope.task)
            .then(
                function (response) {
                    if (response.IsSuceess) {
                        alert("SUCCESS");
                        $scope.task = {};

                    }
                    else {
                        alert('Error' + response.Message);
                    }
                },
                function (error) {
                    alert(error.statusText);
                    
                }
            );
    };

}]);