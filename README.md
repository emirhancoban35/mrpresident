# Mr President

A text-based country management game prototype built in Unity.

Choose a country, respond to events and manage its economy. Decisions affect public support, welfare, military strength and the country's overall economic state.

## Gameplay

Events present a situation and a set of choices. Each option can change multiple country stats and trigger a news item.

Events can also be restricted to specific countries, allowing different situations to appear depending on the selected country.

The economy interface includes budget controls and indicators such as income, expenses, debt, tax rate, unemployment and purchasing power.

## Main Systems

- **Country management:** Selected country data and information about other countries.
- **Events and decisions:** Country eligibility, multiple options and configurable effects.
- **News:** News creation and publication following player decisions.
- **Economy:** Budget allocation, economic indicators and saved budget values.
- **UI:** Separate controllers for menus, news, relations and economy panels.

## Content Setup

Countries, events and news use ScriptableObjects.

An event defines its text, eligible countries and available options. Each option contains its effects and can reference a news item to publish after the decision.

This keeps event content separate from the code that displays choices and applies their consequences.

## Code Layout

Gameplay code is under `Assets/Scripts`.

- `Data` contains content definitions.
- `Event` handles events, choices, effects and news creation.
- `Economy` contains budget logic and economy panels.
- `Controllers` contains UI controllers.
- `Installers` connects managers and panels through Zenject.

## Opening the Project

Open the repository through Unity Hub using **Unity 2021.3.14f1**.

This is a prototype of the country management, event and economy systems.

**Built with Unity, C# and Zenject.**
