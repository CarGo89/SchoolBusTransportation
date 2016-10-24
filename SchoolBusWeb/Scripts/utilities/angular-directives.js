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
                        setTimeout(function () {
                            element.parents("table:first").dataTable({
                                destroy: true,
                                responsive: true,
                                autoWidth: true,
                                sort: true,
                                order: [[0, "asc"]],
                                language: scope.dataTableLanguage
                            });
                        }, 10);
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
                        format: "MM/DD/YYYY",
                        maxDate: new Date()
                    });

                    element.datetimepicker().on("dp.change", function (e) {
                        $(e.currentTarget).change();
                    });
                }
            };
        },

        deleteConfirmation: function () {
            return {
                restrict: "A",

                link: function (scope, element) {
                    element.confirmation({
                        btnOkLabel: "",
                        btnCancelLabel: "",
                        title: "¿Estás seguro?",
                        placement: "top",
                        trigger: "click",

                        onConfirm: function () {
                            if (typeof scope.entity.delete === "function") {
                                scope.entity.delete.call(this);
                            }
                        }
                    });
                }
            };
        },

        errorTooltip: function () {
            return {
                restrict: "A",

                scope: {
                    modelProperty: "=modelProperty"
                },

                link: function (scope, element) {
                    element.tooltip({
                        title: function () {
                            return scope.modelProperty && scope.modelProperty.IsValid !== true ? scope.modelProperty.ErrorMessage : "";
                        }
                    });

                    scope.$watch("modelProperty.IsValid", function (oldValue, newValue) {
                        if (newValue === false) {
                            element.tooltip("hide");
                        }
                    });
                }
            };
        }
    };
})();