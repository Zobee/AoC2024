using System;

    public class Day1 : IDay
    {
        string input = "";
        List<int> A = new List<int>();
        List<int> B = new List<int>();

        public void GenerateLists(){
            A.Clear();
            B.Clear();
            string[] lines = input.Split("\n");
            foreach(string line in lines){
                string[] ids = line.Split("   ");
                A.Add(int.Parse(ids[0]));
                B.Add(int.Parse(ids[1]));
            }
        }

        public void SetInput(string input){
            this.input = input;
        }
        public void LogInput(){
            Console.WriteLine(input);
        }
        public string Part1()
        {
            // Implement Part 1
            GenerateLists();

            A.Sort();
            B.Sort();

            int totalDiff = 0;
            for (int i = 0; i < A.Count; i++){
                totalDiff += Math.Abs(A[i] - B[i]);
            }

            return $"{totalDiff}";
        }

        public string Part2()
        {
            // Implement Part 2
            GenerateLists();

            Dictionary<int, int> listBFrequencyMap = new Dictionary<int, int>();
            foreach (int n in B){
                if (listBFrequencyMap.ContainsKey(n)){
                    listBFrequencyMap[n] ++;
                } else {
                    listBFrequencyMap[n] = 1;
                }
            }

            int total = 0;
            foreach (int n in A){
                if (listBFrequencyMap.ContainsKey(n)){
                    total += n * listBFrequencyMap[n];
                }
            }
            
            return $"{total}";
        }
    }