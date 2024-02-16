using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.FlashCard;

namespace MAUI.SpeechTherapy.Services.FlashCard
{
    public class FlashCardCategoryService
    {
        SpeechDb db = new SpeechDb();
        public async Task<GenericPageByPage<FlashCardCategory>> GetPageByPage(int PageSize, int PageNumber)
        {
            GenericPageByPage<FlashCardCategory> Book = new GenericPageByPage<FlashCardCategory>();
            string query = "Select Id,Name" +
                " From FlashCardCategory" +
                " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From AlphbaBookModel";
            Book.Items = await db.QueryGetEntityList<FlashCardCategory>(query);
            Book.RowCount = await db.GetCount(queryCount);
            return Book;
        }
        public async Task<GenericPageByPage<FlashCardCategory>> GetPageByPage()
        {
            GenericPageByPage<FlashCardCategory> Book = new GenericPageByPage<FlashCardCategory>();
            string query = "Select Id,Name From FlashCardCategory";
            Book.Items = await db.QueryGetEntityList<FlashCardCategory>(query);
            Book.RowCount = Book.Items.Count;
            return Book;
        }

    }
}
