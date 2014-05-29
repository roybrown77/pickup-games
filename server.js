/**
 * Created by rmirdb on 5/6/2014.
 */

var express = require('express');
var fs = require('fs');
var bodyParser = require('body-parser');
var methodOverride = require('method-override');
var app = express();

app.use(bodyParser({limit: '50mb'}));
app.use(methodOverride());
app.use(express.static(__dirname));
app.get('/', function(req, res){
    res.send('hello world');
});
app.listen(8000);