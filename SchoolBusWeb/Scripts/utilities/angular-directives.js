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
                    order: [[0, "asc"]],
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

                    if (scope.data && scope.data.length === 0) {
                        initDataTable(scope, element);
                    }
                }
            };
        },

        datePicker: function() {
            return {
                restrict: "A",

                link: function(scope, element) {
                    element.datetimepicker({
                        useCurrent: false,
                        format: "MM/DD/YYYY"
                    });

                    element.datetimepicker().on("dp.change", function(e) {
                        $(e.currentTarget).change();
                    });
                }
            };
        }
    };
})();