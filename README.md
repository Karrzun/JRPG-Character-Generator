# README

A Unity prototype for procedural character generation in a medieval Japanese-inspired roguelike setting.

## Features

- Procedural character generation
- Stat-based trait selection
- Location-aware occupation generation
- Weighted random selection
- Optional local LLM-generated character backstories

## Technical Highlights

- Data-driven generation logic
- Weighted probability system
- Event-based description generation pipeline
- Serializable character/stat models
- Optional local AI integration via llama.cpp/LLamaSharp

## Screenshots

<img width="2250" height="1261" alt="Screenshot_Characters_Selection" src="https://github.com/user-attachments/assets/764e9e30-e230-46fa-acb4-6e068d05989b" />

## Third-Party Code

- OkGoDoit OpenAI API wrapper
- LLama / LLamaSharp
- EasyButtons, for Inspector access

## Notes

- For this prototype, narrative data is stored in static generator classes. In a production version, these entries would be moved into ScriptableObjects or JSON data files.
- The LLM model files are not included in this repository.

## License

This project is licensed under the PolyForm Noncommercial License 1.0.0.
