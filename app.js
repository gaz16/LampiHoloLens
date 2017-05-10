var mqtt_client = require('./mqtt_client'); 
var express = require('express'); 
var app = express(); 
var bodyParser = require('body-parser') 
app.use(bodyParser.json()); 
 
var lampstate = {'color':{'h':0.5, 's':0.5}, 'brightness':0.5, 'on':true}; 
 
app.post('/lampi', function (req, res) { 
        console.log(req.body); 
        console.log(JSON.stringify(req.body)); 
        mqtt_client.change_lamp(JSON.stringify(req.body)); 
        res.json('OK: 200') 
}); 
 
app.get('/lampi', function (req, res) { 
        res.json(mqtt_client.get_state()); 
}); 

app.listen(3001, function () {
        console.log('Example app listening on port 3001!')
});
