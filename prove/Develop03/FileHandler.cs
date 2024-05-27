using System.Runtime.InteropServices;
using Microsoft.VisualBasic.FileIO;

public class FileHandler
{
   private List<string> _directories = new List<string>();
   private List<string> _files = new List<string>();
   private string _mainDirectory;
   private string _dirName;
   private string _fileName;
   private string _extension = "csv";
   private int _fileOrDirCount;  // get the number of file/directory in a directory
   private List<string> _contents = new List<string>();
   private string[] _currentSelectedContent;

   // Constructor
   public FileHandler()
   {
      _mainDirectory = "scriptures";
      LoadDirectories(_mainDirectory);
   }

   // Methods
   public void LoadDirectories(string dirName)
   {
      // load all directories in the current current directory - at initial (main directory)
      // Console.WriteLine(dirName);  // for testing purpose
      try
      {
         string[] allDirectories = Directory.GetDirectories(dirName);
         // clear current directories and loop through allDirectories and load it to directories
         _directories.Clear();
         foreach (string directory in allDirectories)
         {
            _directories.Add(directory);
            // Console.WriteLine($"Adding directory: {directory}");  // for testing purpose
         }
      }
      catch (IndexOutOfRangeException)
      {
         Console.WriteLine("Invalid Choice: Please chose from the options available");
      }
      catch (Exception error)
      {
         Console.WriteLine($"Error: {error}");
      }

      if (dirName != _mainDirectory)
      {
         FileInDir(dirName);
      }
   }
   private void FileInDir(string dirname)
   {
      // Load all files in a selected directory into the _file list.
      try
      {
         string[] allFiles = Directory.GetFiles(dirname);
         // clear current files list and add new files
         _files.Clear();
         _fileOrDirCount = 0;
         foreach (string file in allFiles)
         {
            _files.Add(file);
            _fileOrDirCount++;
         }
         _dirName = dirname;
      }
      catch (IndexOutOfRangeException)
      {
         Console.WriteLine("Invalid Choice: Please choose from the options available");
      }
      catch (Exception error)
      {
         Console.WriteLine($"Error: {error}");
      }
   }
   public string getDirName(int directoryNumber)
   {
      int dirNum = directoryNumber - 1;
      string dirName = null;
      try
      {
         dirName = _directories[dirNum];
      }
      catch (IndexOutOfRangeException)
      {
         Console.WriteLine("Invalid Choice: Please Choose from the options above");
      }
      catch (Exception error)
      {
         Console.WriteLine(error);
      }
      return dirName;
   }
   public string getFileName(int fileNumber)
   {
      // use the int number to return a filename
      int fileListNum = fileNumber - 1;
      string fileName = null;
      try
      {
         fileName = _files[fileListNum];
      }
      catch (IndexOutOfRangeException)
      {
         Console.WriteLine("Invalid Choice: Please choose from the options above");
      }
      return fileName;
   }

   public void LoadFromFile(string filename)
   {
      try
      {
         string[] lines = File.ReadAllLines(filename);
         _contents.Clear();  // clear current content
                             // set current loaded filename
         _fileName = filename;

         // loop through each line
         _fileOrDirCount = 1;
         foreach (string line in lines.Skip(1))
         {
            _contents.Add(line);
            _fileOrDirCount++;
         }

         // // display success message to user
         // Console.WriteLine($"File: {filename} loaded successfully!\n");
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

   public void LoadFromFile2(string filename)
   {
      try
      {
         string[] lines = File.ReadAllLines(filename);
         _contents.Clear();  // clear current content
                             // set current loaded filename
         _fileName = filename;

         // loop through each line
         _fileOrDirCount = 1;
         foreach (string line in lines)
         {
            _contents.Add(line);
            _fileOrDirCount++;
         }

         // // display success message to user
         // Console.WriteLine($"File: {filename} loaded successfully!\n");
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

   public string[] GetALine(int lineNumber)
   {
      try
      {
         // set current loaded filename
         TextFieldParser textParser = new TextFieldParser(new StringReader(_contents[lineNumber - 1]));
         using (textParser)
         {
            textParser.HasFieldsEnclosedInQuotes = true;
            textParser.SetDelimiters(",");
            // assign the value
            while (!textParser.EndOfData)
            {
               _currentSelectedContent = textParser.ReadFields();
            }
         }

         // display success message to user
         // Console.WriteLine($"File: {lineNumber} loaded successfully!\n");
         // foreach (string content in _currentSelectedContent)
         // {
         //    Console.WriteLine(content);
         // }  // for testing purpose
      }
      catch (IndexOutOfRangeException)
      {
         Console.WriteLine($"Content-Not-Found: Scripture in {lineNumber} not found.\nPlease confirm the number and try again.\n");
      }
      catch (Exception err)
      {
         Console.WriteLine($"Error Loading File: {err}\n");
      }
      return _currentSelectedContent;
   }
   public void WriteToFile(string filename, string book, int chapter, int startVerse, int endVerse, string text)
   {
      // filename = $"{_mainDirectory}/customized/{filename}.csv";
      string aPassage = $"{book},{chapter},{startVerse}-{endVerse},\"{text}\"";
      _contents.Add(aPassage);
      using (StreamWriter fileParser = new(filename))
      {
         foreach (string passage  in _contents)
         {
            try
            {
               fileParser.WriteLine(passage);
            }
            catch (Exception err)
            {
               Console.WriteLine($"Error-Saving: {err}");
            }
         }
         Console.WriteLine($"entered and saved to {filename.Split(".")[0]} successfully\n");
      }
   }
   
   public void WriteToFile(string filename, string book, int chapter, int aVerse, string text)
   {
      // filename = $"{_mainDirectory}/customized/{filename}.{_extension}";
      string aPassage = $"{book},{chapter},{aVerse},\"{text}\"";
      _contents.Add(aPassage);
      using (StreamWriter fileParser = new(filename))
      {
         foreach (string passage  in _contents)
         {
            try
            {
               fileParser.WriteLine(passage);
            }
            catch (Exception err)
            {
               Console.WriteLine($"Error-Saving: {err}");
            }
         }
         Console.WriteLine($"entered and saved to {filename.Split(".")[0]} successfully\n");
      }
   }

   public void CreateFile(string filename)
   {
      // modify fileName to proper saving file-name
      filename = $"{_mainDirectory}/customized/{filename}.{_extension}";
      // create file if not in existence and write to the file
      void Create(string filename)
      {
         // _contents.Clear();
         using (StreamWriter fileParser = new(filename))
         {
            fileParser.WriteLine("Book,Chapter,Verse,Text");
            Console.WriteLine($"{filename.Split(".")[0]} created successfully\n");
         }
      }

      // check if filename already exist and ask to continue or change the name
      bool fileExit = false;
      if (File.Exists(filename))
      {
         while (!fileExit)
         {
               try
               {
                  Console.WriteLine($"{filename.Split(".")[0]} already exit. Do you want to override the file?: ");
                  Console.WriteLine("1. Yes");
                  Console.WriteLine("2. No");
                  Console.Write(">: ");
                  int response = int.Parse(Console.ReadLine());
                  if (response == 1)
                  {
                     Create(filename);
                     break;
                  }
                  else if (response == 2)
                  {
                     Console.Write("Enter Another Filename: ");
                     filename = Console.ReadLine();
                     filename = $"{filename}.{_extension}";
                     if (File.Exists(filename) == false)
                     {
                           Create(filename);
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
      else
      {
         Create(filename);
      }
   }
   public void DisplayDirectories()
   {
      // check operating system
      bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
      // Console.WriteLine($"isWindows: {isWindows}");  // for debugging purpose
      // display all directory in the main directory
      int count = 1;
      foreach (string directory in _directories)
      {
         string[] dirNameParts = directory.Split("../");
         string dirName = dirNameParts[dirNameParts.Length - 1];
         if (isWindows)
         {
            Console.WriteLine($"{count}: {dirName.Split("\\")[1]}");
         }
         else {
            Console.WriteLine($"{count}: {dirName.Split("/")[1]}");
         }
         count++;
      }
      _fileOrDirCount = count;
   }
   public bool DisplayFiles()
   {
      // check operating system
      bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
      // Console.WriteLine($"isWindows: {isWindows}");  // for debugging purpose

      // display files and return true if folder is empty else return false
      int count = 1;
      bool isEmpty;
      if (_files.Count > 0)
      {
         foreach (string file in _files)
         {
            // Console.WriteLine(file);  // for debugging purpose
            string[] fileNameMainParts = file.Split("../");
            string fileName = fileNameMainParts[fileNameMainParts.Length - 1];
            // split further to get filename and extension
            string[] fileNameParts;
            if (isWindows)
            {
               fileNameParts = fileName.Split("\\");
            }
            else
            {
               fileNameParts = fileName.Split("/");
            }
            
            fileName = fileNameParts[fileNameParts.Length - 1];
            // splitting further to get just the filename without extension
            fileNameParts = fileName.Split(".");
            fileName = fileNameParts[0];
            // display value
            Console.WriteLine($"{count}: {fileName}");
            count++;
         }
         isEmpty = false;
      }
      else
      {
         Console.WriteLine("Empty Folder");
         isEmpty = true;
      }
      _fileOrDirCount = count;
      return isEmpty;
   }
   public void DisplayFileContent()
   {
      int count = 1;
      foreach (string content in _contents)
      {
         string[] parts = content.Split(",");
         string book = parts[0];
         string chapter = parts[1];
         string verse = parts[2];
         // display reference to user
         Console.WriteLine($"{count}. {book} {chapter}:{verse}");
         count++;
      }
      _fileOrDirCount = count;
   }
   public void DisplayFullContent()
   {
      int count = 1;
      foreach (string content in _contents)
      {
         string[] parts = content.Split(",");
         string book = parts[0];
         string chapter = parts[1];
         string verse = parts[2];
         string text = parts[3];
         // display reference to user
         Console.WriteLine($"--------({count})--------\n{book} {chapter}:{verse}\n{text}\n");
         Console.WriteLine();  // for spacing
         count++;
      }
      _fileOrDirCount = count;
   }

   public int GetCount()
   {
      return _fileOrDirCount;
   }
}