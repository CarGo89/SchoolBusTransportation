(function () {
    "use strict";

    angular.module("schoolBus", []);

    window.angularDirectives = {
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

        responsiveDataTable: function () {
            var initDataTable = function (scope, element) {
                element.dataTable({
                    destroy: true,
                    responsive: true,
                    autoWidth: true,
                    deferRender: true,
                    sort: true,
                    order: [[0, "desc"]],
                    language: scope.dataTableLanguage
                });
            };

            return {
                restrict: "A",

                link: function (scope, element) {
                    scope.initDataTable = function (render) {
                        if (render === true) {
                            initDataTable(scope, element);
                        }
                    };

                    if (scope.data.length === 0) {
                        initDataTable(scope, element);
                    }
                }
            };
        }
    };
})();