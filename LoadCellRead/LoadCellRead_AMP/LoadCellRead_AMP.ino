/*
 * LoadCellRead_AMP
 * Created for STORQUE and open source educational project
 * Code to read change in weights from a four pin load cell using an external amplifier circuit
 * 
 * Team 8
 * 
*/

//amplification pin
const int inPin = A0;
//calibration pin 
const int btPin = 3;
//amount of times the load cell is checked per second
const int sampleRate = 1000;
//calibration offset
int offset = 0;

void setup() {

  
  //set input pin to input mode
  pinMode(inPin, INPUT);

  //set pullup pin
  pinMode(btPin, INPUT_PULLUP);

  //set baud rate
  //must be same rate that serial monitor is running
  Serial.begin(9600);

  //if nothing is output to serial monitor then there is problem with arduino communicating with computer
}

void loop() {

  //value of calibration pin
  int calCheck;
  //read from button pin
  calCheck = digitalRead(btPin);

  //if calibration button is pressed
  if(calCheck == 0){
    offset = analogRead(inPin);
  }
  
  //delay by sample period
  delay(1000/sampleRate);

  //output offset value
  Serial.println(analogRead(inPin) - offset);
}
