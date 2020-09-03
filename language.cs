using System;
using System.Collections.Generic;
using System.IO;

public class Language {
  public string name;

  public List<string> weightedVowels;
  public List<string> weightedSoftcs;
  public List<string> weightedHardcs;

  public List<string> syllables;
  public List<Word> vocabulary;

  public Language()
  {
    name = "Herman"; //Placeholder duh

    weightedVowels = new List<string>();
    weightedSoftcs = new List<string>();
    weightedHardcs = new List<string>();

    syllables = new List<string>();
    vocabulary = new List<Word>();
  }

  public void initialize()
  {
    weightVowels();
    weightSoftcs();
    weightHardcs();

    // Console.WriteLine("Generating syllables...");
    for (int i = 0; i < 100; i++)
    {
      syllables.Add(makeSyllable());
    }
    // Console.WriteLine(syllables.Count + " syllables generated successfully.\n");

    for (int i = 0; i < 25; i++)
    {
      Word newWord = new Word();
      newWord.initialize(syllables);
      //Console.WriteLine("\n- " + newWord.print());
      //Console.WriteLine(newWord.printEmph());

      vocabulary.Add(newWord);
    }

    name = vocabulary[0].printCap();
  }

  public void weightVowels()
  {
    while (weightedVowels.Count == 0)
    {
      // Console.WriteLine("Populating vowel count...");
      for (int i = 0; i < Globals.vowels.Count; i++)
      {
        for (int j = Globals.rand.Next(8); j > 0; j--)
        {
          weightedVowels.Add(Globals.vowels[i]);
        }
      }
    }
    // Console.WriteLine("Vowel count populated.");
  }

  public void weightSoftcs()
  {
    while (weightedSoftcs.Count == 0)
    {
      // Console.WriteLine("Populating soft consonant count...");
      for (int i = 0; i < Globals.softcs.Count; i++)
      {
        for (int j = Globals.rand.Next(5); j > 0; j--)
        {
          weightedSoftcs.Add(Globals.softcs[i]);
        }
      }
    }
    // Console.WriteLine("Soft consonant count populated.");
  }

  public void weightHardcs()
  {
    while (weightedHardcs.Count == 0)
    {
      // Console.WriteLine("Populating hard consonant count...");
      for (int i = 0; i < Globals.hardcs.Count; i++)
      {
        for (int j = Globals.rand.Next(5); j > 0; j--)
        {
          weightedHardcs.Add(Globals.hardcs[i]);
        }
      }
    }
    // Console.WriteLine("Hard consonant count populated.");
  }

  public string makeSyllable()
  {
    string newSyl = "";
    
    // Console.WriteLine("Generating new syllable...");

    // Hard consonant?
    if (Globals.rand.Next(3) == 0)
    {
      newSyl += weightedHardcs[Globals.rand.Next(weightedHardcs.Count)];
    }

    // Soft consonant?
    if (Globals.rand.Next(3) == 0)
    {
      newSyl += weightedSoftcs[Globals.rand.Next(weightedSoftcs.Count)];
    }

    // Vowel
    newSyl += weightedVowels[Globals.rand.Next(weightedVowels.Count)];

    // Second vowel?
    if (Globals.rand.Next(5) == 0)
    {
      newSyl += weightedVowels[Globals.rand.Next(weightedVowels.Count)];
    }

    // Soft consonant?
    if (Globals.rand.Next(3) == 0)
    {
      newSyl += weightedSoftcs[Globals.rand.Next(weightedSoftcs.Count)];
    }
    
    // Hard consonant?
    if (Globals.rand.Next(3) == 0)
    {
      newSyl += weightedHardcs[Globals.rand.Next(weightedHardcs.Count)];
    }
    
    // Console.WriteLine("New syllable '" + newSyl + "' generated.");
    return newSyl;
  }

  public void saveAlphabet()
  {
    //Console.WriteLine("Saving alphabet weights...");

    string fileName = "languages/alpha_" + name + ".txt";
    // Check if file already exists. If yes, delete it.     
    if (File.Exists(fileName))    
    {    
        File.Delete(fileName);    
    }
    
    // Create a new file     
    using (StreamWriter sw = File.CreateText(fileName))    
    {
      string line = "";
      for (int i = 0; i < weightedVowels.Count; i++)
      {
        line += weightedVowels[i];
      }
      sw.WriteLine(line);

      line = "";
      for (int i = 0; i < weightedSoftcs.Count; i++)
      {
        line += weightedSoftcs[i];
      }
      sw.WriteLine(line);

      line = "";
      for (int i = 0; i < weightedHardcs.Count; i++)
      {
        line += weightedHardcs[i];
      }
      sw.WriteLine(line);
    }
    
    Console.WriteLine("Alphabet weights saved."); 
  }

  public void saveSyllables()
  {
    //Console.WriteLine("Saving syllables...");

    string fileName = "languages/syl_" + name + ".txt";
    //Check if file already exists. If yes, delete it.
    if (File.Exists(fileName))    
    {    
        File.Delete(fileName);    
    }

    // Create a new file     
    using (StreamWriter sw = File.CreateText(fileName))
    {
      for (int i = 0; i < syllables.Count; i++)
      {
        sw.WriteLine(syllables[i]);
      }
    }

    Console.WriteLine("Syllables saved.");
  }

  public void saveVocab()
  {
    //Console.WriteLine("Saving vocabulary...");

    string fileName = "languages/vocab_" + name + ".txt";
    //Check if file already exists. If yes, delete it.
    if (File.Exists(fileName))    
    {    
        File.Delete(fileName);    
    }

    // Create a new file     
    using (StreamWriter sw = File.CreateText(fileName))
    {
      for (int i = 0; i < vocabulary.Count; i++)
      {
        sw.WriteLine(vocabulary[i].printEmph());
        //Console.WriteLine("Saving '" + vocabulary[i].print() + "'.");
      }
    }

    Console.WriteLine("Vocabulary saved.");
  }

  public void loadAlpha(string _langname)
  {
    // Read each line of the file into a string array. Each element
    // of the array is one line of the file.
    string[] lines = System.IO.File.ReadAllLines("languages/alpha_" + _langname + ".txt");

    foreach (char letter in lines[0])
    {
      weightedVowels.Add(letter.ToString());
      // Use a tab to indent each line of the file.
      Console.Write(letter);
    }
    Console.WriteLine("\nVowels loaded.\n");
    
    foreach (char letter in lines[1])
    {
      weightedSoftcs.Add(letter.ToString());
      // Use a tab to indent each line of the file.
      Console.Write(letter);
    }
    Console.WriteLine("\nSoft consonants loaded.\n");
    
    foreach (char letter in lines[2])
    {
      weightedHardcs.Add(letter.ToString());
      // Use a tab to indent each line of the file.
      Console.Write(letter);
    }
    Console.Write(weightedHardcs.ToString());
    Console.WriteLine("\nHard consonants loaded.\n");
  }

  public void loadSyllables(string _langname)
  {
    // Read each line of the file into a string array. Each element
    // of the array is one line of the file.
    string[] lines = System.IO.File.ReadAllLines("languages/syl_" + _langname + ".txt");

    foreach (string line in lines)
    {
      syllables.Add(line);
      Console.WriteLine("Syllable '" + line + "' loaded.");
    }
    Console.WriteLine("Syllables loaded.");
  }

  public void loadVocab(string _langname)
  {
    // Read each line of the file into a string array. Each element
    // of the array is one line of the file.
    string[] lines = System.IO.File.ReadAllLines("languages/vocab_" + _langname + ".txt");

    foreach (string line in lines)
    {
      Word newWord = new Word();
      newWord.parse(line);
      vocabulary.Add(newWord);
      Console.WriteLine("Word '" + newWord.printEmph() + "' loaded successfully.");
    }
    Console.WriteLine("\nAll words loaded successfully.");
  }
}