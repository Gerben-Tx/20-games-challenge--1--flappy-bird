# Flappy Game README
This Godot project is part of the **20 Games Challenge**, a learning journey to master game development through recreating classic games in order of increasing complexity.

> [!Warning] ⚠️ Learning Prototype
> This game prioritizes learning over perfection. It's built for the "20 Games Challenge" and skips advanced best practices, optimizations, or production polish to focus on core mechanics and rapid iteration.

## Challenge Details
Documentation for this Flappy Bird-style game (and the full challenge) is available at: [https://20_games_challenge.gitlab.io/games/flappy/](https://20_games_challenge.gitlab.io/games/flappy/)

The challenge helps build core skills progressively—you can find all games and progress tracking there.

## Goals
- [x] Create a game world with a floor.
- [x] Add an object that represents the main character. Apply a constant force to the character so it falls to the floor.
- [x] Add obstacles on the right of the game area. The obstacles should slide across the screen toward the left. The obstacles will appear in pairs, with a vertical gap between them.
- [x] Detect when the character collides with the floor or obstacles, and reset the game when a collision occurs.
- [x] Accumulate one point for each obstacle that the player passes. Display the score.

Stretch goals:
- [ ] Add some sounds that will play each time the player gains a point, and when the player loses.
- [x] Add a basic game-over screen to display the player’s score.
- [x] Track the high-score between play sessions and display the high score alongside the current score.
- [x] Add some background art ~Try layering the background and scrolling at a different rate to the foreground obstacles. This is called Parallax scrolling.~

## Quick Start
- Open in Godot 4.x
- Press F5 to play