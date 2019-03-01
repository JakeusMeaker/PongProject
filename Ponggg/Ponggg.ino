const int playerOne = A0;
const int playerTwo = A1;

int oneVal;
int twoVal;

int incomingByte;

int plyr1Led1 = 3;
int plyr1Led2 = 5;
int plyr2Led1 = 6;
int plyr2Led2 = 9;

bool plyr1Wins = false;
bool plyr2Wins = false;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(plyr1Led1, OUTPUT);
  pinMode(plyr1Led2, OUTPUT);
  pinMode(plyr2Led1, OUTPUT);
  pinMode(plyr2Led2, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:

  if(Serial.available() > 0){
    incomingByte = Serial.read();
    if(incomingByte == 'P'){
      SendPositions();
    }
    if(incomingByte == 'a'){
      digitalWrite(plyr1Led1, HIGH);
    }
    if(incomingByte == 'b'){
      digitalWrite(plyr1Led2,HIGH);
      plyr1Wins = true;
    }
    if(incomingByte == 'c'){
      digitalWrite(plyr2Led1, HIGH);
    }
    if(incomingByte == 'b'){
      digitalWrite(plyr2Led2, HIGH);
      plyr2Wins = true;
      PlayerWins();
    }
    if(incomingByte == 'r'){
      Reset();
    }
    if(incomingByte == 'w'){
      PlayerWins();
    }
    if(incomingByte == 'o'){
      Reset();
    }
  }
}

void SendPositions(){
  oneVal = analogRead(playerOne);
  twoVal = analogRead(playerTwo);

  Serial.print(oneVal);
  Serial.print('-');
  Serial.println(twoVal);
}

void PlayerWins(){
   
  if(plyr1Wins){
    digitalWrite(plyr2Led1, LOW);
    digitalWrite(plyr2Led2, LOW); 
    digitalWrite(plyr1Led1, LOW);
    digitalWrite(plyr1Led2, LOW);
    delay(100);
    digitalWrite(plyr1Led1, HIGH);
    digitalWrite(plyr1Led2, HIGH);
    }        
  

  if(plyr2Wins){
    digitalWrite(plyr1Led1, LOW);
    digitalWrite(plyr1Led2, LOW);    
    digitalWrite(plyr2Led1, LOW);
    digitalWrite(plyr2Led2, LOW);
    delay(100);
    digitalWrite(plyr2Led1, HIGH);
    digitalWrite(plyr2Led2, HIGH);
    }       
  }


void Reset(){
    digitalWrite(plyr1Led1, LOW);
    digitalWrite(plyr1Led2, LOW);
    digitalWrite(plyr2Led1, LOW);
    digitalWrite(plyr2Led2, LOW);
}
