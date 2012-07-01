using System.Collections.Generic;

namespace Trivia
{
    public class CategoryProvider
    {
        private readonly Dictionary<int, string> categoriesForPosition;
        
        public CategoryProvider()
        {
            categoriesForPosition = new Dictionary<int, string>();
            
            3.Times(i =>
            {
                categoriesForPosition.Add(4 * i, "Pop");
                categoriesForPosition.Add(4 * i + 1, "Science");
                categoriesForPosition.Add(4 * i + 2, "Sports");
                categoriesForPosition.Add(4 * i + 3, "Rock");
            });
        }

        public string GetCategoryForPosition(int position)
        {
            return categoriesForPosition[position];
        }
    }
}