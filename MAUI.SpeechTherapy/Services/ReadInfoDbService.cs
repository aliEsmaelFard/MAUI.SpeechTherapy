using MAUI.SpeechTherapy.DataBase;
using MAUI.SpeechTherapy.Models;
using MAUI.SpeechTherapy.Models.Alphba;
using MAUI.SpeechTherapy.Models.Concept;
using MAUI.SpeechTherapy.Models.FlashCard;
using MAUI.SpeechTherapy.Models.Question;
using MAUI.SpeechTherapy.Models.SentenceMaking;
namespace MAUI.SpeechTherapy.Services
{
    public class ReadInfoDbService
    {
        SpeechDb db = new SpeechDb();

        /// <summary>
        /// GetAll info Alphba
        /// </summary>
        /// <returns> All Record</returns>
        public async Task<GenericPageByPage<AlphbaModel>> AlphbaListAsync()
        {
            GenericPageByPage<AlphbaModel> alphba = new GenericPageByPage<AlphbaModel>();
            //string query = "Select Id,Name,FileId,Data,FileType" +queryCount+
            //    " From AlphbaModel,FileModel" +
            //    " where AlphbaModel.FileId=FileModel.Id";
            //string query = "Select Id,Name,FileId From AlphbaModel";

            alphba.Items = await db.GetEntityList<AlphbaModel>();
            alphba.RowCount = alphba.Items.Count;
            return alphba;
        }
        /// <summary>
        /// Get Info Alphba Words
        /// </summary>
        /// <param name="CategoryId">Id Table Alphba</param>
        /// <param name="Position">Position letter in word</param>
        /// <returns></returns>
        public async Task<GenericPageByPage<AlphbaWordModel>> AlphbaWordListAsync(int AlphbaId, int Position)
        {
            GenericPageByPage<AlphbaWordModel> wordDto = new GenericPageByPage<AlphbaWordModel>();
            string query = "Select Id,Word,Type,AlphbaId" +
                " From AlphbaWordModel" +
                " where AlphbaId=" + AlphbaId + " and Type=" + Position;

            wordDto.Items = await db.QueryGetEntityList<AlphbaWordModel>(query);
            wordDto.RowCount = wordDto.Items.Count;
            return wordDto;
        }
        /// <summary>
        /// Get Info AlphbaBook
        /// </summary>
        /// <param name="PageSize">Count Records</param>
        /// <param name="PageNumber">Start Record</param>
        /// <param name="AlphbaId">Id table Alphba</param>
        /// <returns></returns>
        public async Task<GenericPageByPage<AlphbaBookModel>> AlphbaBookListAsync(int AlphbaId, int PageNumber,int PageSize)
        {
            GenericPageByPage<AlphbaBookModel> Book = new GenericPageByPage<AlphbaBookModel>();
            string query = "Select AlphbaBookModel.Id,Text,Data,FileType" +
                " From AlphbaBookModel,FileModel" +
                " where AlphbaBookModel.FileId=FileModel.Id" +
                " and AlphbaId=" + AlphbaId + " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From AlphbaBookModel where AlphbaId=" + AlphbaId;
            Book.Items = await db.QueryGetEntityList<AlphbaBookModel>(query);
            Book.RowCount = await db.GetCount(queryCount);
            return Book;
        }
        /// <summary>
        /// Get Info AlphbaBook
        /// </summary>
        /// <param name="AlphbaId">Id table Alphba</param>
        /// <returns>All Record</returns>
        public async Task<GenericPageByPage<AlphbaBookModel>> AlphbaBookListAsync(int AlphbaId)
        {
            GenericPageByPage<AlphbaBookModel> Book = new GenericPageByPage<AlphbaBookModel>();
            string query = "Select AlphbaBookModel.Id,Text,FileModel.FileType,FileModel.Data" +
                " From AlphbaBookModel,FileModel" +
                " where AlphbaBookModel.FileId=FileModel.Id" +
                " and AlphbaId=" + AlphbaId ;
            
            Book.Items = await db.QueryGetEntityList<AlphbaBookModel>(query);
            Book.RowCount = Book.Items.Count;
            return Book;
        }
       




        /// <summary>
        /// GetAll info CategorySentence
        /// </summary>
        /// <returns> All Record</returns>
        public async Task<GenericPageByPage<ConceptCategorySentenceModel>> CategorySentenceListAsync()
        {
            GenericPageByPage<ConceptCategorySentenceModel> category = new GenericPageByPage<ConceptCategorySentenceModel>();

            category.Items = await db.GetEntityList<ConceptCategorySentenceModel>();
            category.RowCount = category.Items.Count;
            return category;
        }
        /// <summary>
        /// GetAll info CategoryConceptQuestion
        /// </summary>
        /// <returns> All Record</returns>
        public async Task<GenericPageByPage<ConceptCategoryQuestionModel>> CategoryQuestionListAsync()
        {
            GenericPageByPage<ConceptCategoryQuestionModel> Category = new GenericPageByPage<ConceptCategoryQuestionModel>();


            Category.Items = await db.GetEntityList<ConceptCategoryQuestionModel>();
            Category.RowCount = Category.Items.Count;
            return Category;
        }
        /// <summary>
        /// Get Info ConceptSentence
        /// </summary>
        /// <param name="PageSize">Count Records</param>
        /// <param name="PageNumber">Start Record</param>
        /// <param name="CategoryId">Id table CategorySentence</param>
        /// <returns></returns>
        public async Task<GenericPageByPage<ConceptSentenceModel>> ConceptSentenceListAsync( int CategoryId, int PageNumber,int PageSize)
        {
            GenericPageByPage<ConceptSentenceModel> Page = new GenericPageByPage<ConceptSentenceModel>();
            string query = "Select ConceptSentenceModel.Id,Text,Data,FileType" +
                " From ConceptSentenceModel,FileModel" +
                " where ConceptSentenceModel.FileId=FileModel.Id" +
                " and CategoryId=" + CategoryId + " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From ConceptSentenceModel where CategoryId=" + CategoryId;
            Page.Items = await db.QueryGetEntityList<ConceptSentenceModel>(query);
            Page.RowCount = await db.GetCount(queryCount);
            return Page;
        }
        /// <summary>
        /// Get info ConceptSentence
        /// </summary>
        /// <param name="CategoryId">Id from Table CategorySentence</param>
        /// <returns>All Record</returns>
        public async Task<GenericPageByPage<ConceptSentenceModel>> ConceptSentenceListAsync( int CategoryId)
        {
            GenericPageByPage<ConceptSentenceModel> Page = new GenericPageByPage<ConceptSentenceModel>();
            string query = "Select ConceptSentenceModel.Id,Text,Data,FileType" +
                " From ConceptSentenceModel,FileModel" +
                " where ConceptSentenceModel.FileId=FileModel.Id" +
                " and CategoryId=" + CategoryId;
            
            Page.Items = await db.QueryGetEntityList<ConceptSentenceModel>(query);
            Page.RowCount = Page.Items.Count;
            return Page;
        }
        /// <summary>
        /// Get info Concept Question
        /// </summary>
        /// <param name="CategoryId">Id From table CategoryConceptQuestion</param>
        /// <param name="PageSize">Count Records</param>
        /// <param name="PageNumber">Start Record</param>
        /// <returns>Get Limit Record</returns>
        public async Task<GenericPageByPage<ConceptQuestionModel>> ConceptQuestionListAsync(int CategoryId ,int PageNumber, int PageSize)
        {
            GenericPageByPage<ConceptQuestionModel> Pages = new GenericPageByPage<ConceptQuestionModel>();
            string query = "Select ConceptQuestionModel.Id,RightAnswer,WrongAnswer,Data,FileType" +
               " From ConceptQuestionModel,FileModel" +
               " where ConceptQuestionModel.FileId=FileModel.Id" +
               " and CategoryId = " + CategoryId + "  LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From ConceptQuestionModel" +
                " where CategoryId =" + CategoryId;
            Pages.Items = await db.QueryGetEntityList<ConceptQuestionModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        } 
        /// <summary>
        /// Get info Concept Question
        /// </summary>
        /// <param name="CategoryId">id from Table CategoryConceptQuestion</param>
        /// <returns>All records</returns>
        public async Task<GenericPageByPage<ConceptQuestionModel>> ConceptQuestionListAsync(int CategoryId)
        {
            GenericPageByPage<ConceptQuestionModel> Pages = new GenericPageByPage<ConceptQuestionModel>();
            string query = "Select ConceptQuestionModel.Id,CategoryId,FileId,RightAnswer,WrongAnswer,Data,FileType" +
               " From ConceptQuestionModel,FileModel" +
               " where ConceptQuestionModel.FileId=FileModel.Id" +
               " and CategoryId = " + CategoryId ;
            
            Pages.Items = await db.QueryGetEntityList<ConceptQuestionModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }




        /// <summary>
        /// Get limit Category FlashCard
        /// </summary>
        /// <param name="PageSize">Count Record</param>
        /// <param name="PageNumber">Start Record</param>
        /// <returns></returns>
        public async Task<GenericPageByPage<FlashCardCategory>> FlashCardCategoryListAsync( int PageNumber,int PageSize)
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
        /// <summary>
        /// Get Info Category Flash card
        /// </summary>
        /// <returns>GetAll Category FlashCard</returns>
        public async Task<GenericPageByPage<FlashCardCategory>> FlashCardCategoryListAsync()
        {
            GenericPageByPage<FlashCardCategory> Book = new GenericPageByPage<FlashCardCategory>();
            string query = "Select Id,Name From FlashCardCategory";
            Book.Items = await db.QueryGetEntityList<FlashCardCategory>(query);
            Book.RowCount = Book.Items.Count;
            return Book;
        }
        /// <summary>
        /// Get Info FlashCard
        /// </summary>
        /// <param name="PageSize">Count Record</param>
        /// <param name="PageNumber">Start Record</param>
        /// <param name="CategoryId">Id From Table FlashCategory</param>
        /// <returns>Get Limit Record</returns>
        public async Task<GenericPageByPage<FlashCardModel>> FlashCardListAsync(int CategoryId, int PageNumber,int PageSize )
        {
            GenericPageByPage<FlashCardModel> Pages = new GenericPageByPage<FlashCardModel>();
            string query = "Select FlashCardModel.Id,Name,Data,FileType" +
               " From FlashCardModel,FileModel" +
               " where FlashCardModel.FileId=FileModel.Id" +
               " and CategoryId=" + CategoryId + " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From FlashCardModel";
            Pages.Items = await db.QueryGetEntityList<FlashCardModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        /// <summary>
        /// Get Info FlashCard
        /// </summary>
        /// <param name="CategoryId">Id From Table FlashCardCategory</param>
        /// <returns>Get All Record</returns>
        public async Task<GenericPageByPage<FlashCardModel>> FlashCardListAsync(int CategoryId)
        {
            GenericPageByPage<FlashCardModel> Pages = new GenericPageByPage<FlashCardModel>();
            string query = "Select FlashCardModel.Id,Name,FileModel.Data,FileModel.FileType" +
               " From FlashCardModel,FileModel" +
               " where FlashCardModel.FileId=FileModel.Id" +
               " and CategoryId=" + CategoryId;
            Pages.Items = await db.QueryGetEntityList<FlashCardModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }




        /// <summary>
        /// GetAll info Alphba
        /// </summary>
        /// <returns> All Record</returns>
        public async Task<GenericPageByPage<QuestionCategoryModel>> QuestionCategoryListAsync()
        {
            GenericPageByPage<QuestionCategoryModel> Pages = new GenericPageByPage<QuestionCategoryModel>();
            Pages.Items = await db.GetEntityList<QuestionCategoryModel>();
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }

        /// <summary>
        /// Get info Concept Question
        /// </summary>
        /// <param name="CategoryId">Id From table CategoryConceptQuestion</param>
        /// <param name="PageSize">Count Records</param>
        /// <param name="PageNumber">Start Record</param>
        /// <returns>Get Limit Record</returns>
        public async Task<GenericPageByPage<QuestionModel>> QuestionListAsync(int CategoryId, int PageNumber, int PageSize)
        {
            GenericPageByPage<QuestionModel> Pages = new GenericPageByPage<QuestionModel>();
            string query = "Select QuestionModel.Id,RightAnswer,WrongAnswer,Data,FileType,FileId" +
               " From QuestionModel,FileModel" +
               " where QuestionModel.FileId=FileModel.Id" +
               " and CategoryId=" + CategoryId + "  LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From QuestionModel" +
                " where  CategoryId=" + CategoryId;
            Pages.Items = await db.QueryGetEntityList<QuestionModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        /// <summary>
        /// Get info  Question
        /// </summary>
        /// <param name="CategoryId">id from Table CategoryQuestion</param>
        /// <returns>All records</returns>
        public async Task<GenericPageByPage<QuestionModel>> QuestionListAsync(int CategoryId)
        {
            GenericPageByPage<QuestionModel> Pages = new GenericPageByPage<QuestionModel>();
            string query = "Select QuestionModel.Id,RightAnswer,WrongAnswer,FileModel.Data,FileModel.FileType,FileId" +
               " From QuestionModel,FileModel" +
               " where QuestionModel.FileId=FileModel.Id" +
               " and CategoryId = " + CategoryId;

            Pages.Items = await db.QueryGetEntityList<QuestionModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }


        /// <summary>
        /// Get info Object
        /// </summary>
        /// <param name="PageSize">Count Record</param>
        /// <param name="PageNumber">Start Record</param>
        /// <returns>Get Limit Record</returns>
        public async Task<GenericPageByPage<ObjectModel>> ObjectListAsync(int PageNumber,int PageSize)
        {
            GenericPageByPage<ObjectModel> Pages = new GenericPageByPage<ObjectModel>();
            string query = "Select ObjectModel.Id,Name,Data,FileType" +
               " From ObjectModel,FileModel" +
               " where ObjectModel.FileId=FileModel.Id" +
               " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From ObjectModel";
            Pages.Items = await db.QueryGetEntityList<ObjectModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        /// <summary>
        /// Get Info Objects
        /// </summary>
        /// <returns>Get All Record</returns>
        public async Task<GenericPageByPage<ObjectModel>> ObjectListAsync()
        {
            GenericPageByPage<ObjectModel> Pages = new GenericPageByPage<ObjectModel>();
            string query = "Select ObjectModel.Id,Name,Data,FileType" +
               " From ObjectModel,FileModel" +
               " where ObjectModel.FileId=FileModel.Id";

            Pages.Items = await db.QueryGetEntityList<ObjectModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }
        /// <summary>
        /// Get Info Sentence Making
        /// </summary>
        /// <param name="PageSize">Count Records</param>
        /// <param name="PageNumber">Start Record</param>
        /// <returns>Get Limit Record</returns>
        public async Task<GenericPageByPage<SentenceMakingModel>> SentenceMakingListAsync(int PageNumber,int PageSize)
        {
            GenericPageByPage<SentenceMakingModel> Pages = new GenericPageByPage<SentenceMakingModel>();
            string query = "Select SentenceMakingModel.Id,SubjectId,ObjectId,VerbId," +
                "(Select FileModel.Data from FileModel where FileModel.Id=SubjectModel.FileId) as SubjectData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=SubjectModel.FileId) as SubjectFileType," +
                "(Select FileModel.Data from FileModel where FileModel.Id=ObjectModel.FileId) as ObjectData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=ObjectModel.FileId) as ObjectFileType," +
                "(Select FileModel.Data from FileModel where FileModel.Id=VerbModel.FileId) as VerbData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=VerbModel.FileId) as VerbFileType" +
                " From SentenceMakingModel,SubjectModel,ObjectModel,VerbModel" +
                " where  SentenceMakingModel.SubjectId=SubjectModel.Id" +
                " And SentenceMakingModel.ObjectId=ObjectModel.Id" +
                " And SentenceMakingModel.VerbId =VerbModel.Id" +
                " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From SentenceMakingModel";
            Pages.Items = await db.QueryGetEntityList<SentenceMakingModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        /// <summary>
        /// Get Info SentenceMaking
        /// </summary>
        /// <returns>Get All Record</returns>
        public async Task<GenericPageByPage<SentenceMakingModel>> SentenceMakingListAsync()
        {
            GenericPageByPage<SentenceMakingModel> Pages = new GenericPageByPage<SentenceMakingModel>();
            string query = "Select SentenceMakingModel.Id,SubjectId,ObjectId,VerbId," +
                "(Select FileModel.Data from FileModel where FileModel.Id=SubjectModel.FileId) as SubjectData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=SubjectModel.FileId) as SubjectFileType," +
                "(Select FileModel.Data from FileModel where FileModel.Id=ObjectModel.FileId) as ObjectData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=ObjectModel.FileId) as ObjectFileType," +
                "(Select FileModel.Data from FileModel where FileModel.Id=VerbModel.FileId) as VerbData," +
                "(Select FileModel.FileType from FileModel where FileModel.Id=VerbModel.FileId) as VerbFileType" +
                " From SentenceMakingModel,SubjectModel,ObjectModel,VerbModel" +
                " where  SentenceMakingModel.SubjectId=SubjectModel.Id" +
                " And SentenceMakingModel.ObjectId=ObjectModel.Id" +
                " And SentenceMakingModel.VerbId =VerbModel.Id";
            Pages.Items = await db.QueryGetEntityList<SentenceMakingModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }
        /// <summary>
        /// Get Info Subject 
        /// </summary>
        /// <param name="PageSize">Count Records</param>
        /// <param name="PageNumber">Start Record</param>
        /// <returns>Get Limit Record</returns>
        public async Task<GenericPageByPage<SubjectModel>> SubjectListAsync(int PageNumber,int PageSize)
        {
            GenericPageByPage<SubjectModel> Pages = new GenericPageByPage<SubjectModel>();
            string query = "Select SubjectModel.Id,Name,Data,FileType" +
               " From SubjectModel,FileModel" +
               " where SubjectModel.FileId=FileModel.Id" +
                " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From SubjectModel";
            Pages.Items = await db.QueryGetEntityList<SubjectModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        /// <summary>
        /// Get Info Subject 
        /// </summary>
        /// <returns>Get All Records</returns>
        public async Task<GenericPageByPage<SubjectModel>> SubjectListAsync()
        {
            GenericPageByPage<SubjectModel> Pages = new GenericPageByPage<SubjectModel>();
            string query = "Select SubjectModel.Id,Name,Data,FileType" +
               " From SubjectModel,FileModel" +
               " where SubjectModel.FileId=FileModel.Id";
            Pages.Items = await db.QueryGetEntityList<SubjectModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }
        /// <summary>
        /// Get Info Verb
        /// </summary>
        /// <param name="PageSize">Count Records</param>
        /// <param name="PageNumber">Start Record</param>
        /// <returns>Get Limit Record</returns>
        public async Task<GenericPageByPage<VerbModel>> VerbListAsync( int PageNumber,int PageSize)
        {
            GenericPageByPage<VerbModel> Pages = new GenericPageByPage<VerbModel>();
            string query = "Select VerbModel.Id,Name,Data,FileType" +
               " From VerbModel,FileModel" +
               " where VerbModel.FileId=FileModel.Id" +
                " LIMIT " + PageSize + " OFFSET " + (PageNumber - 1);
            string queryCount = "Select Count(Id) From VerbModel";
            Pages.Items = await db.QueryGetEntityList<VerbModel>(query);
            Pages.RowCount = await db.GetCount(queryCount);
            return Pages;
        }
        /// <summary>
        /// Get Info Verb
        /// </summary>
        /// <returns>Get All Records</returns>
        public async Task<GenericPageByPage<VerbModel>> VerbListAsync()
        {
            GenericPageByPage<VerbModel> Pages = new GenericPageByPage<VerbModel>();
            string query = "Select VerbModel.Id,Name,Data,FileType" +
               " From VerbModel,FileModel" +
               " where VerbModel.FileId=FileModel.Id";
            Pages.Items = await db.QueryGetEntityList<VerbModel>(query);
            Pages.RowCount = Pages.Items.Count;
            return Pages;
        }
    }
}
