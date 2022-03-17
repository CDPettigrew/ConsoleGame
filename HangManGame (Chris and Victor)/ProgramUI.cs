using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HangManGame__Chris_and_Victor_.Consoles;

namespace HangManGame__Chris_and_Victor_
{
    public class ProgramUI
    {
        private readonly IConsole _console;
        public ProgramUI(IConsole console)
        {
            _console = console;
        }

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool ContinueToRun = true;
            while (ContinueToRun)
            {

                _console.Clear();
                _console.WriteRedLine("\n +-----+|");
                _console.WriteRedLine(" O      |");
                _console.WriteRedLine("/|\\     |");
                _console.WriteRedLine("/ \\     |");
                _console.WriteRedLine("      ====");
                _console.WriteLine();
                _console.WriteLine("Welcome to Hang Man! Please select your difficulty: \n" +
                    "1. Easy\n" +
                    "2. Medium\n" +
                    "3. Hard\n" +
                    "4. Custom Word\n" +
                    "5. Exit");
                switch (_console.ReadLine())
                {
                    case "1":
                        EasyMenu();
                        break;
                    case "2":
                        MediumMenu();
                        break;
                    case "3":
                        HardMenu();
                        break;
                    case "4":
                        CustomWord();
                        break;
                    case "5":
                        ContinueToRun = false;
                        break;
                }
            }
        }

        private void EasyMenu()
        {
            _console.Clear();
            _console.WriteLine("Easy\n" +
                "Please select a category\n" +
                "1. Animals\n" +
                "2. Places\n" +
                "3. Food.\n");
            switch (_console.ReadLine())
            {
                case "1":
                    EasyAnimals();
                    break;
                case "2":
                    EasyPlaces();
                    break;
                case "3":
                    EasyFood();
                    break;
            }
        }
        private void MediumMenu()
        {
            _console.Clear();
            _console.WriteLine("Medium\n" +
                "Please select a category\n" +
                "1. Animals\n" +
                "2. Places\n" +
                "3. Food.\n");
            switch (_console.ReadLine())
            {
                case "1":
                    MediumAnimals();
                    break;
                case "2":
                    MediumPlaces();
                    break;
                case "3":
                    MediumFood();
                    break;
            }
        }
        private void HardMenu()
        {
            _console.Clear();
            _console.WriteLine("Hard\n" +
                "Please select a category\n" +
                "1. Animals\n" +
                "2. Places\n" +
                "3. Food.\n");
            switch (_console.ReadLine())
            {
                case "1":
                    HardAnimals();
                    break;
                case "2":
                    HardPlaces();
                    break;
                case "3":
                    HardFood();
                    break;
            }
        }
        private void CustomWord()
        {
            _console.Clear();
            _console.WriteLine("Enter your word here: ");
            string hiddenWord = _console.ReadLine();
            GameLogic(hiddenWord);
            
        }

        public void HangManStickFigures(int wrong)
        {
            if (wrong == 0)
            {
                _console.WriteRedLine("\n +-----+ |");
                _console.WriteRedLine("         |");
                _console.WriteRedLine("         |");
                _console.WriteRedLine("         |");
                _console.WriteRedLine("      ====");
            }
            else if (wrong == 1)
            {
                _console.WriteRedLine("\n +-----+ |");
                _console.WriteRedLine(" O       |");
                _console.WriteRedLine("         |");
                _console.WriteRedLine("         |");
                _console.WriteRedLine("      ====");
            }
            else if (wrong == 2)
            {
                _console.WriteRedLine("\n +-----+ |");
                _console.WriteRedLine(" O       |");
                _console.WriteRedLine(" |       |");
                _console.WriteRedLine("         |");
                _console.WriteRedLine("      ====");
            }
            else if (wrong == 3)
            {
                _console.WriteRedLine("\n +-----+ |");
                _console.WriteRedLine(" O       |");
                _console.WriteRedLine("/|       |");
                _console.WriteRedLine("         |");
                _console.WriteRedLine("      ====");
            }
            else if (wrong == 4)
            {
                _console.WriteRedLine("\n +-----+|");
                _console.WriteRedLine(" O      |");
                _console.WriteRedLine("/|\\     |");
                _console.WriteRedLine("        |");
                _console.WriteRedLine("      ====");
            }
            else if (wrong == 5)
            {
                _console.WriteRedLine("\n +-----+|");
                _console.WriteRedLine(" O      |");
                _console.WriteRedLine("/|\\     |");
                _console.WriteRedLine("/       |");
                _console.WriteRedLine("     ====");
            }
            else if (wrong == 6)
            {
                _console.WriteRedLine("\n +-----+|");
                _console.WriteRedLine(" O      |");
                _console.WriteRedLine("/|\\     |");
                _console.WriteRedLine("/ \\     |");
                _console.WriteRedLine("      ====");
            }
        }


        public void GameLogic(string hiddenWord)
        {
            int numOfWrongGuess = 0;
            _console.WriteLine("Welcome to Hang Man, Have Fun!!");
            _console.WriteLine("-----------------------------------");
            int wordToGuess = hiddenWord.Length;
            int rightLettersGuessed = 0;
            List<string> incorrectGuesses = new List<string>();
            List<char> correctLetters = new List<char>();

            while (numOfWrongGuess < 6 && rightLettersGuessed < wordToGuess)
            {
                _console.Clear();
                HangManStickFigures(numOfWrongGuess);
                int rightGuess = 0;
                foreach (char letter in hiddenWord)
                {
                    if (correctLetters.Contains(letter))
                    {
                        _console.WriteGreen(letter + " "); //Needs a Console.WriteGreenLine
                    }
                    else
                    {
                        _console.Write("_ ");
                    }
                }
                _console.WriteLine();
                _console.Write("Incorrect Guesses: ");
                incorrectGuesses.ForEach(_console.Write);
                _console.WriteLine();
                _console.Write("Please type in a letter to guess: ");
                string userGuess = _console.ReadLine().ToLower();
                if (userGuess.Count() > 1)
                {
                    _console.WriteLine("Please only input one letter.");
                    Thread.Sleep(1000);
                    continue;
                }
                foreach (Char letter in hiddenWord)
                {
                    string wordLetter = letter.ToString();
                    if (userGuess.Contains(wordLetter))
                    {
                        rightGuess++;
                        rightLettersGuessed++;
                        correctLetters.Add(userGuess.ToCharArray().First());

                    }
                }
                if (rightGuess > 0)
                {                    _console.WriteLine($"The letter {userGuess} is correct!");
                }
                else
                {
                    numOfWrongGuess++;
                    incorrectGuesses.Add(userGuess);
                    _console.WriteLine("Incorrect letter guess, please try again.");
                }
            }
            if (rightLettersGuessed >= wordToGuess)
            {
                _console.Clear();
                HangManStickFigures(numOfWrongGuess);
                _console.WriteGreen($"You guessed the word correctly! It was {hiddenWord}!");
                _console.ReadLine();
            }
            else
            {
                _console.BadEndClear();
                HangManStickFigures(numOfWrongGuess);
                _console.WriteRedLine($"You lose! The word was {hiddenWord}.");
                _console.ReadLine();
            }
        }
        public string RandomWordGrabber(List<string> randomWord)
        { 
             Random random = new Random();
           int index = random.Next(randomWord.Count);
           string hiddenWord = randomWord[index];
            return hiddenWord;
        }
        public void EasyPlaces()
        {
            List<string> easyPlaces = new List<string> { "paris", "school", "home", "park", "work" };
            string hiddenWord = RandomWordGrabber(easyPlaces);
            GameLogic(hiddenWord);
         }

        public void EasyAnimals()
        {
            List<string> easyAnimals = new List<string> { "dog", "cat", "horse", "bird", "owl" };
            string hiddenWord = RandomWordGrabber(easyAnimals);
            GameLogic(hiddenWord);
        }

        public void EasyFood()
        {
            List<string> easyFood = new List<string> { "sandwich", "hotdog", "burger", "pickle", "bread" };
            string hiddenWord = RandomWordGrabber(easyFood);
            GameLogic(hiddenWord);
        }

        public void MediumAnimals()
        {
            List<string> mediumAnimals = new List<string> { "spider", "alligator", "gorilla", "lizard", "giraffe" };
            string hiddenWord = RandomWordGrabber(mediumAnimals);
            GameLogic(hiddenWord);
        }

        public void MediumPlaces()
        {
            List<string> mediumPlaces = new List<string> { "downtown", "restaurant", "indiana", "museum", "castle" };
            string hiddenWord = RandomWordGrabber(mediumPlaces);
            GameLogic(hiddenWord);
        }

        public void MediumFood()
        {
            List<string> mediumFood = new List<string> { "spaghetti", "yogurt", "popcornshrimp", "chocolatebar", "cheesecake" };
            string hiddenWord = RandomWordGrabber(mediumFood);
            GameLogic(hiddenWord);
        }

        public void HardAnimals()
        {
            List<string> hardAnimals = new List<string> { "axolotl", "ptarmigan", "coelacanth", "angwantibo", "pterodactyl" };
            string hiddenWord = RandomWordGrabber(hardAnimals);
            GameLogic(hiddenWord);
        }

        public void HardPlaces()
        {
            List<string> hardPlaces = new List<string> { "tajmahal", "whitehouse", "czechoslovakia", "yosemitepark", "elevenfiftyacademy" };
            string hiddenWord = RandomWordGrabber(hardPlaces);
            GameLogic(hiddenWord);
        }

        public void HardFood()
        {
            List<string> hardFood = new List<string> { "prosciutto", "parmigianoreggiano", "bourbonchicken", "smorgasbord", "fettuccine" };
            string hiddenWord = RandomWordGrabber(hardFood);
            GameLogic(hiddenWord);
        }
    }
}


