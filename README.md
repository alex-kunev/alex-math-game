# Math Game

This is a simple console-based Math Game that allows users to practice basic arithmetic operations. The game supports addition, subtraction, multiplication, and division, and includes features such as difficulty levels and game history.

## Features

1. **Basic Operations**: The game includes the four basic arithmetic operations: addition, subtraction, multiplication, and division.
2. **Integer Division**: Division operations result in integers only. The game ensures that the dividend is divisible by the divisor.
3. **Menu Options**: Users can choose from a menu to select an operation, view game history, change difficulty levels, or exit the game.
4. **Game History**: The game records previous operations and allows users to view the history.
5. **Difficulty Levels**: Users can select different difficulty levels (Easy, Medium, Hard) which affect the time allowed to answer each question.
6. **Random Questions**: Users can choose to answer a series of random questions.

## How to Play

1. **Run the Program**: Start the program by running the `Main` method.
2. **Select an Option**: Choose an option from the menu:
   - 1: Addition
   - 2: Subtraction
   - 3: Multiplication
   - 4: Division
   - 5: Random Questions
   - 6: View Game History
   - 7: Change Difficulty Level
   - 8: Exit
3. **Answer Questions**: For each selected operation, answer the presented math question within the allowed time.
4. **View Score**: Your score will be updated based on correct answers.
5. **Change Difficulty**: You can change the difficulty level to adjust the time allowed for each question.
6. **Exit**: Choose the exit option to end the game and view your final score.

## Code Overview

### Main Program

The `Main` method initializes the game and handles the main game loop, presenting the menu and processing user selections.

### Difficulty Levels

The `DifficultyLevel` enum defines the different difficulty levels and their corresponding time limits.

### Methods

- `ChangeDifficulty()`: Allows the user to change the difficulty level.
- `DisplayMathGameQuestion(int firstNumber, int secondNumber, char operation)`: Displays a math question.
- `GetUserMenuSelection(MathGameLogic mathGame)`: Gets the user's menu selection.
- `GetUserResponse(DifficultyLevel difficulty)`: Asynchronously gets the user's response within the allowed time.
- `ValidateResult(int result, int? userResponse, int score)`: Validates the user's response and updates the score.
- `PerformOperation(MathGameLogic mathGame, int firstNumber, int secondNumber, char operation, int score, DifficultyLevel difficulty)`: Orchestrates the process of displaying a question, getting the user's response, and updating the score.

## Example

```plaintext
Please enter a difficulty level
1. Easy
2. Medium
3. Hard
1
Selected difficulty: Easy

Please choose an option:
1. Addition
2. Subtraction
3. Multiplication
4. Division
5. Random Questions
6. View Game History
7. Change Difficulty Level
8. Exit
1

What is 5 + 3?
8
You answered correctly; You earn 5 points
