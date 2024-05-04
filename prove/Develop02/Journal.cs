using System.IO;
using System.Net;
using System.Reflection.Metadata;
using System.Security;

class Journal
{
    // Attributes
    public string _filename;
    public string _extension = "txt";
    public List<Entry> _entries = new List<Entry>();

    //Behavior
    public void AddEntry(Entry newEntry)
    {
        _entries
        .Add(newEntry);
    }
    public void DisplayAllEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string fileName)
    {

        fileName = $"{fileName}.{_extension}";
        // check if filename already exist and ask to continue or change the name
        bool fileExit = false;
        if (File.Exists(fileName) && _filename == null)
        {
            while (!fileExit)
            {
                try
                {
                    Console.WriteLine($"{fileName} already exit. Do you want to override the file?: ");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    Console.Write(">: ");
                    int response = int.Parse(Console.ReadLine());
                    if (response == 1)
                    {
                        writeToFile(fileName);
                        break;
                    }
                    else if (response == 2)
                    {
                        Console.Write("Enter Another Filename: ");
                        fileName = Console.ReadLine();
                        fileName = $"{fileName}.{_extension}";
                        if (File.Exists(fileName) == false)
                        {
                            writeToFile(fileName);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry: please choose from the options provided");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Invalid Entry: Numbers only - please choose from the options provided");
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Error: {err}");
                }
            }
        }

        // check if file is not empty and ask to save in current file or new file
        if (_filename != null)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Do you want to save to current file?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    Console.Write(">: ");
                    int response = int.Parse(Console.ReadLine());
                    if (response == 1)
                    {
                        writeToFile(_filename);
                        break;
                    }
                    else if (response == 2)
                    {
                        while (true)
                        {
                            Console.Write("Enter Filename: ");
                            fileName = Console.ReadLine();
                            // save current file name
                            string currentFileName = _filename;
                            // clear _filename for filename checking purpose
                            _filename = null;
                            SaveToFile(fileName);  // check for filename existence
                            // restore the current file loaded.
                            _filename = currentFileName;
                            break;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry: please choose from the options provided");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Invalid Entry: Numbers only - please choose from the options provided");
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Error: {err}");
                }
            }
        }

        void writeToFile(string fileName)
        {
            using (StreamWriter entry = new StreamWriter(fileName))
            {
                foreach (Entry singleEntry in _entries)
                {
                    try
                    {
                        entry.WriteLine($"{singleEntry._date}~{singleEntry._promptText}~{singleEntry._entryText}");
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine($"Error-Saving: {err}");
                    }
                }
                Console.WriteLine($"{fileName} saved successfully!\n");
            }
        }
    }
    public void LoadFromFile(string filename)
    {
        filename = $"{filename}.txt";
        try
        {
            string[] lines = File.ReadAllLines(filename);
            _entries.Clear();  // clear current entries
            // set current loaded filename
            _filename = filename;

            // loop through each line
            foreach (string line in lines)
            {
                string[] parts = line.Split("~");
                Entry newEntry = new Entry();
                newEntry._date = parts[0];
                newEntry._promptText = parts[1];
                newEntry._entryText = parts[2];
                AddEntry(newEntry);
            }

            // display success message to user
            Console.WriteLine($"File: {filename} loaded successfully!\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File-Not-Found: File {filename} not found.\nPlease confirm the filename and try again.\n");
        }
        catch (Exception err)
        {
            Console.WriteLine($"Error Loading File: {err}\n");
        }
    }
    public void DisplaySelectEntry()
    {
        int count = 1;
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"_______________({count})_____________");
            entry.Display();
            count += 1;
        }
    }
    public int EntriesLength()
    {
        return _entries.Count();
    }
    public void EditEntry(int entryNumber, string userText)
    {
        try
        {
            entryNumber--;
            _entries[entryNumber]._entryText = userText;
            Console.WriteLine("Your change is successful.\n");
        }
        catch (IndexOutOfRangeException)
        {
            throw new IndexOutOfRangeException();
        }
    }
}