/*
 * LoadCellRead_HX711
 * Created for STORQUE and open source educational project
 * Code to read change in weights from a four pin load cell using a HX711 amplifier board
 * 
 * Team 8
 * 
*/

//must install 'HX711_ADC.h' library from library manager
//examples can be found on https://github.com/olkal/HX711_ADC/tree/master/examples
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
