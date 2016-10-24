(function (angular) {
    "use strict";

    var schoolBus = angular.module("schoolBus", ["ngAnimate"]);

    schoolBus.directive("spinner", window.angularDirectives.spinner);

    schoolBus.directive("navigationContainer", window.angularDirectives.navigationContainer);

    schoolBus.directive("responsiveTableRendered", window.angularDirectives.responsiveTableRendered);

    schoolBus.directive("datePicker", window.angularDirectives.datePicker);

    schoolBus.directive("deleteConfirmation", window.angularDirectives.deleteConfirmation);

    schoolBus.directive("errorTooltip", window.angularDirectives.errorTooltip);

    schoolBus.controller("studentController", ["$scope", "$http", function ($scope, $http) {
        var validationMessage = "Existen errores en la información enviada.";
        var createStudent = function () {
            return {
                IsValid: true
            };
        };

        $scope.$parent.selectedNavbar = "Student";

        $scope.dataTableLanguage = {
            search: "Filtrar:",
            searchPlaceholder: "Filtrar Alumnos",
            emptyTable: "Sin Resultados",
            zeroRecords: "Sin Resultados",
            lengthMenu: "Mostrar _MENU_ Alumnos",
            info: "Mostrando _START_ to _END_ of _TOTAL_ Alumnos",
            infoEmpty: "Mostrando 0 a 0 de 0 Alumnos",
            infoFiltered: "(Studentes filtrados de _MAX_)"
        };

        $scope.students = [];
        $scope.currentStudent = createStudent();
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

        $scope.initStudent = function (student) {
            student.delete = function () {
                $scope.currentStudent = student;

                $scope.delete();
            };
        };

        $scope.edit = function (student) {
            $scope.pageSubTitle = "Edición";

            $scope.currentStudent = $.extend(true, {}, student);

            $scope.setEditMode();
        };

        $scope.cancelEdit = function () {
            $scope.pageSubTitle = "";

            $scope.currentStudent = createStudent();

            $scope.setReadMode();
        };

        $scope.get = function () {
            var getUrl = ("Student/Get?cache=").concat(new Date().valueOf());

            $scope.setSpinner(true);

            $scope.students = [];

            $http.get(getUrl).then(
                function (response) {
                    $scope.students = response.data;

                    $scope.renderTable = ($scope.students && $scope.students.length > 0);
                }, function () {
                    $scope.errorMessage = "Ocurrió un error en la consulta.";
                }).finally(function () {
                    $scope.setSpinner(false);
                });
        };

        $scope.add = function () {
            $scope.setSpinner(true);

            $http.post("Student/Add", $scope.currentStudent).then(
                function (response) {
                    $scope.currentStudent = response.data;

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

            $http.post("Student/Update", $scope.currentStudent).then(
                function (response) {
                    $scope.currentStudent = response.data;

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

            $http.post("Student/Delete", $scope.currentStudent).then(
                function () {
                    $scope.get();

                    $scope.cancelEdit();
                }, function () {
                    $scope.errorMessage = "Ocurrió un error al eliminar.";
                }).finally(function () {
                    $scope.currentStudent = createStudent();

                    $scope.setSpinner(false);
                });
        };

        $scope.get();
    }]);
})(window.angular);