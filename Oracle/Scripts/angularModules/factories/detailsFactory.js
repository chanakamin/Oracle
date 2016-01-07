(function () {
    var factory = angular.module("factoryModule").factory("DetailsFactory", function($http, resourcesFactory){
        // arrays of details
        var nutritionals = [],
            measurements = [],
            measureTypes = [],
            userId = 0;
        // function to calculate amount per requested measurement
        function requestAmount(curAmount, curMeasurement, reqMeasurement, weightVolume) {
            if (curMeasurement.id == reqMeasurement.id)
                return curAmount;
            var amount_per_base = curAmount * curMeasurement.amount;
            var baseCur = getMeasurement(curMeasurement.measurement_id), baseReq = getMeasurement(reqMeasurement.measurement_id);
            var amount_per_reqB;
            if (baseReq.id == baseCur.id)
                amount_per_reqB = amount_per_base;
            else if (baseCur.id == 1) // convert from weight to volume
                amount_per_reqB = amount_per_base / weightVolume;
            else if (baseCur.id == 2) //convert from volume to weight
                amount_per_reqB = amount_per_base * weightVolume;
            else   // calory / error
                amount_per_reqB == -1
            // convert from base_req to req
            return amount_per_reqB * reqMeasurement.amount;
        }
        function calcAmountNut(nutritionalProduct, product, amount,measurementId) {
            var product_amount_per_base = requestAmount(amount,getMeasurement(measurementId), getMeasurement(product.measure_type.id), product.amount_weight_in_volume);
            var ratio = product_amount_per_base / 100;
            var result = ratio * nutritionalProduct.amount_per_100;
            return result;
        }
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
                userId = data.userId; 
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
            requestAmount: requestAmount,
            calcNutrition: function (productsRecipe, ProductsFactory) {
                var nut = [];
                var pr, nu;
                angular.forEach(nutritionals, function (n) {
                    nut.push({name:n.name, value:0,id: n.id});
                });
                angular.forEach(productsRecipe,function (p){
                    pr = ProductsFactory.getProduct(p.product_id)
                    angular.forEach(nut,function(n){
                        nu = pr.nutritionalValue.filter(function(nutr){
                            return nutr.nutritional_value_id == n.id;
                        })[0];
                        if(nu && pr && p)
                             n.value += calcAmountNut(nu,pr,p.amount,p.measurements_id);
                    });
                })
                return nut;
            }
        }
    })
})();
//{"id":13,"recipe_id":12,"product_id":32,"measurements_id":1,"amount":200,"measurement":null,"product":null,"recipe":null}
