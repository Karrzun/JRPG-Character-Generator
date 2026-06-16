# README

A Unity prototype for procedural character generation in a medieval Japanese-inspired roguelike setting.

## Overview

The system generates a set of possible player characters and keeps the strongest candidates based on their total stat value. Each character is assembled from several independent generation steps:

1. Random sex selection
2. Randomized character stats
3. Name generation
4. Trait selection based on stats
5. Origin/location selection
6. Occupation selection based on origin and sex
7. Initial description or optional AI-generated backstory

## Features

- Procedural character generation
- Randomized RPG-style stat generation
- Stat-based trait selection
- Location-aware occupation generation
- Weighted random occupation selection
- Optional local LLM-generated character backstories
- Debug tool for analyzing generated trait and occupation distributions

## Technical Highlights

- Data-driven generation logic
- Weighted probability system
- Event-based description generation pipeline
- Serializable character/stat models
- Optional local AI integration via llama.cpp/LLamaSharp

## Optional Local LLM Integration

The project contains an optional local LLM pipeline for generating short character backstories.

The current implementation expects a local `llama-server` compatible executable and model file in `StreamingAssets`:

```text
StreamingAssets/
└── LLM/
    ├── server/
    │   └── llama-server.exe
    └── models/
        └── mistral-7b-instruct-v0.2.Q4_K_M.gguf
```

The model and server executable are not included in this repository.

When AI descriptions are enabled through the project's gameplay settings, `LLMServerLauncher` starts the local server and `LLMClient` sends generated character prompts to the local completion endpoint.

The default local endpoint is:

```text
http://localhost:8080/v1/completions
```

## Screenshots

<img width="2250" height="1261" alt="Screenshot_Characters_Selection" src="https://github.com/user-attachments/assets/764e9e30-e230-46fa-acb4-6e068d05989b" />

## Third-Party Code

- LLama / LLamaSharp
- EasyButtons, for Inspector access

## Notes

- For this prototype, narrative data is stored in static generator classes. In a production version, these entries would be moved into ScriptableObjects or JSON data files.

## License

This project is licensed under the PolyForm Noncommercial License 1.0.0.
