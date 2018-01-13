using System;
using System.Collections.Generic;
public class Multiplets
{
    List<StarkBuilder.Multiplet> MultipletList;
    //List<List<int>> levels = new List<List<int>>();

    public Multiplets()
	{
        
	}
    override public string  ToString()
    {
        string rep="";
        foreach (StarkBuilder.Multiplet level in MultipletList)
        {
            rep += level.Label+" ";
            foreach (int stark in level.Components)
            {
                rep += stark.ToString() + " ";
            }
            rep += "\r\n";
        }
        return rep;

    }
    public void LoadFromString(string data) {
        MultipletList = new List<StarkBuilder.Multiplet>();
        foreach (var myString in data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
        {
            //   Console.WriteLine(myString);
            StarkBuilder.Multiplet Multi=new StarkBuilder.Multiplet();
            Multi.Label=myString.Split(' ')[0];
            string lista=myString.Split(' ')[1];
            List<int> level = new List<int>();
            foreach (string value in lista.Split(','))
            {
                level.Add(Int32.Parse(value));
                
            }
            Multi.Components=level;
            MultipletList.Add(Multi);
        }
    }
    public string GetSafeFilename(string filename)
    {

        return string.Join("_", filename.Split(System.IO.Path.GetInvalidFileNameChars()));

    }
    public void DumpFiles()
    {
        int size = MultipletList.Count;
        for (int krok=size-1; krok >= 0; krok--)
        {
            for (int j = krok - 1; j >= 0; j--)
            {
                string name=MultipletList[krok].Label + "_" + MultipletList[j].Label+".txt";
                string content = "";
                foreach (int stark in MultipletList[krok].Components) content +=stark.ToString() +" ";
                content += "\r\n";
                foreach (int stark in MultipletList[j].Components) content += stark.ToString() + " ";
                string fname = GetSafeFilename(name);
                Console.WriteLine(fname);
                Console.WriteLine(content);
                System.IO.File.WriteAllText(fname, content);
            }
            //Console.WriteLine(MultipletList[krok].Label);
        }
    }
}
