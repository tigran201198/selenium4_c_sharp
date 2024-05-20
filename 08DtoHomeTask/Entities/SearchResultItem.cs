using System;

namespace _08DtoHomeTask.Entities
{
    public class SearchResultItem
    {
        public string Title { get; }

        public string HrefAttributeValue { get; }

        public SearchResultItem(string title, string hrefAttribte)
        {
            Title = title;
            HrefAttributeValue = hrefAttribte;
        }

        public override bool Equals(object obj) => obj is SearchResultItem item &&
                   Title == item.Title &&
                   HrefAttributeValue == item.HrefAttributeValue;

        public override int GetHashCode() => HashCode.Combine(Title, HrefAttributeValue);

        public override string ToString() => $"{nameof(SearchResultItem)}:{{\n" +
                $"{nameof(Title)}={Title},\n" +
                $"{nameof(HrefAttributeValue)}={HrefAttributeValue}\n}}";
    }
}
