﻿using System;

namespace Cookbook.FileGenerating;

public class RecipeDocX
{
    // public static void Generate(Recipe recipe)
    // {
    //     throw new NotImplementedException();
    //     // var fileName = recipe.Header + ".docx";
    //     //
    //     // var fullPath = $"C://{Environment.UserName}/Documents/" + fileName;
    //     //
    //     // try
    //     // {
    //     //     using var doc = DocX.Create(fullPath);
    //     //
    //     //     // добавляем фото рецепта(если есть)
    //     //     try
    //     //     {
    //     //         var image = doc.AddImage(recipe.ImagePath);
    //     //         var pic = image.CreatePicture(300f, 300f);
    //     //
    //     //         var p = doc.InsertParagraph("");
    //     //         p.AppendPicture(pic);
    //     //     }
    //     //     catch (Exception e)
    //     //     {
    //     //         // ignored
    //     //     }
    //     //
    //     //     doc.InsertParagraph(recipe.ToString()).FontSize(20);
    //     //
    //     //     doc.Save();
    //     //
    //     //     ShowDialog(fullPath);
    //     // }
    //     // catch (Exception e)
    //     // {
    //     //     ShowErrorDialog("Ошибка генерации файла");
    //     // }
    // }

    // private static async void ShowErrorDialog(string error)
    // {
    //     var addDialog = new ContentDialog
    //     {
    //         Title = "Ошибка",
    //         Content = error,
    //         CloseButtonText = "Закрыть"
    //     };
    //
    //     await addDialog.ShowAsync();
    // }
    //
    //
    // private static async void ShowDialog(string path)
    // {
    //     var acceptDialog = new ContentDialog
    //     {
    //         Title = "Файл готов",
    //         Content = "Открыть файл?",
    //         CloseButtonText = "Не открывать",
    //         PrimaryButtonText = "Открыть",
    //         DefaultButton = ContentDialogButton.Primary
    //     };
    //
    //     var result = await acceptDialog.ShowAsync();
    //
    //     if (result == ContentDialogResult.Primary)
    //         ShowFileInExplorer(path);
    // }
    //
    // private static void ShowFileInExplorer(string path)
    // {
    //     Process.Start(new ProcessStartInfo
    //         {
    //             FileName = "explorer", Arguments = $"/n, /select, {path}"
    //         }
    //     );
    // }
}