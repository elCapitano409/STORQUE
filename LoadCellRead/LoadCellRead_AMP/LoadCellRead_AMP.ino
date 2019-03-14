/*
 * LoadCellRead_AMP
 * Created for STORQUE and open source educational project
 * Code to read change in weights from a four pin load cell using an external amplifier circuit
 * 
 * Team 8
 * 
*/

//declare analog pin to read value
const int inPin = A0;
//amount of times the load cell is checked per second
const int sampleRate = 500;

void setup() {

  char logo[] = "███████╗████████╗ ██████╗ ██████╗  ██████╗ ██╗   ██╗███████╗/n██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔═══██╗██║   ██║██╔════╝/n███████╗   ██║   ██║   ██║██████╔╝██║   ██║██║   ██║█████╗  /n╚════██║   ██║   ██║   ██║██╔══██╗██║▄▄ ██║██║   ██║██╔══╝  /n███████║   ██║   ╚██████╔╝██║  ██║╚██████╔╝╚██████╔╝███████╗/n╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝ ╚══▀▀═╝  ╚═════╝ ╚══════╝";
  
  //set input pin to input mode
  pinMode(A0, INPUT);

  //set baud rate
  //must be same rate that serial monitor is running
  Serial.begin(9600);

  //output team logo
  //if nothing is output to serial monitor then there is problem with arduino communicating with computer
  Serial.println(logo);
}

void loop() {
  //delay by sample period
  delay(1000/sampleRate);

  //read the raw value and output to computer
  Serial.println(analogRead(inPin));
}
