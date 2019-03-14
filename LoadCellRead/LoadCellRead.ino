/*
 * LoadCellRead
 * Created for STORQUE and open source educational project
 * 
 * Team 8
 * 
*/

//must install 'HX711_ADC.h' library from library manager
#include <HX711_ADC.h>

const int clkPin = A1;
const int dtPin = A2;
HX711_ADC LoadCell(dtPin, clkPin);

void setup() {
  Serial.begin(9600);
  Serial.println("Ready to begin");
  LoadCell.begin();
  //stabilizing value used in example by library author
  long stabilisingtime = 2000;
  LoadCell.start(stabilisingtime);
}

void loop() {
  Serial.println(LoadCell.getData());
 
}
