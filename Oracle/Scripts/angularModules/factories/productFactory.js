(function () {
    /* Factory to save all function of product */
    angular.module("factoryModule").factory("ProductsFactory", function (resourcesFactory, DetailsFactory) {
        var products = [];

        // create new product object
        function Product(productName,description,weight_in_volume){
            this.name = productName;
            this.description;
            this.weight_in_volume = weight_in_volume;
        }

        // orginized list of products from server call
        var orginizedList = function (product, add) {
            if (!add)
                products = [];
            var p;
            angular.forEach(product, function (value) {
                p = value.product;
                angular.forEach(p, function (val, key) {
                    if (!val)
                        delete p[key];
                });
                p.nutritionalValue = value.nutritional;
                products.push(p);
            });
        }
        

        //  add product to db
        var addProductToDb = function (product, nutritionals, Volume, Weight) {
            var config = {
                addProduct: product,
                nutritionals: nutritionals
            };
            resourcesFactory.addResource('addProduct', config)
                    .then(function (data) {
                        debugger;
                        var p = angular.fromJson(data).data.p;
                        product.id = p.id;
                        product.volume = p.measurements_id_volume;
                        product.weight = p.measurements_id_weight;
                        products.push(product);
                        console.log("add product succeed");
                    });
                    //});
                    //.error(function (e) {
                    //    console.log("add product fail");
                    //});
        };
        var initProductsFromDb = function () {
            resourcesFactory.initResource('getProduct', 'products')
                .success(function (data) {
                    console.log("in init from db");
                    console.log(data);
                    orginizedList(data);
                })
                 .error(function (er) {
                     console.log(er);
                 });
        }
        //Those functions for use
        return {
            // init list of products
            initProducts: function (init) {
                if (init)
                    initProductsFromDb();
                else {
                    var r = resourcesFactory.getResource("products");
                    orginizedList(r);
                }
            },            
            // get list of all products
            getProducts: function () {
                if (products.length === 0) {
                    this.initProducts();
                }
                return products;                    
            },
            getLength: function () {
                return products.length;
            },
            //add product to list
            createProduct: function (productName,description,weight,volume,amount) {
                var product = new Product(productName,description,amount);
                products.push(product);
                addProductToDb(product, volume, weight);
                return product;
            },
            addProduct: function (product, nutritionalsValues) {
                var userId = DetailsFactory.userId();
                if (userId > 0) {
                    product.userId = userId;
                    addProductToDb(product, nutritionalsValues);
                }
            }
        };
    });
})();