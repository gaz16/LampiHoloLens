var mqtt = require('mqtt');
var host = 'wss://ec2-34-199-107-106.compute-1.amazonaws.com:50002';
var deviceId = 'b827ebfef9da'
var lampchanged = "/devices/" + deviceId + "/lamp/changed";
var setconfig = "/devices/" + deviceId + "/lamp/set_config";
var fs = require("fs");
var key = fs.readFileSync('/etc/mosquitto/certs/lampi_mqtt_server.key');
var certificate = fs.readFileSync('/etc/mosquitto/certs/lampi_mqtt_server.crt');
var ca_file = fs.readFileSync('/etc/mosquitto/ca_certificates/lampi_ca.crt');
var clientId = '0.26787113831841713_web_client';

var options = {
    keepalive: 10,
    clientId: clientId,
    protocolId: 'MQTT',
    protocolVersion: 4,
    clean: true,
    reconnectPeriod: 1000,
    connectTimeout: 30000,
    rejectUnauthorized: false,
    ca: ca_file,
    key: key,
    cert: certificate
};

var lampstate = {'color':{'h':0.5, 's':0.5}, 'brightness':0.5, 'on':true};
var client = mqtt.connect(host, options);


client.on('connect', function (err) {
       console.log("Connecting!*******");
        client.subscribe("/devices/" + deviceId + "/lamp/changed");
        console.log("Subscribed!***");
});

exports.change_lamp = function(message) {
        console.log("Sending message to lamp!***");
        client.publish(setconfig, message);
}

exports.get_state = function(){
        return lampstate;
}
