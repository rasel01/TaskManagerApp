angular.module('taskmanager').controller('taskdetailsController', ['$scope', '$location', '$routeParams', 'taskService', function ($scope, $location, $routeParams, taskService) {

    $scope.task = {};
    var id = $routeParams.id;
    $scope.pagename = "Update Task";
    $scope.btnname = "Update";

    taskService.getById(id).then(
        function (response) {
            $scope.task = response.Data;
            $scope.task.DueDate = new Date($scope.task.DueDate);
        },
        function (error) {
            alert(error.statusText);
        }

    );
    $scope.save = function () {
        $scope.task.DueDate = $scope.task.DueDate.toDateString();
        taskService.save($scope.task).then(function (response) {
            console.log(response);
            $location.path('/tasks');
        }, function (error) {
            alert(error.statusText);
        });

    };

}]);