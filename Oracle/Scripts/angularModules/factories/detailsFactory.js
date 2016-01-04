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
                var that = this;
                var data = resourcesFactory.getResource('details');
                nutritionals = data.nutritionalValues;
                measurements = data.measurements;
                measureTypes = data.measureTypes;
                userId = data.userId; 
                angular.forEach(nutritionals, function (value) {
                    value.measurement = that.getMeasurement(value.measurements_id);
                });
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
            userId: function () { return userId },
            // function for nutritionals values
            multiplyNutritionals: function (initNutritionals,multBy) {
                var multNutritionals = [];
                var nut;
                angular.forEach(initNutritionals, function (value) {
                    multNutritionals.push({
                        id: value.id,
                        nutritional_value_id: value.nutritional_value_id,
                        product_id: value.product_id,
                        amount: value.amount_per_100 * multBy
                    });
                });
                return multNutritionals
            },
            // function to calculate amount per requested measurement
            requestAmount: function (curAmount, curMeasurement, reqMeasurement, weightVolume) {
                var amount = curAmount;

            }
        }
    })
})();