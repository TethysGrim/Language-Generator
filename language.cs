using System;
using System.Collections.Generic;

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

    weightVowels();
    weightSoftcs();
    weightHardcs();

    syllables = new List<string>();
    vocabulary = new List<Word>();

    Console.WriteLine("Generating syllables...");
    for (int i = 0; i < 25; i++)
    {
      syllables.Add(makeSyllable());
    }
    Console.WriteLine(syllables.Count + " syllables generated successfully.\n");

    for (int i = 0; i < 25; i++)
    {
      Word newWord = new Word();
      newWord.Assemble(syllables);
      Console.WriteLine("- " + newWord.print());
      Console.WriteLine(newWord.printEmph());

      vocabulary.Add(newWord);
    }

    name = vocabulary[0].print();
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
    Console.WriteLine("Vowel count populated.");
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
    Console.WriteLine("Soft consonant count populated.");
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
    Console.WriteLine("Hard consonant count populated.");
  }

  public string makeSyllable()
  {
    string newSyl = "";
    
    // Console.WriteLine("Generating new syllable...");
    if (Globals.rand.Next(3) == 0)
    {
      newSyl += weightedHardcs[Globals.rand.Next(weightedHardcs.Count)];
    }

    if (Globals.rand.Next(3) == 0)
    {
      newSyl += weightedSoftcs[Globals.rand.Next(weightedSoftcs.Count)];
    }

    newSyl += weightedVowels[Globals.rand.Next(weightedVowels.Count)];

    if (Globals.rand.Next(4) == 0)
    {
      newSyl += weightedVowels[Globals.rand.Next(weightedVowels.Count)];
    }

    if (Globals.rand.Next(3) == 0)
    {
      newSyl += weightedSoftcs[Globals.rand.Next(weightedSoftcs.Count)];
    }
    
    if (Globals.rand.Next(3) == 0)
    {
      newSyl += weightedHardcs[Globals.rand.Next(weightedHardcs.Count)];
    }
    
    // Console.WriteLine("New syllable '" + newSyl + "' generated.");
    return newSyl;
  }
}