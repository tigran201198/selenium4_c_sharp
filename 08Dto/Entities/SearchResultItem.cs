using System;

namespace _08Dto.Entities
{
    public class SearchResultItem
    {
        public string Title { get; }

        public string Description { get; }

        public SearchResultItem(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public override bool Equals(object obj) => obj is SearchResultItem item &&
                   Title == item.Title &&
                   Description == item.Description;

        public override int GetHashCode() => HashCode.Combine(Title, Description);

        public override string ToString() => $"{nameof(SearchResultItem)}:{{\n" +
                $"{nameof(Title)}={Title},\n" +
                $"{nameof(Description)}={Description}\n}}";
    }
}
