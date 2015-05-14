(function(){
	'use strict';
	angular.module('classified.services.ClassifiedService')
		.factory('Classified', Classified);

		Classified.$inject = ['$http', '$routeParams'];

		function Classified($http, $routeParams){
			var Classified = {
				getCategories: getCategories,
				getClassifiedList: getClassifiedList,
				getCities: getCities
			};

			return Classified;

			function getClassifiedList(){
				if (!$routeParams.categoryId)
				    return $http.get('/api/ClassifiedAdsAPI/GetClassifiedAds');
				else
				    return $http.get('/api/ClassifiedAdsAPI/GetClassifiedAds/' + $routeParams.categoryId);
				
			}

			function getCategories(){
			    return $http.get('/api/ClassifiedAdsAPI/GetCategories');
			}

			function getCities(){
			    return $http.get('/api/ClassifiedAdsAPI/GetCities');
			}
		}
})();