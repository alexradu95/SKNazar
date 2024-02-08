```
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
26:## Message Handling:
27:
28:- It is possible to send and receive messages transiting in a `World`.
29:
30:```csharp
31:void On(in bool message) { }
32:
33:// the method On will be called back every time a bool object is published
34:// it is possible to use any type
35:world.Subscribe<bool>(On);
36:
37:world.Publish(true);
38:```
39:
40:- It is also possible to subscribe to multiple methods of an instance by using the `SubscribeAttribute`:
41:
42:```csharp
43:public class Dummy
44:{
45:    [Subscribe]
46:    void On(in bool message) { }
47:
48:    [Subscribe]
49:    void On(in int message) { }
50:
51:    void On(in string message) { }
52:}
53:
54:Dummy dummy = new Dummy();
55:
56:// this will subscribe the decorated methods only
57:world.Subscribe(dummy);
58:
59:// the dummy bool method will be called
60:world.Publish(true);
61:
62:// but not the string one as it did not have the SubscribeAttribute
63:world.Publish(string.Empty);
64:```
65:
66:- Note that the `Subscribe` method returns an `IDisposable` object acting as a subscription. To unsubscribe, simply dispose this object.
67:
68:```
26:## Message Handling:
27:
28:- It is possible to send and receive messages transiting in a `World`.
29:
30:```csharp
31:void On(in bool message) { }
32:
33:// the method On will be called back every time a bool object is published
34:// it is possible to use any type
35:world.Subscribe<bool>(On);
36:
37:world.Publish(true);
38:```
39:
40:- It is also possible to subscribe to multiple methods of an instance by using the `SubscribeAttribute`:
41:
42:```csharp
43:public class Dummy
44:{
45:    [Subscribe]
46:    void On(in bool message) { }
47:
48:    [Subscribe]
49:    void On(in int message) { }
50:
51:    void On(in string message) { }
52:}
53:
54:Dummy dummy = new Dummy();
55:
56:// this will subscribe the decorated methods only
57:world.Subscribe(dummy);
58:
59:// the dummy bool method will be called
60:world.Publish(true);
61:
62:// but not the string one as it did not have the SubscribeAttribute
63:world.Publish(string.Empty);
64:```
65:
66:- Note that the `Subscribe` method returns an `IDisposable` object acting as a subscription. To unsubscribe, simply dispose this object.
67:
68:```
- Ensure the directory structure is following good architectural practices.
- Implement a message passing mechanism using the DefaultEcs `Publish` and `Subscribe` methods to allow systems to communicate with each other. For example, when a button is pressed, a `ButtonPressedMessage` is published, and any system subscribed to that message type can react accordingly.
```