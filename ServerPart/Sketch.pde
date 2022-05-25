import mqtt.*;
import processing.serial.*;

MQTTClient client;
JSONObject json;
Serial myPort;
String temp ;
String humid;

void setup() 
{ 
  client = new MQTTClient(this);   
  client.connect("mqtt://2NMhdlPzJrAI6ZiJ4seX@demo.thingsboard.io");
   printArray(Serial.list());
   myPort = new Serial(this, Serial.list()[0], 9600);
   myPort.bufferUntil(10); 
}

void draw() {
  if ( myPort.available() > 0)
 { 
    temp = myPort.readStringUntil('\n');    
    humid = myPort.readStringUntil('\n');
    println("Temp: " + temp);
    println("Humid: " + humid);
    if(temp != null && humid != null)
    {
      json = new JSONObject(); 
      json.setFloat("Temperature",float(temp));
      json.setFloat("Humidity",float(humid));
      client.publish("v1/devices/me/telemetry", json.toString());
    }
  }
}

void clientConnected() {
  println("client connected");
  client.subscribe("v1/#");
}

void messageReceived(String topic, byte[] payload) {
  println("new message: " + topic + " - " + new String(payload));
}

void connectionLost() {
  println("connection lost");
}
