﻿(function () {
    function fac() {
        var dtf , prf , recf ;
        // function to calculate amount per requested measurement
        // arguments: the current amount and measurement, requested measurement and specific weight
        function requestAmount(curAmount, curMeasurement, reqMeasurement, product) {
            if (curMeasurement.id == reqMeasurement.id)
                return curAmount;
            var amount_per_base = curAmount,
                amount_per_reqB;
            var baseCur = dtf.getMeasurement(curMeasurement.measurement_id),
                baseReq = dtf.getMeasurement(reqMeasurement.measurement_id);
            // if measurement is unit
            if (curMeasurement.id === curMeasurement.measurement_id && curMeasurement.id !== curMeasurement.measure_type) {
                amount_per_base *= product.unit_amount;
                amount_per_reqB = amount_per_base * product.amount_weight_in_volume;
            }
            else {
                amount_per_base *= curMeasurement.amount;
                if (baseReq.id == baseCur.id)
                    amount_per_reqB = amount_per_base;
                else if (baseCur.id == 1) // convert from weight to volume
                    amount_per_reqB = amount_per_base / product.amount_weight_in_volume;
                else if (baseCur.id == 2) //convert from volume to weight
                    amount_per_reqB = amount_per_base * product.amount_weight_in_volume;
            }
            // convert from base_req to req
            return amount_per_reqB * reqMeasurement.amount;
        }
        // this function returns amount of base measurement of product
        // arguments: product object, measurementId it now being measured, the amount
        function amountPerBase(product, measurementId, amount) {
            var cur_measurement = dtf.getMeasurement(measurementId),
                requested_measurement = dtf.getMeasurement(product.measure_type.id);
            return requestAmount(amount, cur_measurement, requested_measurement, product);
        }

        // This function calculate nutritional value amount in product upon its amount per base
        // arguments: product_in_nutritionalValue object, amount per base
        function calcAmountNut(nutritionalProduct, product_amount_per_base) {
            var ratio = product_amount_per_base / 100;
            var result = ratio * nutritionalProduct.amount_per_100;
            return result;
        }

        return {
            init: function () {
                var fact = angular.module('factoryModule').factories;
                dtf = fact.details, prf = fact.products, recf = fact.recipes;
            },
            requestAmount: requestAmount,
            multiplyNutritionals: function (initNutritionals, multBy) {
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
            // this function returns array of nutritionals values for products list - productsRecipe.
            calcNutrition: function (productsRecipe) {
                var nut = [], nutritionals = dtf.nutritionalsValues();
                var pr, nu;
                var amount_per_base;
                // prepare array of nutritional result, value is steal empty.
                angular.forEach(nutritionals, function (n) {
                    var obj = { name: n.name, value: 0, id: n.id };
                    nut.push(obj);
                    nut[n.name] = obj;
                });
                // loop on every product to add his nutritionals to array
                angular.forEach(productsRecipe, function (p) {
                    // pr - regular product
                    pr = prf.getProduct(p.product_id)
                    amount_per_base = amountPerBase(pr, p.measurements_id, p.amount);
                    // loop for every nutritional to calc its value and add it to the array
                    angular.forEach(nut, function (n) {
                        // find the nutritional in product element in product's array of it
                        nu = pr.nutritionalValue.filter(function (nutr) {
                            return nutr.nutritional_value_id == n.id;
                        })[0];
                        if (nu && pr && p)
                            // add the nutritional amount
                            n.value += calcAmountNut(nu, amount_per_base);
                    });
                })
                return nut;
            }
        }
    }
    angular.module("factoryModule").factory('convertFactory',[fac]);
})();