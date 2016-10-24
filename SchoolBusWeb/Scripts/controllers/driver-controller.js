(function (angular) {
    "use strict";

    var schoolBus = angular.module("schoolBus", ["ngAnimate"]);

    schoolBus.directive("spinner", window.angularDirectives.spinner);

    schoolBus.directive("navigationContainer", window.angularDirectives.navigationContainer);

    schoolBus.directive("responsiveTableRendered", window.angularDirectives.responsiveTableRendered);

    schoolBus.directive("datePicker", window.angularDirectives.datePicker);

    schoolBus.directive("deleteConfirmation", window.angularDirectives.deleteConfirmation);

    schoolBus.directive("errorTooltip", window.angularDirectives.errorTooltip);

    schoolBus.controller("driverController", ["$scope", "$http", function ($scope, $http) {
        var validationMessage = "Existen errores en la información enviada.";
        var createDriver = function () {
            return {
                IsValid: true
            };
        };

        $scope.$parent.selectedNavbar = "Driver";

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
        $scope.currentDriver = createDriver();
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

        $scope.initDriver = function (driver) {
            driver.delete = function () {
                $scope.currentDriver = driver;

                $scope.delete();
            };
        };

        $scope.edit = function (driver) {
            $scope.pageSubTitle = "Edición";

            $scope.currentDriver = $.extend(true, {}, driver);

            $scope.setEditMode();
        };

        $scope.cancelEdit = function () {
            $scope.pageSubTitle = "";

            $scope.currentDriver = createDriver();

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
                }, function () {
                    $scope.errorMessage = "Ocurrió un error en la consulta.";
                }).finally(function () {
                    $scope.setSpinner(false);
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
                }, function () {
                    $scope.errorMessage = "Ocurrió un error al guardar.";
                }).finally(function () {
                    $scope.setSpinner(false);
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
                }, function () {
                    $scope.errorMessage = "Ocurrió un error al actualizar.";
                }).finally(function () {
                    $scope.setSpinner(false);
                });
        };

        $scope.delete = function () {
            $scope.setSpinner(true);

            $scope.pageMode = "delete";

            $http.post("Chofer/Delete", $scope.currentDriver).then(
                function () {
                    $scope.get();

                    $scope.cancelEdit();
                }, function () {
                    $scope.errorMessage = "Ocurrió un error al eliminar.";
                }).finally(function () {
                    $scope.currentDriver = createDriver();

                    $scope.setSpinner(false);
                });
        };

        $scope.get();
    }]);
})(window.angular);