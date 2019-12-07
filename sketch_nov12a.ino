#include <Ala.h>
#include <AlaLed.h>
#include <AlaLedRgb.h>
#include <ExtNeoPixel.h>
#include <ExtTlc5940.h>
#include <ExtTlc5940Config.h>

#include <Arduino.h>

#define REDPIN 3
#define BLUEPIN 5
#define GREENPIN 6

String data;

String colorStringData;
String redIntDataString;
String blueIntDataString;
String greenIntDataString;

float redFloat;
float greenFloat;
float blueFloat;

int redIntData;
int blueIntData;
int greenIntData;

AlaLedRgb rgbLed;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

  pinMode(6,OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(5, OUTPUT);

  redIntData = 255;
  blueIntData = 255;
  greenIntData = 255;
}

void loop() {
  // put your main code here, to run repeatedly;
	data = Serial.readString();
  colorStringData = Serial.readString();


 if(colorStringData.length()  > 2){
  redIntDataString = colorStringData.substring(0, 2);
  greenIntDataString = colorStringData.substring(3, 5);
  blueIntDataString = colorStringData.substring(6, 8);

  redIntData = redIntDataString.toInt();
  greenIntData = greenIntDataString.toInt();
  blueIntData = blueIntDataString.toInt();
 }
    analogWrite(REDPIN, redIntData);
    analogWrite(BLUEPIN, blueIntData);
    analogWrite(GREENPIN, greenIntData);
}


    
