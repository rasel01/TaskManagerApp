angular.module('taskmanager', ['ngRoute', 'ngResource'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/',
                {
                    templateUrl: 'partials/views/home/home.tpl.html',
                    controller: 'homeController',
                    controllerAs: 'vm'
                })
            .when('/home',
                {
                    templateUrl: 'partials/views/home/home.tpl.html',
                    controller: 'homeController',
                    controllerAs: 'vm'
                })
            .when('/task',
                {
                    templateUrl: 'partials/views/task/task.tpl.html',
                    controller: 'taskController',
                    controllerAs: 'vm'
                })
            .when('/tasks',
                {
                    templateUrl: 'partials/views/task/tasks.tpl.html',
                    controller: 'tasksController',
                    controllerAs: 'vm'

                })
            .when('/taskdetails/:id',
                {
                    templateUrl: 'partials/views/task/task.tpl.html',
                    controller: 'taskdetailsController',
                    controllerAs: 'vm'
                })
            .when('/subtask',
                {
                    templateUrl: 'partials/views/subtask/subtask.tpl.html',
                    controller: 'subtaskController',
                    controllerAs: 'vm'
                })
            .when('/subtasks',
                {
                    templateUrl: 'partials/views/subtask/subtasks.tpl.html',
                    controller: 'subtasksController',
                    controllerAs:'vm'

                })
            .when('/subtaskdetails/:id',
                {
                    templateUrl: 'partials/views/subtask/subtask.tpl.html',
                    controller: 'subtaskdetailsController',
                    controllerAs: 'vm'
                })
            .otherwise({ redirectTo: '/' });
    }]);