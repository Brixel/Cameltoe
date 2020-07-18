#include <Arduino.h>
#include <Adafruit_NeoPixel.h>
#include <Keyboard.h>

Adafruit_NeoPixel *pixels;
int pixelPin = 6;
int numPixels = 3;
int pixelFormat = NEO_GRB + NEO_KHZ800;

int playerPins[4] = {10, 11, 12, 13};
int currentPlayer = -1;

struct sPlayerConfig
{
   uint32_t color;
   byte buttons[4];
};

sPlayerConfig playerConfigs[] = {
    {0xFF0000,
     {KEY_F1, 'x', 'b', 'c'}},
    {0x00FF00,
     {KEY_F2, 'd', 'e', 'f'}},
    {0x0000FF,
     {KEY_F3, 'g', 'h', 'i'}},
    {0xC000C0,
     {KEY_F4, 'j', 'k', 'l'}}};

int buttonPins[] = {2, 3, 4, 5};
#define BUTTON_DEBOUNCE 100
unsigned long lastButtonPress = 0;
byte lastButtonState[4];

unsigned long ledOnTime = 0;
bool ledOn = false;

void checkPlayerSelect();
void setLedColor();
void triggerLed(int onTime = 5000);
void checkButtons();
void handleLedSchedule();

#define SERIAL_INT 500
unsigned long lastSerialOutput = 0;

void setup()
{
   pixels = new Adafruit_NeoPixel(numPixels, pixelPin, pixelFormat);
   pixels->begin();
   pixels->clear();
   pixels->show();

   for (int i = 0; i < 4; i++)
   {
      pinMode(playerPins[i], INPUT_PULLUP);
      pinMode(buttonPins[i], INPUT_PULLUP);
   }

   Keyboard.begin();
   Serial.begin(9600);
}

void loop()
{
   checkPlayerSelect();
   setLedColor();
   checkButtons();
   handleLedSchedule();
   if (millis() > lastSerialOutput + SERIAL_INT)
   {
      Serial.print("LO: ");
      Serial.print(ledOn);
      Serial.print(" LOT: ");
      Serial.println(ledOnTime);
   }
}

void checkPlayerSelect()
{
   if (!ledOn)
      return;
   for (int i = 0; i < 4; i++)
   {
      if (digitalRead(playerPins[i]) == LOW)
      {
         currentPlayer = i;
         setLedColor();
         pixels->show();
         break;
      }
   }
}

void setLedColor()
{
   pixels->fill(playerConfigs[currentPlayer].color);
}

void checkButtons()
{
   if (millis() < lastButtonPress + BUTTON_DEBOUNCE)
      return;
   for (int i = 0; i < 4; i++)
   {
      byte buttonState = digitalRead(buttonPins[i]);
      if (buttonState == LOW && buttonState != lastButtonState[i])
      {
         Keyboard.write(playerConfigs[currentPlayer].buttons[i]);
         triggerLed(500);
         lastButtonPress = millis();
      }
      lastButtonState[i] = buttonState;
   }
}

void triggerLed(int offTime = 5000)
{
   pixels->clear();
   pixels->show();
   ledOnTime = millis() + offTime;
   ledOn = false;
}

void handleLedSchedule()
{
   if (ledOn)
      return;

   if (millis() > ledOnTime)
   {
      setLedColor();
      pixels->show();
      ledOn = true;
   }
}