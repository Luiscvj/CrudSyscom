namespace LibraryCrud.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IAuthor Authors { get; } 
        public IBook Books { get; }
        public IGenre Genres { get; }

        Task<int> SaveAsync();


    }
}
