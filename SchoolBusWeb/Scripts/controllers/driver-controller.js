(function (angular) {
    "use strict";

    var schoolBus = angular.module("schoolBus", ["ngAnimate"]);

    schoolBus.directive("navigationContainer", window.angularDirectives.navigationContainer);

    schoolBus.directive("responsiveTableRendered", window.angularDirectives.responsiveTableRendered);

    schoolBus.directive("datePicker", window.angularDirectives.datePicker);

    schoolBus.controller("driverController", ["$scope", "$http", function ($scope, $http) {
        $scope.dataTableLanguage = {
            search: "Filtrar:",
            searchPlaceholder: "Filtrar Choferes",
            emptyTable: "Sin Resultados",
            zeroRecords: "Sin Resultados",
            lengthMenu: "Mostrar _MENU_ Choferes",
            info: "Mostrando _START_ to _END_ of _TOTAL_ Choferes",
            infoEmpty: "Mostrando 0 a 0 de 0 Choferes",
            infoFiltered: "(Choferes filtrados de _MAX_)"
        };

        $scope.drivers = [];
        $scope.currentDriver = {
            IsValid: true
        };

        $scope.edit = function (driver) {
            $scope.currentDriver = $.extend(true, {}, driver);

            $scope.setEditMode();
        };

        $scope.cancelEdit = function () {
            $scope.currentDriver = {};

            $scope.setReadMode();
        };

        $scope.get = function () {
            var getUrl = ("Chofer/Get?cache=").concat(new Date().valueOf());

            $scope.drivers = [];

            $http.get(getUrl).then(
                function (response) {
                    $scope.drivers = response.data;
                }, function (response) {
                    response;
                });
        };

        $scope.add = function () {
            $http.post("Chofer/Add", $scope.currentDriver).then(
                function (response) {
                    $scope.currentDriver = response.data;

                    if (response.data.IsValid === true) {
                        $scope.cancelEdit();

                        $scope.get();
                    }
                }, function (response) {
                    response;
                });
        };

        $scope.update = function () {
            $http.post("Chofer/Update", $scope.currentDriver).then(
                function (response) {
                    $scope.currentDriver = response.data;

                    if (response.data.IsValid === true) {
                        $scope.cancelEdit();

                        $scope.get();
                    }
                }, function (response) {
                    response;
                });
        };

        $scope.get();
    }]);
})(window.angular);