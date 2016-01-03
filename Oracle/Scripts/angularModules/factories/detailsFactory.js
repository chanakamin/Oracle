(function () {
    var factory = angular.module("factoryModule").factory("DetailsFactory", function($http, resourcesFactory){
        // arrays of details
        var nutritionals = [],
            measurements = [],
            measureTypes = [],
            userId = 0;
        return {
            // function to init resources from resources factory
            init: function () {
                var data = resourcesFactory.getResource('details');
                nutritionals = data.nutritionalValues;
                measurements = data.measurements;
                measureTypes = data.measureTypes;
                userId = data.userId;
            },
            // functions to get lists of details
            getMeasurement: function (id) {
                var res = -1;
                angular.forEach(measurements, function (value) {
                    if (value.id === id)
                        res =  value;
                });
                return res;
            },
            nutritionalsValues: function () {
                return nutritionals;
            },
            measurements: function () { return measurements; },
            measureTypes: function () { return measureTypes; },
            userId: function () { return userId }
        }
    })
})();