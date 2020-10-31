using System;

namespace TemplateMethod
{
    // It is a pattern used to apply separate functions to different people or groups.
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;
            Console.WriteLine("Mans");
            algorithm =new MenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8,new TimeSpan(0,2,35)));

            Console.WriteLine("Women");
            algorithm = new WomensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 15)));

            Console.WriteLine("Mans");
            algorithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 35)));
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits,TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score,reduction);
        }

        public abstract int CalculateOverallScore(in int score, in int reduction);
       

        public abstract int CalculateReduction(in TimeSpan time);
        

        public abstract int CalculateBaseScore(int hits);

    }

    class MenScoringAlgorithm:ScoringAlgorithm
    {
        public override int CalculateOverallScore(in int score, in int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(in TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }
    class WomensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(in int score, in int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(in TimeSpan time)
        {
            return (int)time.TotalSeconds / 3; 
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }
    class ChildrenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(in int score, in int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(in TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }
    }
}
