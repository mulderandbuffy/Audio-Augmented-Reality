# Timelog

* Audio Augmented Reality
* Laura Henry
* 2467245H
* Stephen Brewster

## Week 1

### 30 Sep 2022

* *0.5 hours* Created GitHub repository with provided project template
* *0.5 hours* Initial meeting with supervisor

### 02 Oct 2022

* *1 hour* Brainstorming, working on mind map, trying existing examples of 3D spatial audio.
* *1 hour* Watched OpenMIT workshop on Bose AR for Unity
* *0.5 hour* Set up test Unity Project to ensure the Bose package imports properly and Unity is working

## Week 2

### 03 Oct 2022

* *2.5 hours* Read two research papers between classes, set up Zotero
* *2 hours* Read more research papers, added more papers to Zotero library

### 04 Oct 2022

* *1.5 hours* More research papers

### 07 Oct 2022

* *1 hour* Reading

### 08 Oct 2022

* *1 hour* Started new mind map, brainstorming more refined version of my idea

### 09 Oct 2022

* *1.5 hours* Researching possible weather APIs
* *2 hours* Completed intro to C# tutorial

## Week 3

### 13 Oct 2022

* *0.5 hours* Second meeting with supervisor, was given Bose Frames to start working with
* *0.5 hours* Typed up meeting notes

### 18 Oct 2022

* *1 hour* Watching unity tutorial and started basic bose demo before a meeting
* *2 hours* Finished basic demo project - frames connected and tracking motion

## Week 4

### 19 Oct 2022

* *1.5 hours* Started notes/specification file for the weather app to collect necessary information. Wrote description of functionality and made a basic interaction flow diagram

### 20 Oct 2022

* *0.5 hours* Meeting with supervisor
* *0.5 hours* typed up meeting notes

### 22 Oct 2022

* *2 hours* Found videos on using 3D audio with Unity's particle system (good for rain, snow etc.)

## Week 5

### 25 Oct 2022

* *3 hours* Working with unity's particle system to make different levels of rain and snow systems, which will be used to play spatialised audio

### 26 Oct 2022

* *1 hour* Installed and set up Rider, started working on the script to manage audio in the particle systems

### 27 Oct 2022

* *1 hour* Meeting with supervisor
* *0.5 hours* Typed up meeting notes

________________________________________________________________________________________________________________

## Void of Deadlines and Depression - nothing was done here

________________________________________________________________________________________________________________

## W/C 11/12/2022

### 11 Dec 2022

* *2.5 hours* Collected some useful sound effects

### 13 Dec 2022

* *3 hours* Wrote the status report

### 14 Dec 2022
* *2 hours* Wrestled with Unity, can build to Android with working Bluetooth connection
* *2 hours* Added in sound effects for sun and light wind
* *3 hours* Added sound effects and rotation code for thunder, visualisations for all three effects, currently UI controlled

### 15 Dec 2022

* *1 hour* supervisor meeting
* *4 hours* Tried to get wind to spawn from different directions, decided to work on snow effect instead

## W/C 18/12/2022

### 18 Dec 2022

* *3 hours* Completed rain and snow effects with randomised audio

### 19 Dec 2022

* *3 hours* Finished blizzard effect, added improvements to rain effect and the random audio script

### 21 Dec 2022

* *1 hour* Started making a debug log to display on the phone screen, looking for more sound effects

### 22 Dec 2022

* *3 hours* Improvements to the wind and rain effects, started on the cloud effect

### 23 Dec 2022

* *3 hours* Finished Cloud effect, made heavy rain effect and made more improvements to the rain effect. Finished debug screen.

## W/C 25/12/2022

## 29 Dec 2022

* *1 hour* Meeting with supervisor

## W/C 01/01/2023


## W/C 08/01/2023

### 12 Jan 2023

* *1 hour* Meeting with Supervisor

## W/C 15/01/2023

### 18 Jan 2023

* *2 hours* Creating initial questionnaire to investigate the effectiveness of the sound effects

### 19 Jan 2023

* *1 hour* Meeting With Supervisor
* *0.5 hours* Released questionnaire and spread it around

## W/C 22/01/2023

### 23 Jan 2023

* *2 hours* Implementing custom gesture detection - currently works with glasses on Unity but not on phone

### 26 Jan 2023

* *1 hour* Meeting With Supervisor

### 28 Jan 2023

## W/C 29/01/2023

### 29 Jan 2023

* *2 hours* wrote a simple JSON file and parser to read in and select a weather effect based on the time.

* *2.5 hours* Finally got gesture detection properly working and triggering the effect

* *0.5 hours* Swapped previous headphone model to a model that automatically switches depending on the connected device.

### 30 Jan 2023

* *1.5 hours* Added a day/night cycle to the clear sky (sun) effect so it plays owl sounds etc. at night.
* *.5 hours* Found a tutorial for implementing a rotating sun based on the system clock. Wasn't working as intended so shelved this implementation.

### 2 Feb 2023

* *1 hour* Meeting with supervisor

### 4 Feb 2023

* *1 hour* Added functionality for switching the JSON being read. This will be useful in evaluations for demonstrating different effects while keeping it time-based.
* *1.5 hours* Created a toggleable 'demo mode' where the effects are decided only by the buttons at the top of the screen - querying the json is disabled. Useful for debugging.
* *3 hours* - Implemented working code to rotate the sun/night sounds according to the time of day

## W/C 05/02/2023

### 5 Feb 2023
* *1.5 hours* Improvements to the new nighttime sound
* *0.5 hours* Created Style Sheet for the UI, improved button appearance.

### 6 Feb 2023
* *2.5 hours* Running diagnostics and fixes on laptop, which wouldn't boot
* *1.5 hour* Transferred important stuff off of hard drive in Emergency Linux
* *2 hours* Reinstalling Windows

### 7 Feb 2023

* *1 hour* Moving files onto new install
* *1 hour* Reinstalling Unity
* *2.5 hours* Updates to overall appearance, buttons now better communicate what is active

### 8 Feb 2023

* *2.5 hours* Created Popup Menu where the user can adjust settings
* *1 hour* The height of the gesture trigger can be cutomised by the user via a slider

### 9 Feb 2023

* *1 hour* The delay on disabling the current effect can be customised to the user's liking, giving them more neck freedom after triggering the gesture

### 11 Feb 2023

* *3 hours* Implemented JSON-defined angles for the wind effect (N, S, E, W)
* *2 hours* Created base of the 'next X hours' view. Dynamically determine sound spawn points and fetch necessary data from the JSON
* *1 hour* Created simplified versions of the basic sounds as prefab objects for use in the extended view.

## W/C 12/02/2023

* *7 hours* Extended 'Forecast' view now functional - toggled on and off using the 'input' gesture on the headset, properly reloaded when switching json files. The number of points on the circle/hours in the forecast view can be set by the user in the menu. Still difficult to differentiate where each sound is coming from.