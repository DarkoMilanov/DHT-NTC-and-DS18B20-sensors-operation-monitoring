#include <Arduino.h>
#include <LiquidCrystal.h>
#include <SimpleDHT.h>
#include <OneWire.h>
#include <DallasTemperature.h>
#define PINWIRE 10

OneWire oneWire(PINWIRE);
DallasTemperature sensors(&oneWire);
float tempC = 0;
float tempc1=0;


void NTC();
int pinDHT22 = 8;
SimpleDHT22 dht22(pinDHT22);
LiquidCrystal lcd(13, 12, 4, 5, 6, 7);
int ThermistorPin = A0;
int Vo;
float R1 = 10000;
float logR2, R2, T;
float c1 = 1.009249522e-03, c2 = 2.378405444e-04, c3 = 2.019202697e-07;

void setup () {
    Serial.begin(9600);
    lcd.begin(20,4);
    sensors.begin();
  }
  
void loop () {  

  lcd.clear();
  sensors.requestTemperatures();
  delay(1000);
  tempC =sensors.getTempCByIndex(0);
  lcd.setCursor(0,0);
  lcd.print("C: ");
  lcd.print(tempC);
  lcd.print(" stepeni");
  lcd.setCursor(0,1);
  delay(1000);
  lcd.clear();
  NTC(); //NTC i DHT
  Serial.println(tempC);

}

void NTC() //NTC i DHT22
{
  float vlaznost=0;
  float temperatura=0;
  dht22.read2(&temperatura,&vlaznost,NULL);
  
  Vo = analogRead(ThermistorPin);
  float Napon;
  R2 = R1 * (1023.0 / (float)Vo - 1.0);
  logR2 = log(R2);
  T = (1.0 / (c1 + c2*logR2 + c3*logR2*logR2*logR2));
  T = T - 273.15;
  T = (T * 9.0)/ 5.0 + 32.0; 
  Napon=(float)Vo*5/1023;
    lcd.setCursor(0,0);
  lcd.print("NTC: ");
  lcd.print(Napon);   
  lcd.print(" V");
  lcd.setCursor(0,1);           
  
  lcd.print("temperatura: ");
  lcd.print(temperatura);
  lcd.print("*C");
  lcd.setCursor(0,2); 
  lcd.print("vlaznost: "); 
  lcd.print(vlaznost);
  lcd.print("%");
  delay(1000);
  Serial.println(Napon);
  Serial.println(temperatura);
  Serial.println(vlaznost);
  
}