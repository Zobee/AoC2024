using System.Text.RegularExpressions;

public class Day3 : IDay
    {
      string input = "";
      readonly string mulPattern = @"mul\(\d+,\d+\)";
      readonly string doDontPattern = @"do\(\)|don't\(\)";
      public void SetInput(string input)
      {
          this.input = input;
      }
      public void LogInput()
      {
          Console.WriteLine(input);
      }

      public int CallMul(Match match){
        string strippedCall = match.Value.Substring(4, match.Value.Length - 5);
        int[] nums = Array.ConvertAll(strippedCall.Split(","), int.Parse).ToArray();
        return nums[0] * nums[1];
      }

      public string Part1()
      {
          // Implement Part 1
          int total = 0;
          //Find every valid instance of mul(n,n) in the string
          MatchCollection matches = Regex.Matches(input, mulPattern);
          foreach (Match match in matches){
            total += CallMul(match);
          }
          return $"{total}"; //188741603
      }
      public string Part2()
      {
          // Implement Part 2
          // Mults are enabled by do/don't functions. Enabled by default. If don't() is called, all mults are ignored until another do() is called.
          //Instead of regex, manual parsing makes sense here
          List<string> validMults = new List<string>();

          int total = 0;
          bool doMult = true;
          string currString = "";

          for (int i = 0; i < input.Length; i++){
            int endInd = input.IndexOf(")", i);
            if (endInd > i){
              currString = input.Substring(i, endInd - i + 1);

              //check if string is a do/don't call
              Match doDontMatch = Regex.Match(currString, doDontPattern);
              if (!doDontMatch.Value.Equals("")){
                bool doMatch = doDontMatch.Value.Equals("do()"); 
                if (doMult != doMatch) doMult = doMatch;
              }

              //otherwise, check if it's a mul call

              Match mulMatch = Regex.Match(currString, mulPattern);
              if (!mulMatch.Value.Equals("") && doMult) {
                total += CallMul(mulMatch);
              }
              currString = "";
            }
            i += endInd - i;
          }

          return $"{total}";
      }
    }