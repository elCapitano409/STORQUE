/*
 * LoadCellRead
 * Created for STORQUE and open source educational project
 * 
 * Team 
 * 
*/

//pin to read from load cell
const int sensorPin = A0;
//value that will be read from load cell
int sensorValue = 0;

void setup() {

  //set pin to input
  pinMode(sensorPin, INPUT);

  //set baud rate to 9600
  Serial.begin(9600);
}

void loop() {

  //delay by 10 milliseconds
  delay(10);

  //read voltage from pin and output to serial
  sensorValue = analogRead(sensorPin);
  Serial.write(sensorValue);
}
