# Look At The Sky

The majority of the source files are a mix of proprietary Unity file types and C# script files.

The code can be found in `src\Weather App` - The rest is mostly library files and project configuration data.

`Assets` contains the bulk of the project code and materials.
* `Audio` contains the sound files used in the app (except those included with the Bose SDK)
* `Bose` contains the Bose SDK and its associated files
* `Fonts` contains the font files and Unity Font Assets needed to render text on screen.
* `Prefabs` contains the Unity prefab files for the simplified weather sounds used in Forecast Mode.
* `Resources` contains the JSON files storing three example days of weather.
* `Scenes` contains the Unity scene
* `Scripts` contains all of the C# code written for this project
* `TextMeshPro` contain package configuration data for TextMeshPro
* `UI` contains UXML and USS files used to build menus and buttons.
* `UI Toolkit` contains configuration data for UI Toolkit.


## Build instructions


### Requirements

* Requires Bose Frames (with cable if running on PC) or Bose NC700 Headset
* Unity version `2021.3.11f1` with `Android Build Support` module installed
* Android Phone (Tested on OnePlus 8T running Android 12 (API 31)) with developer options and USB debugging enabled.
* Build tested from Windows 10 and 11.

### Build steps

To build to Android device from Unity:
* Plug in Android phone, ensure media transfer and USB debugging are on (on the phone)
* Ensure Android is selected in Build Settings in Unity
* Select `Build and Run`.
* Save the APK if prompted
* Wait To Complete
* Once built and installed, it can be launched from the app drawer like any app.

 The build error `Destroy() may not be called from edit mode! Use DestroyImmediate() instead.`  occasionally appears and is caused by a known bug in the editor. It can be fixed by building again.

### Test steps


Running on Android Device:
* Connect Bose AR enabled headset via bluetooth to the phone before opening the app - NOTE: Try to look straight forward when powering on the headset to set the gyroscope properly.
* The app will ask for location permission on first startup - **NOTE: This is ONLY for the BLE connection between the headset and the mobile device and the app doesn't read or process any location data at all (hence when running through Unity only it doesn't need this since Bluetooth isn't involved).**
* Connect the headset via BLE using the GUI.
* After the headset has connected the on-screen model should copy its movements.

Running on PC via Unity:
* Open the Project folder (`src/Unity Hub`) in Unity (best done using Unity Hub)
* Connect the Bose Frames to the PC via the included USB-Magnet cable.
* Click the Play button at the top of the Unity window. Try to hold the glasses level as they power on and connect.
* The glasses will connect and the on-screen model should match its movements.

Note that only the Bose Frames are able to connect to Unity over USB.

Instructions for using the app can be found in `manual.md`.