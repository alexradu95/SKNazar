# AI Instructions for Nazar Mixed Reality Application

## Context:
- The application is a prototype for a visual learning coding application in Mixed Reality.
- Users can create entities with inputs/outputs and connect them dynamically.
- It uses StereoKit and DefaultEcs for an ECS architecture.
- The codebase includes systems for animations, interactions, UI updates, and more.
- There is a global using file. All the usings should stay in this class to reduce codebase character count.

## Goals:
- Follow best coding practices, including KISS and SOLID principles.
- Maintain clear separation of code and responsibilities.
- Minimize character count while preserving readability.
- Update ai_instructions.md with the current state and context of this conversation.
- Save any new request or particularity regarding the code or the application in ai_instruction.md.

## Rules:
- Use DefaultEcs.World instead of StereoKit.World

## Refactoring Objectives:
- Ensure the directory structure is following good architectural practices.
- Implement a message passing mechanism using the DefaultEcs `Publish` and `Subscribe` methods to allow systems to communicate with each other.
- Abstract UI code from systems to a separate UI handler class.
- Implement an entity factory for creating entities with components.
- Organize files into appropriate directories.
- Add XML documentation comments to public APIs.
- Rename `PoseComponent` to `PositionComponent` for consistency.
- Remove unnecessary `Dispose` methods from systems.
- Establish a base system class or interface for common system functionality.
- Design a robust and flexible system for dynamic entity connections.
```