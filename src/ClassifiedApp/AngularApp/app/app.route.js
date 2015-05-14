(function(){

	'use strict';

	angular.module('app.route').config(config);

	config.$inject = ['$routeProvider'];

	function config($routeProvider){
		$routeProvider
			.when('/', {
				controller: "ClassifiedListController",
				controllerAs: "vm",
				templateUrl: "AngularApp/templates/classified_ads/index.html"
				})
			.when('/:categoryId',{
			    templateUrl: "AngularApp/templates/classified_ads/index.html",
				controller: "ClassifiedListController",
				controllerAs: "vm"
			}).otherwise('/');
	};

})();