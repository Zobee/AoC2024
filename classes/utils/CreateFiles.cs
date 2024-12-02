public static class CreateFiles{
  public static int GenerateTodaysFiles(int day = 0){
    int today = day != 0 ? day : DateTime.Now.Day;
    string basePath = @"D:\0dev\Advent Of Code\2024";
    string txtPath = $@"{basePath}\Inputs/Day{today}.txt";
    string classPath = $@"{basePath}\classes\Days\Day{today}.cs";
    string template = $@"public class Day{today} : IDay
    {{
      string input = """";
      public void SetInput(string input)
      {{
          this.input = input;
      }}
      public void LogInput()
      {{
          Console.WriteLine(input);
      }}
      public string Part1()
      {{
          // Implement Part 1
          return ""Result of Day {today} Part 1"";
      }}
      public string Part2()
      {{
          // Implement Part 2
          return ""Result of Day {today} Part 2"";
      }}
    }}";
    if (!File.Exists(txtPath)){
      File.WriteAllText(txtPath, "INPUT NOT SET YET");
      File.WriteAllText(classPath, template);
    }

    //Get the current day via system
    //If there aren't a Day{day}.cs or Day{day}.txt files, create them
    return today;
  }
}