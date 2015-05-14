(function(){

	angular.module("app",[
		//'common',
        'flow',
		'app.route',
		//'authentication',
		'classified',
		'comments',
		
		]);

	angular.module('app.route',['ngRoute']);
	angular.module('classified',[
		'classified.controllers',
		'classified.controllers.CategoryListController',
		'classified.services.ClassifiedService'
		]);

	angular.module('comments',[
		'comments.controllers.CommentsController',
		'comments.services.CommentsService'
		]);

	//angular.module('common',[
	//	'common.services.CommonService'

	//	]);

	/*
	angular.module('authentication',[
		'authentication.controllers.AuthController',
		'authentication.services.Auth'
		]);
*/
})();


