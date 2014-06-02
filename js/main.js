require.config({
  baseUrl: '/js',
  paths: {
    /* Load jquery from google cdn. On fail, load local file. */
    'jQuery': ['//ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min'],// 'libs/jquery-min'],
    /* Load bootstrap from cdn. On fail, load local file. */
    'bootstrap': ['//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min'],// 'libs/bootstrap-min'],
    'angular': '//code.angularjs.org/1.2.0-rc.2/angular',
    'angular.route': '//code.angularjs.org/1.2.0-rc.2/angular-route.min',
    'ui.router': '//cdnjs.cloudflare.com/ajax/libs/angular-ui-router/0.2.10/angular-ui-router.min'
  },
  shim: {
    'angular' : {'exports' : 'angular'},
    'angular.route': ['angular'],
    'jQuery': {'exports' : 'jQuery'},
    'bootstrap': ['jQuery'],
    'ui.router': ['angular']
  }
});

require(['jQuery', 'angular', 'app', 'bootstrap', 'ui.router'] , function ($, angular) {
  $(function () { // using jQuery because it will run this even if DOM load already happened
    angular.bootstrap(document , ['app']);
  });
});