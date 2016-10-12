(function (angular) {
    "use strict";

    var schoolBus = angular.module("schoolBus", ["ngAnimate"]);

    schoolBus.directive("spinner", window.angularDirectives.spinner);

    schoolBus.directive("navigationContainer", window.angularDirectives.navigationContainer);

    schoolBus.directive("responsiveTableRendered", window.angularDirectives.responsiveTableRendered);

    schoolBus.directive("datePicker", window.angularDirectives.datePicker);

    schoolBus.controller("driverController", ["$scope", "$http", function ($scope, $http) {
        var initDriver = function () {
            return {
                IsValid: true
            };
        };
        var validationMessage = "Existen errores en la información enviada.";

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
        $scope.currentDriver = initDriver();
        $scope.renderTable = null;
        $scope.pageSubTitle = "";
        $scope.errorMessage = "";

        $scope.setSpinner = function (active) {
            $scope.$parent.spinnerActive = active;
        };

        $scope.setAddMode = function () {
            $scope.pageSubTitle = "Nuevo";

            $scope.setEditMode();
        };

        $scope.edit = function (driver) {
            $scope.pageSubTitle = "Edición";

            $scope.currentDriver = $.extend(true, {}, driver);

            $scope.setEditMode();
        };

        $scope.cancelEdit = function () {
            $scope.pageSubTitle = "";

            $scope.currentDriver = initDriver();

            $scope.setReadMode();
        };

        $scope.get = function () {
            var getUrl = ("Chofer/Get?cache=").concat(new Date().valueOf());

            $scope.setSpinner(true);

            $scope.drivers = [];

            $http.get(getUrl).then(
                function (response) {
                    $scope.drivers = response.data;

                    $scope.renderTable = ($scope.drivers && $scope.drivers.length > 0);

                    $scope.setSpinner(false);
                }, function () {
                    $scope.setSpinner(false);

                    $scope.errorMessage = "Ocurrió un error en la consulta.";
                });
        };

        $scope.add = function () {
            $scope.setSpinner(true);

            $http.post("Chofer/Add", $scope.currentDriver).then(
                function (response) {
                    $scope.currentDriver = response.data;

                    if (response.data.IsValid === true) {
                        $scope.cancelEdit();

                        $scope.get();
                    }
                    else {
                        $scope.errorMessage = validationMessage;
                    }

                    $scope.setSpinner(false);
                }, function () {
                    $scope.setSpinner(false);

                    $scope.errorMessage = "Ocurrió un error al guardar.";
                });
        };

        $scope.update = function () {
            $scope.setSpinner(true);

            $http.post("Chofer/Update", $scope.currentDriver).then(
                function (response) {
                    $scope.currentDriver = response.data;

                    if (response.data.IsValid === true) {
                        $scope.cancelEdit();

                        $scope.get();
                    }
                    else {
                        $scope.errorMessage = validationMessage;
                    }

                    $scope.setSpinner(false);
                }, function () {
                    $scope.setSpinner(false);

                    $scope.errorMessage = "Ocurrió un error al actualizar.";
                });
        };

        $scope.get();
    }]);
})(window.angular);