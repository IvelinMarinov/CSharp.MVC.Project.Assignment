namespace MyMovieDb.Common.ViewModels.Admin
{
    public class ManageUserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        //public string FullName { get; set; }

        public bool IsModerator { get; set; }

        public bool IsAdmin { get; set; }
    }
}
