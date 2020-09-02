using System;
using System.Collections.Generic;

public class Word
{
  public List<string> components;
  public int emphasis;

  public Word()
  {
    components = new List<string>();

    emphasis = 0;
  }

  public void Assemble(List<string> _syl)
  {
    int sylLength = 1;

    for (int i = 0; i < 4; i++)
    {
      if (Globals.rand.Next(3) == 0)
      {
        sylLength++;
      }
    }

    for (int i = 0; i < sylLength; i++)
    {
      components.Add(_syl[Globals.rand.Next(_syl.Count)]);
    }

    emphasis = Globals.rand.Next(sylLength);
  }

  public string print()
  {
    string outp = "";
    for (int i = 0; i < components.Count; i++)
    {
      outp += components[i];
    }

    return outp;
  }

  public string printEmph()
  {
    string outp = "(";
    for (int i = 0; i < components.Count; i++)
    {
      if (i == emphasis)
      {
        outp += components[i].ToUpper();
      }
      else
      {
        outp += components[i];
      }

      if (i != components.Count - 1)
      {
        outp += "*";
      }
    }
    outp += ")";

    return outp;
  }
}