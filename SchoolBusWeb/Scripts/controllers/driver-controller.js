(function (angular) {
    "use strict";

    var schoolBus = angular.module("schoolBus", ["ngAnimate"]);

    schoolBus.directive("responsiveDataTable", window.angularDirectives.responsiveDataTable);

    schoolBus.directive("navigationContainer", window.angularDirectives.navigationContainer);

    schoolBus.controller("driverController", ["$scope", function ($scope) {
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

        $scope.data = [
        {
            Name: "Carlos",
            MiddleName: "Alberto",
            LastName: "Gonzalez",
            SecondLastName: "Morales",
            BirthDate: "05/09/1989"
        }];

        $scope.drivers = $scope.data;
        $scope.driverToUpdate = {};

        $scope.edit = function(driver) {
            $scope.driverToUpdate = driver;

            $scope.setEditMode();
        };

        $scope.cancelEdit = function () {
            $scope.driverToUpdate = {};

            $scope.setReadMode();
        };
    }]);
})(window.angular);