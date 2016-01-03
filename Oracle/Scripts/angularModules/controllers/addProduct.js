// Controller for add product
angular.module("controllers").controller('addProductCtrl', function ($scope, ProductsFactory, DetailsFactory) {
    // text will be shown in the view
    $scope.text = {
        title: "new product",
        name: "nutritional",
        value: "value",
        amount: "Weight of one mililiter of this product: "
    };
    // nutritional values from details factory
    var mustNutrition = DetailsFactory.nutritionalsValues();

    // prepare list of nutritionals values to be nutritionals of product
    angular.forEach(mustNutrition, function (value, key) {
        mustNutrition[key] = {
            idNutritional: value.id,
            name: value.name,
            amount: 0.0,
            measurement: DetailsFactory.getMeasurement(value.measurements_id)
        };
        if (!angular.isObject(mustNutrition[key].measurement)) {
            mustNutrition[key].measurement = "";
        }
        else
            mustNutrition[key].alias = mustNutrition[key].measurement.alias;
    });
    $scope.mustNutrition = mustNutrition;

    // prepare product object to be added 
    var p = $scope.product = {
        name: "",
        description: "",
        weight_in_volume: "",
        mustNutrition: mustNutrition
    };

    // onSubmit function
    $scope.SubmitProduct = function () {
        var nutritionalsValues = [];
        angular.forEach(p.mustNutrition, function (value) {
            nutritionalsValues.push({
                idNutritional: value.idNutritional,
                amount:value.amount
            });
        });
        delete p.mustNutrition;
        ProductsFactory.addProduct(p, nutritionalsValues);
    };   
});
