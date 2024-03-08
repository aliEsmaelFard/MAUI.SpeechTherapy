namespace MAUI.SpeechTherapy.Models
{
    public class GenericPageByPage<TEntity>  where TEntity : class
    {
        public List<TEntity> Items { get; set; }
        public TEntity Item { get; set; }
        public int RowCount { get; set; }
    }
}
