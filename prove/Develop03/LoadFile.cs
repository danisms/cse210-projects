using Microsoft.VisualBasic.FileIO;

public class LoadFile
{
   private List<string> _directories = new List<string>();
   private List<string> _files = new List<string>();
   private string _mainDirectory;
   private string _dirName;
   private string _fileName;
   private List<string> _contents = new List<string>();
   private string[] _currentSelectedContent;

   // Constructor
   public LoadFile()
   {
      _mainDirectory = "../../../scriptures";
      LoadDirectories(_mainDirectory);
   }

   // Methods
   public void LoadDirectories(string dirName)
   {
      // load all directories in the current current directory - at initial (main directory)
      Console.WriteLine(dirName);  // for testing purpose
      try
      {
         string[] allDirectories = Directory.GetDirectories(dirName);
         // clear current directories and loop through allDirectories and load it to directories
         _directories.Clear();
         foreach (string directory in allDirectories)
         {
            _directories.Add(directory);
            Console.WriteLine($"Adding directory: {directory}");  // for testing purpose
         }
      }
      catch (Exception error)
      {
         Console.WriteLine($"Error: {error}");
      }

      if (dirName != _mainDirectory)
      {
         LoadFilesInDir(dirName);
      }
   }
   private void LoadFilesInDir(string dirname)
   {
      // Load all files in a selected directory into the _file list.
      try
      {
         string[] allFiles = Directory.GetFiles(dirname);
         // clear current files list and add new files
         _files.Clear();
         foreach (string file in allFiles)
         {
            _files.Add(file);
         }
         _dirName = dirname;
      }
      catch (Exception error)
      {
         Console.WriteLine($"Error: {error}");
      }
   }
   public string getDirName(int directoryNumber)
   {
      int dirNum = directoryNumber - 1;
      string dirName = _directories[dirNum];
      return dirName;
   }
   public string getFileName(int fileNumber)
   {
      // use the int number to return a filename
      int fileListNum = fileNumber - 1;
      string fileName = _files[fileListNum];
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
         foreach (string line in lines)
         {
            _contents.Add(line);
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
         TextFieldParser textParser = new TextFieldParser(new StringReader(_contents[lineNumber]));
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
   public void WriteToFile(string filename)
   {

   }
   public void SaveToFile(string filename)
   {

   }
   public void DisplayDirectories()
   {
      // display all directory in the main directory
      int count = 1;
      foreach (string directory in _directories)
      {
         string[] dirNameParts = directory.Split("../");
         string dirName = dirNameParts[dirNameParts.Length - 1];
         Console.WriteLine($"{count}: {dirName.Split("\\")[1]}");
         count++;
      }
   }
   public void DisplayFiles()
   {
      int count = 1;
      foreach (string file in _files)
      {
         string[] fileNameMainParts = file.Split("../");
         string fileName = fileNameMainParts[fileNameMainParts.Length - 1];
         // split further to get filename and extension
         string[] fileNameParts = fileName.Split("\\");
         fileName = fileNameParts[fileNameParts.Length - 1];
         // splitting further to get just the filename without extension
         fileNameParts = fileName.Split(".");
         fileName = fileNameParts[0];
         // display value
         Console.WriteLine($"{count}: {fileName}");
         count++;
      }
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
         Console.WriteLine($"{count}: {book} {chapter}:{verse}");
      }
   }
}