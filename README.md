# BowMaster

Welcome to **BowMaster**!

## Overview

This project is a Unity-based Bow and Arrow game focusing on realistic physics and interactive gameplay. It features multiple scripts organized into specific functionalities, handling everything from object interaction and arrow dynamics to audio management and collision detection.


![image](https://github.com/sanilkatula/Bowmaster/assets/124840083/7845a203-c95a-403f-93ef-3aa957e63b51)
![image](https://github.com/sanilkatula/Bowmaster/assets/124840083/e243f071-65d9-4e82-91e3-26d7275f1aa5)
![image](https://github.com/sanilkatula/Bowmaster/assets/124840083/a14cc1ba-eecf-485d-9716-d237fb3c8d14)

## Features

- **Arrow Physics**: Simulates realistic arrow flight and interactions with the environment.
- **Collision Management**: Handles events when arrows collide with objects, including changes in physical properties and triggering of events.
- **Object Interaction**: Scripts allow objects to follow targets or move along predefined paths, enhancing the game's dynamic environment.
- **Audio Feedback**: Provides auditory cues for actions like hitting the target, adding an immersive layer to the gameplay.
- **Target Mechanism**: Targets are equipped with color-coded tags for precise collision detection, providing immediate feedback when hit by an arrow. This feature enhances gameplay interactivity and feedback accuracy.
- **Bow Mechanism**: Features an undroppable bow that stays in the air when not held, accommodating both left-handed and right-handed players. Arrows appear on the bow ready to be shot, enhancing realism and ease of use.


## Script Summary

### ArrowScripts
- `FlyStraight.cs`: Controls the arrow's flight, ensuring it points in the direction it's moving.
- `NonKineCollision.cs`: Makes arrows kinematic upon collision and triggers collision-related events.

### BowScripts
- Manage the bow's interactions, such as how it can be grabbed, aiming mechanisms, and visual orientation relative to the player and targets.

## Gulf Analysis Overview

### Gulf of Execution
- Users faced challenges in understanding how to interact with the game environment, such as picking up and using the bow. Solutions implemented include step-by-step instructions and intuitive control enhancements.

### Gulf of Evaluation
- The game now includes clear audio feedback and a scoring system to help users evaluate their performance, such as knowing when the arrow hits the target or specific parts of the target, aiding in immediate performance feedback.

### System/User Interface Adjustments
- Modifications were made to improve system response to user inputs, making the controls more intuitive and reducing confusion between similar commands.

### Feedback Mechanisms
- Enhanced feedback mechanisms help users understand the results of their actions better, with audio cues and visual aids that clarify the impact and accuracy of their shots.

By addressing these gulfs, the game's usability and player engagement have significantly improved, making for a more intuitive and enjoyable user experience.

## Installation

1. **Clone the Repository**:
   - Clone this repository to your local machine using your favorite Git client.

2. **Open the Project in Unity Hub**:
   - Open Unity Hub and add the cloned repository folder to your projects list.
   - Open the project in the Unity Editor.

3. **Set Up for Meta Quest**:
   - Ensure you have the Oculus XR Plugin installed from the Unity Package Manager.
   - Configure the project settings for Android and set the texture compression to ASTC.
   - Under XR Plugin Management, check the Oculus box to enable support for the Meta Quest headset.

4. **Build and Run**:
   - Connect your Meta Quest headset to your computer via USB.
   - Enable Developer Mode on your Meta Quest if not already enabled.
   - In Unity, go to File > Build Settings.
   - Ensure that Android is selected as the platform and click on the "Build And Run" button.
   - Choose the destination folder for the APK file and start the build process. Unity will build the game and automatically deploy it to your Meta Quest headset.

## Basic Instructions: How to Play?

Controller image for reference:
![Quest Controller Diagram](https://github.com/sanilkatula/Bowmaster/assets/124840083/02b54603-b967-41d9-9ca2-2884af685b90)

1. **Picking Up the Bow**:
   - Approach the bow within the game.
   - Press and hold the "grip" button on your controller to grab the bow. The bow will stay in the air when released, making it easy to re-grab if needed.

2. **Shooting an Arrow**:
   - With the bow in hand, press the "trigger" button to spawn an arrow.
   - Aim at your target by adjusting the angle of the bow.
   - Release the trigger button to shoot the arrow towards the target.

These steps provide a basic understanding of how to interact with the game's primary mechanics.


## Contributors

Team Member:
- Sanil Katula
- Jenil Prajapati
- Sarvesh Jayaram
- Ishan Jain
- Aryan Chopra

