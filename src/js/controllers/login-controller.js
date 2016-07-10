app.controller('userController', ['$scope', 'User', function($scope, User) {

  $scope.show = true;

  $scope.loginData = {
    usuario: 'celiano',
    password: 'nspweb',
    country: 'CO'
  };

  $scope.logear = function (data) {
    var newDate = new Date();
    var logearRequest = User.logear(data);

    logearRequest.success(function (data, status, header, config) {
      console.log("data.succeded = true");
      console.log(data);
      if (data.succeded == true && data.data != null) {
        $scope.show = false;
      }       
    })
  }

}])