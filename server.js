/**
 * Created by rmirdb on 5/6/2014.
 */

var express 	= require('express');
var fs 		= require('fs');
var bodyParser 	= require('body-parser');
var methodOverride = require('method-override');
var app 	   = express();
var mongoose       = require('mongoose');
var passport       = require('passport');
var flash	   = require('connect-flash');
var cookieParser   = require('cookie-parser');
var morgan	   = require('morgan');
var session	   = require('express-session');

var configDB	= require('./config/database.js');

//configuration
mongoose.connect( configDB.url );
require('./config/passport')(passport); // pass passport for configuration

app.use(morgan('dev'));
app.use(bodyParser({limit: '50mb'}));
app.use(methodOverride());
app.use(cookieParser());

app.set('view engine', 'ejs'); // set up ejs for templating

// required for passport
app.use(session({ secret: 'pickupgames39495-23894584jdfualdfiahfasf' })); // session secret
app.use(passport.initialize());
app.use(passport.session()); // persistent login sessions
app.use(flash()); // use connect-flash for flash messages stored in session


app.use(express.static(__dirname));


/*app.get('/', function(req, res){
    res.send('hello world');
});*/

// routes ======================================================================
require('./app/routes.js')(app, passport); // load our routes and pass in our app and fully configured passport

app.listen(8000);
