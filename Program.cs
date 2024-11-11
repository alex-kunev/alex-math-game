/*
    1. You need to create a Math game containing the 4 basic operations

    2. The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.

    3. Users should be presented with a menu to choose an operation

    4. You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

    5. You don't need to record results on a database. Once the program is closed the results will be deleted.
*/

using AlexMathGame;
using System.Diagnostics;

public class Program
{
    public static async Task Main(string[] args)
    {
        MathGameLogic mathGame = new MathGameLogic();
        Random random = new Random();

        int firstNumber;
        int secondNumber;
        int userMenuSelection;
        int score = 0;
        bool gameOver = false;

        DifficultyLevel difficultyLevel = DifficultyLevel.Easy;

        while (!gameOver)
        {
            userMenuSelection = GetUserMenuSelection(mathGame);

            firstNumber = random.Next(1, 101);
            secondNumber = random.Next(1, 101);

            switch (userMenuSelection)
            {
                case 1:
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, '+', score, difficultyLevel);
                    break;
                case 2:
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, '-', score, difficultyLevel);
                    break;
                case 3:
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, '*', score, difficultyLevel);
                    break;
                case 4:
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(1, 101);
                        secondNumber = random.Next(1, 101);
                    }
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, '/', score, difficultyLevel);
                    break;
                case 5:
                    int numberOfQuestions = 99;
                    Console.WriteLine("Please enter the number of questions you want to attempt: ");
                    while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || (numberOfQuestions < 1 || numberOfQuestions > 100))
                    {
                        Console.WriteLine("Please enter the number of questions you want to attempt in integer numbers.");
                    }
                    while (numberOfQuestions > 0)
                    {
                        int randomOperation = random.Next(1, 5);

                        if (randomOperation == 1)
                        {
                            firstNumber = random.Next(1, 101);
                            secondNumber = random.Next(1, 101);
                            score += await PerformOperation(mathGame, firstNumber, secondNumber, '+', score, difficultyLevel);
                        }
                        else if (randomOperation == 2)
                        {
                            firstNumber = random.Next(1, 101);
                            secondNumber = random.Next(1, 101);
                            score += await PerformOperation(mathGame, firstNumber, secondNumber, '-', score, difficultyLevel);
                        }
                        else if (randomOperation == 3)
                        {
                            firstNumber = random.Next(1, 101);
                            secondNumber = random.Next(1, 101);
                            score += await PerformOperation(mathGame, firstNumber, secondNumber, '*', score, difficultyLevel);
                        }
                        else
                        {
                            firstNumber = random.Next(1, 101);
                            secondNumber = random.Next(1, 101);
                            while (firstNumber % secondNumber != 0)
                            {
                                firstNumber = random.Next(1, 101);
                                secondNumber = random.Next(1, 101);
                            }
                            score += await PerformOperation(mathGame, firstNumber, secondNumber, '/', score, difficultyLevel);
                        }
                        numberOfQuestions--;
                    }
                    break;
                case 6:
                    Console.WriteLine("Game History: \n");
                    foreach (var operation in mathGame.GameHistory)
                    {
                        Console.WriteLine($"{operation}");
                    }
                    break;
                case 7:
                    difficultyLevel = ChangeDifficulty();
                    DifficultyLevel difficultyEnum = (DifficultyLevel)difficultyLevel;
                    Enum.IsDefined(typeof(DifficultyLevel), difficultyEnum);
                    Console.WriteLine($"Difficulty level changed to: {difficultyEnum}");
                    break;
                case 8:
                    gameOver = true;
                    Console.WriteLine($"Your final score is: {score}");
                    break;
            }
        }
    }

    public enum DifficultyLevel
    {
        Easy = 45,
        Medium = 30,
        Hard = 15
    }

    static DifficultyLevel ChangeDifficulty()
    {
        int userSelection = 0;

        Console.WriteLine("Please enter a difficulty level");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        while (!int.TryParse(Console.ReadLine(), out userSelection) || (userSelection < 1 || userSelection > 3))
        {
            Console.WriteLine("Please enter a valid option: 1 to 3");
        }

        return userSelection switch
        {
            1 => DifficultyLevel.Easy,
            2 => DifficultyLevel.Medium,
            3 => DifficultyLevel.Hard,
            _ => DifficultyLevel.Easy
        };
    }

    static void DisplayMathGameQuestion(int firstNumber, int secondNumber, char operation)
    {
        Console.WriteLine($"{firstNumber} {operation} {secondNumber} = ??");
    }

    static int GetUserMenuSelection(MathGameLogic mathGame)
    {
        int selection = -1;
        mathGame.ShowMenu();
        while (selection < 1 || selection > 8)
        {
            while (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Please enter a valid option: 1-8");
            }

            if (!(selection >= 1 && selection <= 8))
            {
                Console.WriteLine("Please enter a valid option: 1-8");
            }
        }
        return selection;
    }
/* The GetUserResponse method in the provided C# code is an asynchronous function designed to get a user's input within a specified time limit, determined by the difficulty parameter. It starts by initializing a Stopwatch to measure the time taken for the user to respond. The method then runs a task to read user input from the console and waits for either the user input task to complete or a timeout task to finish, whichever comes first. If the user provides input within the allowed time, the method stops the stopwatch, parses the input to an integer, and returns it. If the input is not provided in time or is invalid, an OperationCanceledException is thrown, caught, and the method returns null while printing a "Time is up" message. This approach ensures that the program does not wait indefinitely for user input and handles timeouts gracefully.*/
    static async Task<int?> GetUserResponse(DifficultyLevel difficulty)
    {
        int response = 0;
        int timeout = (int)difficulty;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Task<string?> getUserInputTask = Task.Run(() => Console.ReadLine());

        try
        {
            string? result = await Task.WhenAny(getUserInputTask, Task.Delay(timeout * 1000)) == getUserInputTask ? getUserInputTask.Result : null;

            stopwatch.Stop();

            if (result != null && int.TryParse(result, out response))
            {
                Console.WriteLine($"Time taken to answer: {stopwatch.Elapsed.ToString(@"m\:ss\.fff")}");
                return response;
            }
            else
            {
                throw new OperationCanceledException();
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Time is up");
            return null;
        }
    }

/* The ValidateResult method in the provided C# code is designed to validate a user's response against a correct result and update their score accordingly. It takes three parameters: result (the correct answer), userResponse (the user's answer, which can be null), and score (the current score). If the user's response matches the correct result, the method prints a congratulatory message and adds 5 points to the score. If the user's response is incorrect or null, it prompts the user to try again and displays the correct answer. Finally, the method returns the updated score. This function is useful in quiz or game applications where user responses need to be validated and scores updated dynamically. */
    static int ValidateResult(int result, int? userResponse, int score)
    {
        if (result == userResponse)
        {
            Console.WriteLine("You answered correctly; You earn 5 points");
            score += 5;
        }
        else
        {
            Console.WriteLine("Try again!");
            Console.WriteLine($"Correct answer is: {result}");
        }
        return score;
    }

/*     The PerformOperation method orchestrates the process of displaying a math question, performing the operation, getting the user's response, validating it, and updating the score. It leverages asynchronous programming to handle user input with a timeout, making the game interactive and responsive.*/    
 static async Task<int> PerformOperation(MathGameLogic mathGame, int firstNumber, int secondNumber, char operation, int score, DifficultyLevel difficulty)
    {
        int result;
        int? userResponse;

        DisplayMathGameQuestion(firstNumber, secondNumber, operation);
        result = mathGame.MathOperation(firstNumber, secondNumber, operation);
        userResponse = await GetUserResponse(difficulty);
        score = ValidateResult(result, userResponse, score);
        return score;
    }
}