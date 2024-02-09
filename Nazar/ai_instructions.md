# AI Instructions for Nazar Mixed Reality Application

## Context:

- The application is an XR no-code prototype app, where users can visually connect outputs of entities to inputs in a
  style similar to Unreal Blueprints.
- The goal is to create a modular, dynamic, and easily extendable and maintainable system.
- Main technologies used are StereoKit for Mixed Reality development and DefaultEcs for an Entity Component System (ECS)
  architecture.
- The application is a prototype for a visual learning coding application in Mixed Reality.
- Users can create entities with inputs/outputs and connect them dynamically.
- It uses StereoKit and DefaultEcs for an ECS architecture.
- The codebase includes systems for animations, interactions, UI updates, and more.
- There is a global using file. All the usings should stay in this class to reduce codebase character count.

## Goals:

- Follow best coding practices, including KISS and SOLID principles while also taking into consideration that you are in
  an ECS context.
- Maintain clear separation of code and responsibilities.
- Minimize character count while preserving readability.
- Update ai_instructions.md with the current state and context of this conversation.
- Save any new request or particularity regarding the code or the application in ai_instruction.md.

## Rules:

- Use DefaultEcs.World instead of StereoKit.World

## Refactoring Objectives:

- Organize files into appropriate directories.
- Remove unnecessary `Dispose` methods from systems.
- Design and implement a system for visually connecting entity outputs to inputs, ensuring modularity and dynamic
  behavior.
- Establish a base system class or interface for common system functionality.
- Design a robust and flexible system for dynamic entity connections.

## Development Guide:

1. **Modularity**: Ensure that each component, system, and utility is self-contained and interacts with other parts of
   the application through well-defined interfaces.
2. **Dynamic Connections**: Implement a system that allows for dynamic creation and connection of entities at runtime,
   similar to a visual scripting interface.
3. **Ease of Extension**: Write code in a way that new features can be added with minimal changes to existing code.
4. **Maintainability**: Follow best coding practices, including KISS and SOLID principles, to ensure that the codebase
   is easy to understand and maintain.
5. **StereoKit and DefaultEcs**: Utilize the strengths of StereoKit for MR development and DefaultEcs for managing
   entities, components, and systems.

## Project State and Tasks:

This section will serve as a dynamic task tracker, similar to a Jira board, to keep track of the current state of the
project and upcoming tasks.

- [x] Organize files into appropriate directories.
- [x] Remove unnecessary `Dispose` methods from systems.
- [x] Design and implement a system for visually connecting entity outputs to inputs, ensuring modularity and dynamic
  behavior.
- [x] Establish a base system class or interface for common system functionality.
- [x] Design a robust and flexible system for dynamic entity connections.
- [x] Update documentation to reflect changes and provide usage examples.
- [x] Ensure all systems and components follow best coding practices.

Note: This document should be updated regularly to reflect the current state of the project and any new requirements or
changes in direction.

```
