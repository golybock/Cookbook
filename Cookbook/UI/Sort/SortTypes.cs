using System.Collections.Generic;

namespace Cookbook.UI.Sort;

public class SortTypes
{
    public static SortType Default =>
        new SortType() {Id = 0, Name = "По умолчанию"};

    public static SortType Alphabet =>
        new SortType() {Id = 1, Name = "По алфивиту"};

    public static SortType CookingTime =>
        new SortType() {Id = 2, Name = "Время приготовления"};

    public static List<SortType> SortTypesList => new List<SortType>()
    {
        Default,
        Alphabet,
        CookingTime
    };
}