using System.Collections.Generic;

namespace Cookbook.UI.Sort;

public class SortTypes
{
    public static SortType Default => new() {Id = 0, Name = "По умолчанию"};

    public static SortType Alphabet => new() {Id = 1, Name = "По алфивиту"};

    public static SortType CookingTime => new() {Id = 2, Name = "Время приготовления"};

    public static SortType Views => new() {Id = 3, Name = "Просмотры"};

    public static List<SortType> SortTypesList => new()
    {
        Default,
        Alphabet,
        Views
    };
}