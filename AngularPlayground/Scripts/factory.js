personApp.factory('personFactory', function () {
    function getName() {
        return "Mary Jane";
    }

    var service = {
        getName: getName
    };

    return service;
});



personApp.controller('personController', function ($scope, personFactory) {
    $scope.name = personFactory.getName();
});