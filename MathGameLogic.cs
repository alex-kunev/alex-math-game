namespace AlexMathGame
{
    public class MathGameLogic
    {
        //Game history to save the results of the games:
        public List<string> GameHistory { get; set; } = new List<string>();

        public void ShowMenu() 
        {
            Console.WriteLine("Please enter an option to select the operation to be performed:");
            Console.WriteLine("1. Sum");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random Mode");
            Console.WriteLine("6. Show History");
            Console.WriteLine("7. Change Difficulty");
            Console.WriteLine("8. Exit");
        } 

        // Build one function for all operations
		public int MathOperation(int firstNumber, int secondNumber, char operation) 
		{
			switch(operation)
			{
				case '+': 
					GameHistory.Add($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
					return firstNumber + secondNumber;
				case '-':
					GameHistory.Add($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
					return firstNumber - secondNumber;

				case '*':
					GameHistory.Add($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
					return firstNumber * secondNumber;

				case '/':
					while(firstNumber < 0 || firstNumber > 100)
					{
						try
                        {
                            Console.WriteLine("Please enter a number  between 0 and 100.");
                            firstNumber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (System.Exception)
                        {
                            // ignored
                            
					    }
			        }
					GameHistory.Add($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
					return firstNumber / secondNumber;			
            }
            return 0;		
		}
    }
}