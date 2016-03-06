/// <reference path="../../../plugin/own.js" />
(function () {
    var factory = angular.module("factoryModule").factory("DetailsFactory", function($http, resourcesFactory){
        // arrays of details
        var nutritionals = [],
            measurements = [],
            measureTypes = [],
            user = 0;
        
        // function to get measurement per id
        function getMeasurement(id)
        {
            var res = -1;
            angular.forEach(measurements, function (value) {
                if (value.id === id)
                    res =  value;
            });
            return res;
        }
        return {
            // function to init resources from resources factory
            init: function () {
                var that = this;
                var data = resourcesFactory.getResource('details');
                nutritionals = data.nutritionalValues;
                measurements = data.measurements;
                measureTypes = data.measureTypes;
                user = data.user; 
                angular.forEach(nutritionals, function (value) {
                    value.measurement = that.getMeasurement(value.measurements_id);
                });
            },
            // functions to get lists of details
            getMeasurement: getMeasurement,
            nutritionalsValues: function () {
                return nutritionals;
            },
            measurements: function () { return measurements; },
            measureTypes: function () { return measureTypes; },
            user: function () { return user },
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
            // this function returns object contains default options for convertions:
            // -multiply - 1
            // - measure_type  - tools,
            // - convert_units  - false
            defaultConvertObject: function () {
               return {
                    multiply: 1,
                    measurement_type: measureTypes.filter(function (m) {
                        return m.measure_type1 === 'tools';
                    })[0],
                    convert_units: 0,
                };
            },
        }
    })
})();
//{"id":13,"recipe_id":12,"product_id":32,"measurements_id":1,"amount":200,"measurement":null,"product":null,"recipe":null}
