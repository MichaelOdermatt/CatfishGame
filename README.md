## TODO
### Character Controller
- [x] Use fixed update
- [x] Fix double jump

### Assets
- [x] Create monitor model
- [x] Add screen to monitor
- [x] Fix blinking line script's remove character method
- [x] Texture monitor
- [x] Create additional assets for the desk
- [x] Create a mouse model
- [x] Create a wood texture for the desk
- [x] Create create post-it note with login password on it
- [x] Fix lighting
- [x] Add lamp model
- [x] Create Speaker model
- [x] Create player animations

### Visual Effects
- [x] Create an animation on the player text mesh when a key is pressed or deleted.
- [x] Camera wobble?
- [x] Add some form of feedback when the user either gets the login password wrong or right.
- [ ] Figure out post processing

## Sound
- [x] Add music to speaker asset
- [x] Add sounds to player movement

### Story
- [ ] Come up with some sort of narrative

### Gameplay
- [X] Create something which reads the players input when enter is pressed and switches from the login screen to another screen.
- [X] Do something about space being pressed as the first character. Somehow let the player know (or don't allow space to be pressed as a first character).
- [ ] Make movement feel a bit better
- [ ] Try and fix the player extended jump
- [x] Add a respawn button (R) that resets the player location to the starting location

## Narrative Ideas

#### Login Screen
- Have the first screen be a login screen where the user must type in a password, they cannot play the rest of the game without first passing the login screen.
- Once they type in the password correctly the screen switches to a new project in unity. They can only type on the keyboard, they cant actually interact with it. 
- Alternatively, I could have another login screen, then another, then another, then another... Instead of having the password on the montior in the form of a postit note I could add blue text that says "I think the password is _ _ _ _" -> "Wait no its actually _ _ _ _" 
- There is a go to sleep button that the player can use at any time. going to sleep just restarts the game.
- There is another postit note that says IDEAS on it, but the postit note is blank. Is this too on the nose?
- Or once the user enters the password correctly, cut to a black screen that says something along the lines of "The rest of this game is supposed to be about having no motivation. Particularly in the things that you've convinced yourself you enjoy. About feeling guilty that you aren't being being productive enough. But I'm not sure how to convey that and I want to do something else now." Then an exit button appears.

- Maybe just ditch the sleep idea and just lable the quit game button as "go to bed", Then title the game "How I feel after a long day at work."