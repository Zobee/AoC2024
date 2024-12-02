//GenerateTodaysFiles creates the required day files, and returns today's date
int today = CreateFiles.GenerateTodaysFiles();
string rawData = File.ReadAllText($@"D:\0dev\Advent Of Code\2024\Inputs\Day{today}.txt");
IDay day = new Day2();
day.SetInput(rawData);
// day.LogInput();
day.Solve();