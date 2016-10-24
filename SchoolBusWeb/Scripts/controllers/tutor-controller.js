(function (angular) {
    "use strict";

    var schoolBus = angular.module("schoolBus", ["ngAnimate"]);

    schoolBus.directive("spinner", window.angularDirectives.spinner);

    schoolBus.directive("navigationContainer", window.angularDirectives.navigationContainer);

    schoolBus.directive("responsiveTableRendered", window.angularDirectives.responsiveTableRendered);

    schoolBus.directive("datePicker", window.angularDirectives.datePicker);

    schoolBus.directive("deleteConfirmation", window.angularDirectives.deleteConfirmation);

    schoolBus.directive("errorTooltip", window.angularDirectives.errorTooltip);

    schoolBus.controller("tutorController", ["$scope", "$http", function ($scope, $http) {
        var validationMessage = "Existen errores en la información enviada.";
        var createTutor = function () {
            return {
                IsValid: true
            };
        };

        $scope.$parent.selectedNavbar = "Tutor";

        $scope.dataTableLanguage = {
            search: "Filtrar:",
            searchPlaceholder: "Filtrar Tutores",
            emptyTable: "Sin Resultados",
            zeroRecords: "Sin Resultados",
            lengthMenu: "Mostrar _MENU_ Tutores",
            info: "Mostrando _START_ to _END_ of _TOTAL_ Tutores",
            infoEmpty: "Mostrando 0 a 0 de 0 Tutores",
            infoFiltered: "(Tutores filtrados de _MAX_)"
        };

        $scope.tutors = [];
        $scope.currentTutor = createTutor();
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

        $scope.initTutor = function (tutor) {
            tutor.delete = function () {
                $scope.currentTutor = tutor;

                $scope.delete();
            };
        };

        $scope.edit = function (tutor) {
            $scope.pageSubTitle = "Edición";

            $scope.currentTutor = $.extend(true, {}, tutor);

            $scope.setEditMode();
        };

        $scope.cancelEdit = function () {
            $scope.pageSubTitle = "";

            $scope.currentTutor = createTutor();

            $scope.setReadMode();
        };

        $scope.get = function () {
            var getUrl = ("Tutor/Get?cache=").concat(new Date().valueOf());

            $scope.setSpinner(true);

            $scope.tutors = [];

            $http.get(getUrl).then(
                function (response) {
                    $scope.tutors = response.data;

                    $scope.renderTable = ($scope.tutors && $scope.tutors.length > 0);
                }, function () {
                    $scope.errorMessage = "Ocurrió un error en la consulta.";
                }).finally(function () {
                    $scope.setSpinner(false);
                });
        };

        $scope.add = function () {
            $scope.setSpinner(true);

            $http.post("Tutor/Add", $scope.currentTutor).then(
                function (response) {
                    $scope.currentTutor = response.data;

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

            $http.post("Tutor/Update", $scope.currentTutor).then(
                function (response) {
                    $scope.currentTutor = response.data;

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

            $http.post("Tutor/Delete", $scope.currentTutor).then(
                function () {
                    $scope.get();

                    $scope.cancelEdit();
                }, function () {
                    $scope.errorMessage = "Ocurrió un error al eliminar.";
                }).finally(function () {
                    $scope.currentTutor = createTutor();

                    $scope.setSpinner(false);
                });
        };

        $scope.get();
    }]);
})(window.angular);