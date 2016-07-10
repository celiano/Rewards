app.factory('User', ['$http', function ($http) {
	
		var user = {};
		var baseUrl = "http://localhost:35448";
		var apiName = "/api/User";

		user.logear = function (data) {
			console.log(baseUrl + apiName + "?userName=" + data.usuario + "&password=" + data.password);
			return $http.get(baseUrl + apiName + "?userName=" + data.usuario + "&password=" + data.password);
		}
		return user;
	}
])