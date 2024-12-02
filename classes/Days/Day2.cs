using System;
    public class Day2 : IDay
    {
      string input = "";
      public void SetInput(string input)
      {
          this.input = input;
      }
      public void LogInput()
      {
          Console.WriteLine(input);
      }
      public bool IsValid(List<int> ints){
        bool match = true;
        int direction = Math.Sign(ints[1] - ints[0]);
        int curr = ints[0];
        for (int i = 1; i < ints.Count; i++){
            int next = ints[i];
            int newDir = Math.Sign(next - curr);
            if (direction != Math.Sign(next - curr) || (direction == 0 && newDir == 0)) {
                match = false;
                break;
            }
            if (Math.Abs(next - curr) > 3) {
                match = false;
                break;
            }
            curr = next;
        }
        return match;
      }

      public bool IsValidWithTolerance(List<int> ints){
        //If isValid failed, remove the fail index from the list and try
        //one more time
        if (IsValid(ints)){
            return true;
        } else {
            //GOTTA BRUTE FORCE THIS SHIT
            for (int i = 0; i < ints.Count; i++){
                var tempList = new List<int>(ints); // Create a copy of the original list
                tempList.RemoveAt(i); 

                if (IsValid(tempList)) {
                    return true;
                }
            }
            return false;
        }
      }

      public string Part1()
      {
        // Implement Part 1
        string[] lines = input.Split("\n");
        int safeLines = 0;
        foreach(string line in lines){
        List<int> numbers = Array.ConvertAll(line.Split(' '), int.Parse).ToList();
        if (IsValid(numbers)) safeLines++;
        }
        return $"{safeLines}";
      }
      public string Part2()
      {
        // Implement Part 2
        string[] lines = input.Split("\n");
        int safeLines = 0;
        foreach(string line in lines){
        List<int> numbers = Array.ConvertAll(line.Split(' '), int.Parse).ToList();
        if (IsValidWithTolerance(numbers)) safeLines++;

        }
        return $"{safeLines}";
      }
    }