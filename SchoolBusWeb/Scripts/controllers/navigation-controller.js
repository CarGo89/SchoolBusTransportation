(function (angular) {
    "use strict";

    var schoolBus = angular.module("schoolBus", ["ngAnimate"]);

    schoolBus.controller("navigationController", ["$scope", function ($scope) {
        $scope.editMode = false;

        $scope.setEditMode = function () {
            $scope.editMode = !$scope.editMode;
        };
    }]);
})(window.angular);