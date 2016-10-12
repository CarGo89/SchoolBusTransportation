(function () {
    "use strict";

    angular.module("schoolBus", []).config(["$httpProvider", function ($httpProvider) {
        $httpProvider.defaults.cache = false;
    }]);

    window.angularDirectives = {
        spinner: function () {
            return {
                restrict: "A",

                link: function (scope) {
                    scope.spinnerActive = true;
                }
            };
        },

        navigationContainer: function () {
            return {
                restrict: "A",

                link: function (scope) {
                    scope.pageMode = "read";

                    scope.setReadMode = function () {
                        scope.pageMode = "read";
                    };

                    scope.setEditMode = function () {
                        scope.pageMode = "edit";
                    };
                }
            }
        },

        responsiveTableRendered: function () {
            return {
                restrict: "A",

                link: function (scope, element) {
                    if (scope.$last === true) {
                        element.parents("table:first").dataTable({
                            destroy: true,
                            responsive: true,
                            autoWidth: true,
                            sort: true,
                            order: [[0, "asc"]],
                            language: scope.dataTableLanguage
                        });
                    }
                }
            };
        },

        datePicker: function () {
            return {
                restrict: "A",

                link: function (scope, element) {
                    element.datetimepicker({
                        useCurrent: false,
                        format: "MM/DD/YYYY"
                    });

                    element.datetimepicker().on("dp.change", function (e) {
                        $(e.currentTarget).change();
                    });
                }
            };
        }
    };
})();