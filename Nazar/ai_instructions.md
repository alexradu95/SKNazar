
# AI Instructions for Nazar Mixed Reality Application

## Context:
- The application is a prototype for a visual learning coding application in Mixed Reality.
- Users can create entities with inputs/outputs and connect them dynamically.
- It uses StereoKit and DefaultEcs for an ECS architecture.
- The codebase includes systems for animations, interactions, UI updates, and more.
- There is a global using file. All the usings should stay in this class to reduce codebase character count.
- A new system called TextWindowInputSystem has been created to handle input events and update the text contents of TextWindow entities.
## Goals:
- Follow best coding practices, including KISS and SOLID principles.
- Maintain clear separation of code and responsibilities.
- Minimize character count while preserving readability.
- You will update ai_instructions.md with the current state and context of this conversation.
- Every time I add a new request or a particularity regarding the code or the application, you will save that in ai_instruction.md. 

## Rules:

- Use DefaultEcs.World instead of StereoKit.World

## Refactoring Objectives:
- Ensure the directory structure is following good architectural practices.
- Implement a message passing mechanism using the DefaultEcs `Publish` and `Subscribe` methods to allow systems to communicate with each other. For example, when a button is pressed, a `ButtonPressedMessage` is published, and any system subscribed to that message type can react accordingly.
```