using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    List<Language> languages = new List<Language>();

    //Language lang = new Language();
    //lang.initialize();

    Console.WriteLine("");
    //lang.saveAlphabet();
    //lang.saveSyllables();
    //lang.saveVocab();

    //string loadFile = "bfempqmoafjupfua";
    //lang.loadAlpha(loadFile);
    //lang.loadSyllables(loadFile);
    //lang.loadVocab(loadFile);

    char choice = ' ';
    Console.WriteLine("Language Generator");

    while (choice != 'Q')
    {
      Console.WriteLine("\n0: [G]enerate new Language");
      Console.WriteLine("1: [L]oad a saved Language");
      if (languages.Count != 0)
      {
        Console.WriteLine("2: [A]dd Words to existing Language");
        Console.WriteLine("3: [V]iew all Words of a Language");
        Console.WriteLine("4: Get random [W]ord from Language");
        Console.WriteLine("5: [S]ave a Language");
      }
      Console.WriteLine("Q: Quit");

      Console.WriteLine("\nPlease choose an option: ");
      choice = Console.ReadLine()[0];

      // Generate a new Language
      if ((choice == '0') || (choice == 'G'))
      {
        if (languages.Count <= 10)
        {
          Language lang = new Language();
          lang.initialize();
          languages.Add(lang);

          Console.WriteLine("Language '" + lang.name + "' generated!");
        }
        else
        {
          Console.WriteLine("You have too many languages already!");
        }
      }

      // Load a saved Language
      if ((choice == '1') || (choice == 'L'))
      {
        Console.WriteLine("I'm sorry, that option is not yet available");
      }

      // Add Words to existing Language
      if (((choice == '2') || (choice == 'A')) && (languages.Count != 0))
      {
        int subChoice = -1;
        if (languages.Count > 1)
        {
          for (int i = 0; i < languages.Count; i++)
          {
            Console.WriteLine(i + ": " + languages[i].name);
          }
          Console.WriteLine("\nPlease choose a language option:");
          
          // Ensure valid input
          while ((0 > subChoice) || (subChoice >= languages.Count))
          {
            subChoice = (int)Char.GetNumericValue(Console.ReadLine()[0]);
            if ((0 > subChoice) || (subChoice >= languages.Count))
            {
              Console.WriteLine("Please enter a number between 0 and " + (languages.Count - 1) + " to choose your language:");
            }
            else
            {
              Console.WriteLine("You have selected " + subChoice);
            }
          }
        }
        else
        {
          subChoice = 0;
        }

        // Add the words
        for (int i = 0; i < 25; i++)
        {
          Console.WriteLine("Adding word " + i + " to " + languages[subChoice].name + ".");
          Word newWord = new Word();
          newWord.initialize(languages[subChoice].syllables);
          languages[subChoice].vocabulary.Add(newWord);
        }
        Console.WriteLine("Words added to " + languages[subChoice].name + ".");
      }

      // View all Words in Language
      if (((choice == '3') || (choice == 'V')) && (languages.Count != 0))
      {
        int subChoice = -1;
        if (languages.Count > 1)
        {
          for (int i = 0; i < languages.Count; i++)
          {
            Console.WriteLine(i + ": " + languages[i].name);
          }
          Console.WriteLine("\nPlease choose a language option:");
          
          // Ensure valid input
          while ((0 > subChoice) || (subChoice >= languages.Count))
          {
            subChoice = (int)Char.GetNumericValue(Console.ReadLine()[0]);
            if ((0 > subChoice) || (subChoice >= languages.Count))
            {
              Console.WriteLine("Please enter a number between 0 and " + (languages.Count - 1) + " to choose your language:");
            }
            else
            {
              Console.WriteLine("You have selected " + subChoice);
            }
          }
        }
        else
        {
          subChoice = 0;
        }

        int j = 0;
        for (int i = 0; i < languages[subChoice].vocabulary.Count; i++)
        {
          Console.WriteLine("\n- " + languages[subChoice].vocabulary[i].print());
          Console.WriteLine(languages[subChoice].vocabulary[i].printEmph());
          j++;

          if (j >= 6)
          {
            Console.ReadKey();
            j = 0;
          }
        }
      }

      // Get Random Word from Language
      if (((choice == '4') || (choice == 'W')) && (languages.Count != 0))
      {
        int subChoice = -1;
        if (languages.Count > 1)
        {
          for (int i = 0; i < languages.Count; i++)
          {
            Console.WriteLine(i + ": " + languages[i].name);
          }
          Console.WriteLine("\nPlease choose a language option:");
          
          // Ensure valid input
          while ((0 > subChoice) || (subChoice >= languages.Count))
          {
            subChoice = (int)Char.GetNumericValue(Console.ReadLine()[0]);
            if ((0 > subChoice) || (subChoice >= languages.Count))
            {
              Console.WriteLine("Please enter a number between 0 and " + (languages.Count - 1) + " to choose your language:");
            }
            else
            {
              Console.WriteLine("You have selected " + subChoice);
            }
          }
        }
        else
        {
          subChoice = 0;
        }

        int randIndex = Globals.rand.Next(languages[subChoice].vocabulary.Count);
        Word randWord = languages[subChoice].vocabulary[randIndex];
        Console.WriteLine("\nYour random word from " + languages[subChoice].name + " is:");
        Console.WriteLine("- " + randWord.print());
        Console.WriteLine(randWord.printEmph());
      }

      // Save a Language
      if (((choice == '5') || (choice == 'S')) && (languages.Count != 0))
      {
        Console.WriteLine("I'm sorry, that option is not yet available");
      }
    }
    Console.WriteLine("Thank you for checking out my language generator.");
  }
}