using System.Collections.Generic;
using System.Text;

namespace permutations
{
    public class Category
    {
        public int Index { get; set; }
        public int MaxIndex { get; set; }
        public string BaseString { get; private set; }
        public List<string> SubCategories { get; set; }

        public Category(int numberOfMembers)
        {
            BaseString = "";
            Index = 0;
            MaxIndex = numberOfMembers - 1;
            for (int i = 0; i < numberOfMembers - 1; i++)
            {
                BaseString += "0";
            }
            BaseString += 1;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("******************************");
            builder.AppendLine($"Base string: {BaseString}");
            if(SubCategories != null)
            {
                foreach (var item in SubCategories)
                {
                    builder.AppendLine(item);
                }
            }
            builder.AppendLine("******************************");
            return builder.ToString();
        }

        public void BuildPermutations()
        {   
            SubCategories = Permutations.BuildPermutations(BaseString);
            SubCategories.Sort();
        }

        public bool WillRotate()
        {
            return Index + 1 > MaxIndex;
        }

        public int Increment()
        {
            if(Index + 1 <= MaxIndex)
                return Index++;
            
            Index = 0;
            return Index;
        }

        public string GetElement()
        {
            return SubCategories[Index];
        }
    }
}