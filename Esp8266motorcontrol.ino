
#include <ESP8266WiFi.h>
#include <MQTT.h>

const char ssid[] = "KNSLAPTOP";
const char pass[] = "123456789.";
const int D1 = 5;
const int D2 = 4;
const int D3 = 0;
const int D4 = 2;

WiFiClient wificlient;
MQTTClient client;


void connect() {
  Serial.print("checking");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(1000);
  }

  Serial.print("\nconnecting");
  if(client.connect("ESP8266_1","public","public")){
    Serial.println("\nconnected!");
    client.subscribe("robot/device1/com");
    client.publish("robot/device1/status","Connected",true,0);
  }
}


void reconnect(){
  while(!client.connected()){
    Serial.println("Reconnecting to MQTT server...");
    if (client.connect("ESP8266_1", "public","public")) {
      Serial.println("Reconnected to MQTT server");
      client.subscribe("robot/device1/com");
      client.publish("robot/device1/status","Connected",true,0);
    } else {
      Serial.println("Reconnection to MQTT server failed, will try again in 5 seconds");
      delay(5000);
    }
  }
}

void messageReceived(String &topic, String &payload) {
  Serial.println("incoming: " + topic + " - " + payload);
  if (payload == "ileri"){
    digitalWrite(D1,LOW);
    digitalWrite(D2,LOW);
    digitalWrite(D3,HIGH);
    digitalWrite(D4,HIGH);
    
  }
  else if(payload =="geri"){
    digitalWrite(D3,LOW);
    digitalWrite(D4,LOW);
    digitalWrite(D1,HIGH);
    digitalWrite(D2,HIGH);

  }
  else if(payload =="sag"){
    digitalWrite(D3,LOW);
    digitalWrite(D2,LOW);
    digitalWrite(D1,LOW);
    digitalWrite(D4,HIGH);

  }
  else if(payload =="sol"){
    digitalWrite(D1,LOW);
    digitalWrite(D4,LOW);
    digitalWrite(D2,LOW);
    digitalWrite(D3,HIGH);


  }
  else{
    digitalWrite(D1,LOW);
    digitalWrite(D2,LOW);
    digitalWrite(D3,LOW);
    digitalWrite(D4,LOW);

  }
  // Note: Do not use the client in the callback to publish, subscribe or
  // unsubscribe as it may cause deadlocks when other things arrive while
  // sending and receiving acknowledgments. Instead, change a global variable,
  // or push to a queue and handle it in the loop after calling `client.loop()`.
}

void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, pass);
  pinMode(D1,OUTPUT);
  pinMode(D2,OUTPUT);
  pinMode(D3,OUTPUT);
  pinMode(D4,OUTPUT);
  digitalWrite(D1,LOW);
  digitalWrite(D2,LOW);
  digitalWrite(D3,LOW);
  digitalWrite(D4,LOW);


  // Note: Local domain names (e.g. "Computer.local" on OSX) are not supported
  // by Arduino. You need to set the IP address directly.
  client.begin("broker.kerembilgicer.com",1883, wificlient);
  client.onMessage(messageReceived);
  client.setWill("robot/device1/status","Disconnected",true,0);

  connect();
}

void loop() {
  client.loop();
  delay(10);  // <- fixes some issues with WiFi stability

  if (!client.connected()) {
    reconnect();
  }
}
