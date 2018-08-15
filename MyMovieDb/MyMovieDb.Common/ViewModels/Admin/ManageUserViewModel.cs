namespace MyMovieDb.Common.ViewModels.Admin
{
    public class ManageUserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public bool IsModerator { get; set; }

        public bool IsAdmin { get; set; }
    }
}
