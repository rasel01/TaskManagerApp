angular.module('taskmanager').controller('subtasksController',
    [
        '$scope', 'subtaskService', function ($scope, subtaskService) {

            
            $scope.pagename = "SubTask List";
            $scope.subtasks = [];

            $scope.loadSubTask = function() {
                subtaskService.getAllByTask(0).then(
                    function(response) {
                        if (response.IsSuceess) {

                            $scope.subtasks = response.Data;
                        } else {
                            alert(response.Message);
                        }
                    },
                    function(error) {
                        console.log(error);
                    }
                );
            };

            var init = function() {
                $scope.loadSubTask();
            };

            init();


            $scope.remove = function(subtask) {
                subtaskService
                    .remove(subtask.Id)
                    .then(
                        function(response) {
                            if (response.IsSuceess) {
                                $scope.loadSubTask();
                            }
                            else {
                                alert(response.Mssage + '\n Detail:' + response.Exception.Message);
                            }
                        },
                        function(error) {
                            console.log(error);
                        }
                    );

            };


        }]);