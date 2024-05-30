# Unity Project: Experiential Learning

Welcome to the Experiential Learning Unity project! This repository contains all the necessary files and assets for the project. Follow the instructions below to set up the project on your local machine.

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
- [Project Structure](#project-structure)
- [Usage](#usage)

## Requirements

- **Unity Editor**: Version 2022.3.11f1

Make sure you have the correct version of Unity installed. You can download it from the [Unity Hub](https://unity3d.com/get-unity/download).

## Installation

1. **Clone the repository**:

    ```sh
    git clone https://github.com/yourusername/experiential-learning.git
    ```

2. **Open the project in Unity**:
    - Launch the Unity Hub.
    - Click on the `Add` button and navigate to the location where you cloned the repository.
    - Select the `experiential-learning` folder.
    - Ensure that the Unity version is set to `2022.3.11f1`.
## Project Structure
```
├── Animation
│   ├── ...
├── GameObject
│   ├── ...
├── Scenes
│   ├── HomeScene.unity
│   ├── HomeScene.unity.meta
│   ├── PreparationRoom.unity
│   └── PreparationRoom.unity.meta
├── Scenes.meta
├── Scripts
│   ├── Die.cs
│   ├── Die.cs.meta
│   ├── DrugSpawner.cs
│   ├── DrugSpawner.cs.meta
│   ├── InGameManu.cs
│   ├── InGameManu.cs.meta
│   ├── InfoDisplayManager.cs
│   ├── InfoDisplayManager.cs.meta
│   ├── IngredientPowder.cs
│   ├── IngredientPowder.cs.meta
│   ├── LevelManager.cs
│   ├── LevelManager.cs.meta
│   ├── MainManu.cs
│   ├── MainManu.cs.meta
│   ├── MaterialPreparation.cs
│   ├── MaterialPreparation.cs.meta
│   ├── Powder.cs
│   ├── Powder.cs.meta
│   ├── PowderMixer.cs
│   ├── PowderMixer.cs.meta
│   ├── RepoPagination.cs
│   ├── RepoPagination.cs.meta
│   ├── RoomShifter.cs
│   ├── RoomShifter.cs.meta
│   ├── SlideDown.cs
│   ├── SlideDown.cs.meta
│   ├── Slot.cs
│   ├── Slot.cs.meta
│   ├── Spatula.cs
│   ├── Spatula.cs.meta
│   ├── TablePress.cs
│   ├── TablePress.cs.meta
│   ├── Tablet.cs
│   ├── Tablet.cs.meta
│   ├── TabletHub.cs
│   ├── TabletHub.cs.meta
│   ├── TabletStoreSlot.cs
│   ├── TabletStoreSlot.cs.meta
│   ├── TooltipManager.cs
│   └── TooltipManager.cs.meta
└── ...
```
- **Scenes**:
  - `HomeScene.unity`: This is the starting scene of the game. It serves as the main menu or landing page where the player begins their journey.
  - `PreparationRoom.unity`: This is the in-game scene where includes all the interactive elements.
- **Scripts**:
  - `Die.cs`: Handles the behaviors and interactions of the die tool.
  - `DrugSpawner.cs`: Handles the spawning of drug-related items in the game.
  - `InGameManu.cs`: Manages the in-game menu functionality.
  - `InfoDisplayManager.cs`: Controls the display of information to the player.
  - `IngredientPowder.cs`: Manages the properties and behaviors of ingredient powders.
  - `LevelManager.cs`: Manages the game levels, including transitions and level-specific logic.
  - `MainManu.cs`: Handles the main menu interactions and navigation.
  - `MaterialPreparation.cs`: Manages the preparation of materials within the game.
  - `Powder.cs`: Represents and manages the properties of powders in the game.
  - `PowderMixer.cs`: Represents and manages the properties of power mixer in the game.
  - `RepoPagination.cs`: Handles the pagination of repositories or lists within the game.
  - `RoomShifter.cs`: Manages the shifting or changing of rooms within the game.
  - `SlideDown.cs`: Controls the slide-down animations and behaviors.
  - `Slot.cs`: Manages inventory or storage slots within the game.
  - `Spatula.cs`: Handles the behaviors and interactions of the spatula tool.
  - `TablePress.cs`: Represents and manages the properties of tablet press in the game.
  - `Tablet.cs`: Represents and manages the properties of tablet in the game.
  - `TabletHub.cs`: Controls the hub for tablet-related interactions.
  - `TabletStoreSlot.cs`: Manages the storage slots for tablets.
  - `TooltipManager.cs`: Handles the display and behavior of tooltips within the game.

## Usage

Once you have the project open in Unity, you can:

- Explore the scenes located in `Assets/Scenes/`.
- Modify or add new scripts in `Assets/Scripts/`.
- Create new prefabs, materials, and other assets as needed.
