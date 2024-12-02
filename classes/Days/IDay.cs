public interface IDay{
  void SetInput(string input);
  void LogInput();
  string Part1();
  string Part2();
  void Solve(){
    Console.WriteLine($"Part 1 solution: {Part1()}");
    Console.WriteLine($"Part 2 solution: {Part2()}");
  }
}