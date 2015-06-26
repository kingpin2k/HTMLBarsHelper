App = Em.Application.create();

App.Router.map(function () {
    this.route('colors');
});

App.ColorsRoute = Em.Route.extend({
    model: function () {
        return ['red', 'yellow', 'blue'];
    }
});

App.ColorsController = Em.Controller.extend();